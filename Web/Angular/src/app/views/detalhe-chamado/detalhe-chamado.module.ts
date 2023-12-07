import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { IconModule } from '@coreui/icons-angular';
import { DetalheChamadoComponent } from '../detalhe-chamado/detalhe-chamado.component';
import { DetalheChamadoRoutingModule } from '../detalhe-chamado/detalhe-chamado-routing.module';

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
  SpinnerModule,
  BadgeModule,
  ToastModule,
  AccordionModule,
  AlertModule,
} from '@coreui/angular';

import {} from '@coreui/angular';

@NgModule({
  imports: [
    DetalheChamadoRoutingModule,
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
    SpinnerModule,
    BadgeModule,
    ToastModule,
    AccordionModule,
    AlertModule,
  ],
  declarations: [DetalheChamadoComponent],
})
export class DetalheChamadoModule {}
