import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { OpcaoControleBase } from './opcao-base';
import { FormularioRespostaOpcao } from '../../../models/formulario/formulario-resposta-opcao';

@Component({
  selector: 'app-opcao',
  templateUrl: './dynamic-form-opcao.component.html',
})
export class DynamicFormOpcaoComponent {
  private TEXTBOX: string = 'textbox';
  private TEXTAREA: string = 'textarea';
  private DROPDOWN: string = 'dropdown';

  @Input() opcao!: OpcaoControleBase<string>;
  @Input() resposta!: FormularioRespostaOpcao;
  @Input() form!: FormGroup;
  @Output() respostaChange = new EventEmitter<FormularioRespostaOpcao>();

  descricao!: string;

  constructor() {
  }

  get isValid() {
    return this.form == null ? true : this.form.controls[this.opcao.key]?.valid;
  }

  onItemChange(opcao: OpcaoControleBase<string>, event: any) {
    this.resposta = new FormularioRespostaOpcao({
      idQuestao: opcao.idQuestao,
      idResposta: opcao.id,
      descricao:
        opcao.controlType == this.TEXTBOX ||
        opcao.controlType == this.TEXTAREA ||
        opcao.controlType == this.DROPDOWN
          ? opcao.texto + '|' + opcao.controlType + '|' + event.target.value
          : opcao.texto,
    });
    this.respostaChange.emit(this.resposta);
  }
}
