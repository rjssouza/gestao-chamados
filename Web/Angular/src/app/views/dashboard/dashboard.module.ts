import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import {
  AvatarModule,
  ButtonGroupModule,
  ButtonModule,
  CardModule,
  FormModule,
  GridModule,
  NavModule,
  ProgressModule,
  SpinnerModule,
  TableModule,
  TabsModule,
  ModalModule 
} from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { ChartjsModule } from '@coreui/angular-chartjs';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';

import { WidgetsModule } from '../widgets/widgets.module';
import { TotalizadorChamadosModule } from '../totalizador-chamados/totalizador-chamados.module';
import { EvolutivoMensalModule } from '../evolutivo-mensal/evolutivo-mensal.module';
import { IncidentesAreaModule } from '../incidentes-area/incidentes-area.module';
import { TableFilterPipe } from './table-filter.pipe';

@NgModule({
  imports: [
    DashboardRoutingModule,
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
    ChartjsModule,
    AvatarModule,
    TableModule,
    WidgetsModule,
    TotalizadorChamadosModule,
    EvolutivoMensalModule,
    SpinnerModule,
    IncidentesAreaModule,
    FormsModule,
    ModalModule
  ],
  declarations: [DashboardComponent, TableFilterPipe]
})
export class DashboardModule {}
