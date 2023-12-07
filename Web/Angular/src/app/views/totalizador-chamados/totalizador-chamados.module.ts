import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {
  ButtonModule,
  CardModule,
  DropdownModule,
  GridModule,
  ProgressModule,
  SharedModule,
  WidgetModule
} from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { ChartjsModule } from '@coreui/angular-chartjs';

import { WidgetsRoutingModule } from '../widgets/widgets-routing.module';
import { TotalizadorChamadosComponent } from './totalizador-chamados.component';

@NgModule({
  declarations: [
    TotalizadorChamadosComponent,
  ],
  imports: [
    CommonModule,
    WidgetsRoutingModule,
    GridModule,
    WidgetModule,
    IconModule,
    DropdownModule,
    SharedModule,
    ButtonModule,
    CardModule,
    ProgressModule,
    ChartjsModule
  ],
  exports: [
    TotalizadorChamadosComponent
  ]
})
export class TotalizadorChamadosModule {
}
