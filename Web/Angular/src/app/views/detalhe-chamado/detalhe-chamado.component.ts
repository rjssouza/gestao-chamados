import {
  Component,
  ElementRef,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { ChamadoService } from '../../services/chamados.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertMessageModule } from 'src/app/core/alert-message.module';
import { AlertType } from 'src/app/models/enum/alert-type.enum';

import {
  Anexo,
  Comentario,
  DetalheChamadoViewModel,
  ResultDetalheChamadoViewModel,
  Time,
} from '../../models/chamado/detalheChamadoViewModel';
import {
  AnexoChamadoArquivoViewModel,
  AnexoChamadoViewModel,
} from '../../models/anexo/anexoChamadoViewModel';
import { HttpResponse } from '@angular/common/http';
import { RegistrarProgressoChamadoViewModel } from 'src/app/models/chamado/registrarProgressoChamadoViewModel';

@Component({
  templateUrl: 'detalhe-chamado.component.html',
  styleUrls: ['detalhe-chamado.component.scss'],
})
export class DetalheChamadoComponent implements OnInit {
  @Input() carregandoAnexo: boolean = false;
  @Input() baixandoAnexo: boolean = false;
  @Input() removendoAnexo: boolean = false;
  @Input() chamadoViewModel: DetalheChamadoViewModel;
  @Input() times: Time[];

  @ViewChild('formAnexarAquivo', { static: false })
  formAnexarAquivo: ElementRef;
  idChamado: number = 0;
  ehAdministrador: boolean = true;
  filtrarAtendente: boolean = false;
  filtrarSolicitante: boolean = false;
  comentarios?: Comentario[] = [];
  statusFinalizado: boolean = false;

  constructor(
    private chamadoService: ChamadoService,
    private _router: Router,
    private alertModule: AlertMessageModule,
    private _activatedRoute: ActivatedRoute
  ) {
    this.chamadoViewModel = new DetalheChamadoViewModel();
    this.times = [];
    this.carregandoAnexo = false;
    this.baixandoAnexo = false;
    this.removendoAnexo = false;
    this.formAnexarAquivo = new Input();
  }

  permiteAdicionarAtendimento(): boolean {
    return !this.habilitarFecharChamado();
  }

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe((params: any) => {
      this.idChamado = params.idChamado;
      this.chamadoService
        .obterDetalheChamado(this.idChamado)
        .subscribe((result) => {
          this.preencherDetalheChamado(result);
        });
    });
  }

  preencherDetalheChamado(result: ResultDetalheChamadoViewModel) {
    const data = result as unknown as ResultDetalheChamadoViewModel;
    if (data && data.result?.length > 0) {
      this.chamadoViewModel = data.result[0];
      this.ehAdministrador = data.ehAdministrador;
      this.times = data.times;
      this.comentarios = this.chamadoViewModel.comentarios;
      this.statusFinalizado = this.chamadoViewModel?.status === 3 ? true : false;
    }
  }

  habilitarIniciarAtendimentoChamado(): boolean {
    return !this.chamadoViewModel?.dtAtendimento;
  }

  habilitarFecharChamado(): boolean {
    return !this.chamadoViewModel?.dtFechamento;
  }

  validarNovoComentario(): boolean {
    return (
      this.chamadoViewModel?.novoComentario != null &&
      this.chamadoViewModel?.novoComentario.length > 0
    );
  }

  iniciaratendimento() {
    if (
      confirm(
        `Deseja iniciar o atendimento do chamado ${this.chamadoViewModel.id}?`
      )
    ) {
      this.chamadoService.iniciaratendimento(this.idChamado).subscribe(
        (result) => {
          this.alertModule.showAlert(
            AlertType.Success,
            'Chamado iniciado atendimento com sucesso'
          );
          //this._router.navigate(['/'], { replaceUrl: true });
          this.preencherDetalheChamado(result);
        },
        (error) => {}
      );
    }
  }

  fecharChamado() {
    if (
      !this.chamadoViewModel.atendimento ||
      this.chamadoViewModel.atendimento == ''
    ) {
      alert('Por favor. Descreva sobre o atendimento realizado no campo acima');
      return;
    } else if (
      confirm(`Confirmar o fechamento do chamado ${this.chamadoViewModel.id}?`)
    ) {
      this.chamadoService
        .fecharChamado(this.idChamado, this.chamadoViewModel.atendimento)
        .subscribe(
          (result) => {
            this.alertModule.showAlert(
              AlertType.Success,
              'Chamado fechado com sucesso'
            );
            //this._router.navigate(['/'], { replaceUrl: true });
            this.preencherDetalheChamado(result);
          },
          (error) => {}
        );
    }
  }

  adicionarComentario() {
    if (!!this.chamadoViewModel?.novoComentario) {
      this.chamadoService
        .adicionarComentario(
          this.idChamado,
          this.chamadoViewModel?.novoComentario
        )
        .subscribe(
          (result) => {
            this.alertModule.showAlert(
              AlertType.Success,
              'Comentário adicionado com sucesso'
            );
            //this._router.navigate(['/'], { replaceUrl: true });
            this.preencherDetalheChamado(result);
          },
          (error) => {}
        );
    }
  }

  baixarAnexo(anexo: Anexo, evento: any) {
    this.baixandoAnexo = true;
    this.chamadoService.baixarAnexo(anexo.id).subscribe(async (event: any) => {
      let data = event as HttpResponse<Blob>;
      const downloadedFile = new Blob([data.body as BlobPart], {
        type: data.body?.type,
      });
      if (downloadedFile.type != '') {
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = anexo.nomeArquivo;
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);
      }
      this.baixandoAnexo = false;
    });
  }

  removerAnexo(anexo: Anexo, evento: any) {
    if (confirm(`Confirmar a exclusão do arquivo: ${anexo.nomeArquivo}?`)) {
      this.removendoAnexo = true;
      this.chamadoService.removerAnexo(anexo.id).subscribe(
        (result) => {
          this.alertModule.showAlert(
            AlertType.Success,
            `Arquivo ${anexo.nomeArquivo} excluído com sucesso`
          );
          this.removendoAnexo = false;
          this.preencherDetalheChamado(result);
        },
        (error) => {
          this.removendoAnexo = false;
        }
      );
    }
  }

  onItemChangeAdicionarAnexo(
    chamadoViewModel: DetalheChamadoViewModel,
    event: any
  ) {
    const files = event.target.files;
    if (files) {
      const anexoChamadoViewModel: AnexoChamadoViewModel = {
        idChamado: chamadoViewModel.id,
        anexoChamadoArquivoViewModel: [],
      };

      for (let file of files) {
        this.carregandoAnexo = true;
        const reader = new FileReader();
        reader.onload = (e: any) => {
          const novoAnexo: AnexoChamadoArquivoViewModel = {
            anexo: e.target.result.toString().replace(/^data:(.*,)?/, ''),
            nomeArquivo: file.name,
            tipoArquivo: '',
          };
          anexoChamadoViewModel.anexoChamadoArquivoViewModel.push(novoAnexo);

          this.chamadoService.adicionarAnexo(anexoChamadoViewModel).subscribe(
            (result) => {
              this.alertModule.showAlert(
                AlertType.Success,
                'Anexo(s) incluído(s) com sucesso'
              );
              this.carregandoAnexo = false;
              this.formAnexarAquivo.nativeElement.value = '';
              this.preencherDetalheChamado(result);
            },
            (error) => {
              this.carregandoAnexo = false;
            }
          );
        };
        reader.readAsDataURL(file);
      }
    }
  }

  onItemChangeAtendente(chamadoViewModel: DetalheChamadoViewModel, event: any) {
    const nomeNovoAntendete =
      event?.target[event?.target?.selectedIndex]?.text ?? event?.target?.value;
    if (
      confirm(
        `Deseja alterar o usuário de atendimento do chamado ${chamadoViewModel.id}\nDE: ${chamadoViewModel.chamadoTime?.nomeDoTime}\nPARA: ${nomeNovoAntendete}?`
      )
    ) {
      this.chamadoService
        .mudarAtendente(this.idChamado, event.target.value)
        .subscribe(
          (result) => {
            this.alertModule.showAlert(
              AlertType.Success,
              'Atendente alterado com sucesso'
            );
            //this._router.navigate(['/'], { replaceUrl: true });
            this.preencherDetalheChamado(result);
          },
          (error) => {}
        );
    }
    if (event?.target) {
      event.target.selectedIndex = 0;
    }
  }

  onTextAreaChangeComentario(event: any) {
    if (!!this.chamadoViewModel) {
      this.chamadoViewModel.novoComentario = event.target.value.toString();
    }
  }

  onTextAreaChangeAtendimento(event: any) {
    if (!!this.chamadoViewModel) {
      this.chamadoViewModel.atendimento = event.target.value.toString();
    }
  }

  registrarProgresso() {
    if (
      confirm(
        `Confirma o registro do progresso para ${this.chamadoViewModel.percentualAtendimento}% ?`
      )
    ) {
      const registrarProgressoChamadoViewModel =
        new RegistrarProgressoChamadoViewModel(
          `Registro do progresso para ${this.chamadoViewModel.percentualAtendimento}%`,
          this.idChamado,
          Number(this.chamadoViewModel.percentualAtendimento)
        );
      this.chamadoService
        .registrarProgresso(registrarProgressoChamadoViewModel)
        .subscribe(
          (result) => {
            this.alertModule.showAlert(
              AlertType.Success,
              'Progresso do chamado alterado com sucesso'
            );
            this.chamadoService
              .obterDetalheChamado(this.idChamado)
              .subscribe((result) => {
                this.preencherDetalheChamado(result);
              });
          },
          (error) => {}
        );
    }
  }

  onItemChangePercentualAtendimento(event: any) {
    if (!event.target.value) {
      return;
    }
    const novoPercentual = Number(event.target.value.toString() ?? 0);
    const percentualAtual = Number(
      this.chamadoViewModel.percentualAtendimento ?? 0
    );
    if (novoPercentual < 0 || novoPercentual > 100) {
      alert('Percentual de atendimento precisa estar entre 0 e 100');
      event.target.value = percentualAtual;
      return;
    }
    this.chamadoViewModel.percentualAtendimento = novoPercentual;
  }

  filtrarComentarios() {
    this.comentarios = this.chamadoViewModel.comentarios?.filter(
      (t) =>
        (this.filtrarSolicitante && t.ehAtualSolicitante) ||
        (this.filtrarAtendente && !t.ehAtualSolicitante) ||
        (!this.filtrarSolicitante && !this.filtrarAtendente)
    );
  }
}
