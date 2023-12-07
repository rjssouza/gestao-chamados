import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators, RadioControlValueAccessor } from '@angular/forms';

import { OpcaoControleBase } from './opcao-base';

@Injectable()
export class OpcaoControlService {
  toFormGroup(questions: OpcaoControleBase<string>[] ) {
    const group: any = {};
    questions.forEach(question => {
      group[question.key] = question.required ? new FormControl(question.value || '', Validators.required)
                                              : new FormControl(question.value || '');
    });
    return new FormGroup(group);
  }
}