import { Component, OnInit } from '@angular/core';

import { FormsService } from '../../services/forms.service';
import { ChamadoService } from '../../services/chamados.service';
import { QuestaoBase } from '../dynamic-form/questao/questao-base';
import { FormularioResposta } from '../../models/formulario/formulario-resposta';
import { FormularioQuestionario } from '../../models/formulario/formulario-questionario';
import { Router } from '@angular/router';
import { AlertMessageModule } from 'src/app/core/alert-message.module';
import { AlertType } from 'src/app/models/enum/alert-type.enum';

@Component({
  templateUrl: 'abrir-chamado.component.html',
  styleUrls: ['abrir-chamado.component.scss']
})
export class AbrirChamadoComponent implements OnInit {
  primeiraQuestao: QuestaoBase;
  formulario!: FormularioQuestionario;
  loading: boolean = true;

  constructor(private formsService: FormsService, private chamadoService: ChamadoService, private _router: Router, private alertModule: AlertMessageModule) {
    this.primeiraQuestao = new QuestaoBase();
    this.formsService.obterFormulario().subscribe(result => {
      this.formulario = result;
      this.primeiraQuestao = result.primeiraQuestao;
      setTimeout(() => {
        this.loading = false;
      }, 100);
    });
  }

  ngOnInit(): void {

  }

  onSubmit(payload: FormularioResposta) {
    payload.idFormulario = this.formulario.idFormulario;
    this.loading = true;
    this.chamadoService.abrirChamado(payload).subscribe(result => {
      this.alertModule.showAlert(AlertType.Success, "Chamado aberto com sucesso");
      this._router.navigate(['/'], { replaceUrl: true });
    }, (error) => {
      this.loading = false;
    })
  }
}