import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { IconModule } from '@coreui/icons-angular';
import { AbrirChamadoComponent } from '../abrir-chamado/abrir-chamado.component';
import { AbrirChamadoRoutingModule } from '../abrir-chamado/abrir-chamado-routing.module';
import { DynamicFormQuestaoComponent } from '../dynamic-form/questao/dynamic-form-question.component';
import { DynamicFormOpcaoComponent } from '../dynamic-form/opcao/dynamic-form-opcao.component';

import {
  AvatarModule,
  ButtonGroupModule,
  ButtonModule,
  CardModule,
  FormModule,
  GridModule,
  NavModule,
  ProgressModule,
  TableModule,
  TabsModule,
  DropdownModule,
  ListGroupModule,
  SharedModule,
  SpinnerModule
} from '@coreui/angular';

import {

} from '@coreui/angular';

@NgModule({
  imports: [
    AbrirChamadoRoutingModule ,
    CardModule,
    NavModule,
    IconModule,
    TabsModule,
    CommonModule,
    GridModule,
    ProgressModule,
    ReactiveFormsModule,
    ButtonModule,
    FormModule,
    ButtonModule,
    ButtonGroupModule,
    AvatarModule,
    TableModule,
    DropdownModule,
    ListGroupModule,
    SharedModule,
    SpinnerModule
  ],
  declarations: [
    AbrirChamadoComponent,
    DynamicFormQuestaoComponent,
    DynamicFormOpcaoComponent
  ]
})
export class AbrirChamadoModule {
}
