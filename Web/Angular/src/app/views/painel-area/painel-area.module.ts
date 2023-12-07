import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PainelAreaComponent } from './painel-area.component';
import { PainelAreaRoutingModule } from './painel-area-routing.module';

import {
  CardModule,
  GridModule,
  SpinnerModule,
  TableModule,
  CarouselModule,
} from '@coreui/angular';

import { ChartjsModule } from '@coreui/angular-chartjs';
import { IconModule } from '@coreui/icons-angular';
import { PainelAreaPipe } from './pipes/painel-area.pipe';

@NgModule({
  imports: [
    CommonModule,
    PainelAreaRoutingModule,
    CardModule,
    GridModule,
    SpinnerModule,
    TableModule,
    ChartjsModule,
    IconModule,
    CarouselModule,
  ],
  declarations: [
    PainelAreaComponent,
    PainelAreaPipe,
  ],
})
export class PainelAreaModule { }
