import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import {
  ButtonModule,
  CardModule,
  DropdownModule,
  GridModule,
  ProgressModule,
  SharedModule,
  WidgetModule,
  FormModule
} from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { ChartjsModule } from '@coreui/angular-chartjs';

import { WidgetsRoutingModule } from '../widgets/widgets-routing.module';
import { IncidentesAreaComponent } from './incidentes-area.component';

@NgModule({
  declarations: [
    IncidentesAreaComponent,
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
    ChartjsModule,
    FormModule
  ],
  exports: [
    IncidentesAreaComponent
  ]
})
export class IncidentesAreaModule {
}
