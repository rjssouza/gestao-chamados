import { Component, Input, OnInit } from '@angular/core';

import { cilArrowTop, cilOptions } from '@coreui/icons';
import { Evolutivo } from '../../models/dashboard/evolutivo/evolutivo';
import {
  DashboardChartsData,
  IChartProps,
} from './dashboard-charts-data';

@Component({
  selector: 'evolutivo-mensal',
  templateUrl: './evolutivo-mensal.component.html',
})
export class EvolutivoMensalComponent implements OnInit {
  icons = { cilOptions, cilArrowTop };

  @Input() model!: Evolutivo;
  public mainChart!: IChartProps;

  constructor(private chartsData: DashboardChartsData) {}

  ngOnInit(): void {
    this.chartsData.initMainChart(this.model);
    this.initCharts();
  }

  
  initCharts(): void {
    this.mainChart = this.chartsData.mainChart;
  }
}
