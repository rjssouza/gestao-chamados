import {
  Component,
  Input,
  OnInit,
  NgModule,
  ViewChild,
  ElementRef,
} from '@angular/core';
import { FormGroup } from '@angular/forms';
import { OpcaoControleBase } from '../opcao/opcao-base';
import { OpcaoControlService } from '../opcao/opcao-control.service';
import { QuestaoBase } from './questao-base';
import { FormularioRespostaOpcao } from '../../../models/formulario/formulario-resposta-opcao';
import { FormularioResposta } from '../../../models/formulario/formulario-resposta';
import { Output, EventEmitter } from '@angular/core';
import { FormularioQuestionario } from 'src/app/models/formulario/formulario-questionario';
import { AnexoChamadoArquivoViewModel } from 'src/app/models/anexo/anexoChamadoViewModel';

@Component({
  selector: 'app-dynamic-questao',
  templateUrl: './dynamic-form-question.component.html',
  providers: [OpcaoControlService],
})
export class DynamicFormQuestaoComponent implements OnInit {
  @Input() questao: QuestaoBase | null;
  @Input() anexos: AnexoChamadoArquivoViewModel[] = [];
  @Input() formulario: FormularioQuestionario | null;
  @Output() onSubmit = new EventEmitter();

  @ViewChild('formAnexarAquivo', { static: false })
  formAnexarAquivo: ElementRef;

  form!: FormGroup;
  payLoad: FormularioResposta = new FormularioResposta();
  resposta!: FormularioRespostaOpcao;
  questoesAnteriores: QuestaoBase[] = [];

  constructor(private qcs: OpcaoControlService) {
    this.questao = new QuestaoBase();
    this.formulario = new FormularioQuestionario();
    this.anexos = [];
    this.formAnexarAquivo = new Input();
  }

  exibeAnterior(): boolean {
    return this.questoesAnteriores.length > 0;
  }

  ngOnInit() {
    setTimeout(() => {
      this.payLoad.idFormulario = this.questao?.idFormulario || 0;
      this.form = this.qcs.toFormGroup(
        this.questao?.opcoes as OpcaoControleBase<string>[]
      );
    }, 100);
  }

  submit() {
    this.addRespostaStack();
    this.onSubmit.emit(this.payLoad);
  }

  onNext(event: any) {
    this.addRespostaStack();
    this.carregarProximaQuestao();
  }

  onPrev(event: any) {
    this.removerRespostaStack();
    this.carregarQuestaoAnterior();
  }

  addRespostaStack() {
    if(this.resposta != undefined) {
    var index = this.payLoad.respostas.findIndex(
      (t) => t.idResposta == this.resposta.idResposta
    );

    if (index >= 0) return;

    this.payLoad.respostas.push(this.resposta);
    }
  }

  removerRespostaStack() {
    var index = this.payLoad.respostas.length - 1;
    this.resposta = this.payLoad.respostas[index];

    this.payLoad.respostas.splice(index, 1);
  }

  carregarProximaQuestao() {
    console.log(this.questao)
    if (this.questao == null || this.resposta == undefined ) return;

    var proximaQuestao = this.questao?.opcoes.find(
      (t) => t.id == this.resposta.idResposta
    )?.proximaQuestao;
    if (proximaQuestao == null) throw new Error('Questao não formatada');
    this.questoesAnteriores.push(this.questao);

    this.carregarQuestao(proximaQuestao);
  }

  carregarQuestaoAnterior() {
    if (this.questoesAnteriores.length <= 0)
      throw new Error('Questao não formatada');
    var index = this.questoesAnteriores.length - 1;
    var questaoAnterior =
      this.questoesAnteriores[this.questoesAnteriores.length - 1];
    this.questoesAnteriores.splice(index, 1);

    this.carregarQuestao(questaoAnterior);
  }

  carregarQuestao(proximaQuestao: QuestaoBase) {
    this.questao = proximaQuestao || null;
    this.form = this.qcs.toFormGroup(
      this.questao?.opcoes as OpcaoControleBase<string>[]
    );
  }

  onItemChangeAdicionarAnexo(event: any) {
    const files = event.target.files;
    if (files) {
      for (let file of files) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
          const novoAnexo: AnexoChamadoArquivoViewModel = {
            anexo: e.target.result.toString().replace(/^data:(.*,)?/, ''),
            nomeArquivo: file.name,
            tipoArquivo: '',
          };
          this.anexos.push(novoAnexo);
          this.payLoad.anexos = this.anexos;
          this.formAnexarAquivo.nativeElement.value = '';
        };
        reader.readAsDataURL(file);
      }
    }
  }

  removerAnexo(anexo: AnexoChamadoArquivoViewModel, evento: any) {
    const fAnexo = this.anexos.filter(
      (f) => f.nomeArquivo != anexo.nomeArquivo
    );
    this.anexos = fAnexo;
    this.payLoad.anexos = this.anexos;
  }

  enviarFormulario() {}
}
