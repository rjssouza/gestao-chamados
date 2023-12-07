import { Component, Input, OnInit } from '@angular/core';

import { cilArrowTop, cilOptions } from '@coreui/icons';
import { getStyle } from '@coreui/utils/src';
import { Totalizador } from 'src/app/models/dashboard/totalizadores/totalizador';
import { TotalizadorDetalhes } from 'src/app/models/dashboard/totalizadores/totalizador-detalhes';

@Component({
  selector: 'totalizador-chamados',
  styleUrls: ['./totalizador-chamados.component.scss'],
  templateUrl: './totalizador-chamados.component.html',
})
export class TotalizadorChamadosComponent implements OnInit {

  icons = { cilOptions, cilArrowTop };

  @Input() model!: TotalizadorDetalhes;
  data: any = {};
  options: any = {};

  labels = [
    {mesDesc: 'Janeiro', mes: 1},
    {mesDesc: 'Fevereiro', mes: 2},
    {mesDesc: 'Março', mes: 3},
    {mesDesc: 'Abril', mes: 4},
    {mesDesc: 'Maio', mes: 5},
    {mesDesc: 'Junho', mes: 6},
    {mesDesc: 'Julho', mes: 7},
    {mesDesc: 'Agosto', mes: 8},
    {mesDesc: 'Setembro', mes: 9},
    {mesDesc: 'Outubro', mes: 10},
    {mesDesc: 'Novembro', mes: 11},
    {mesDesc: 'Dezembro', mes: 12},
  ];

  dataset = {
      label: 'Quantidade Mensal',
      backgroundColor: 'transparent',
      borderColor: 'rgba(255,255,255,.55)',
      pointBackgroundColor: getStyle('--cui-primary'),
      pointHoverBorderColor: getStyle('--cui-primary'),
      data: [100, 50, 30, 44, 9, 3, 6, 1, 3, 2, 8, 12]
    };

  optionsDefault = {
    plugins: {
      legend: {
        display: false
      }
    },
    maintainAspectRatio: true,
    scales: {
      x: {
        grid: {
          display: false,
          drawBorder: false
        },
        ticks: {
          display: false
        }
      },
      y: {
        display: false,
        grid: {
          display: false
        },
        ticks: {
          display: false
        }
      }
    },
    elements: {
      line: {
        borderWidth: 1,
        tension: 0.4
      },
      point: {
        radius: 4,
        hitRadius: 10,
        hoverRadius: 4
      }
    }
  };

  ngOnInit(): void {
    this.options = this.optionsDefault;
    this.dataset.data = this.model.valorMensal?.map(t => t.valor)
    this.dataset.backgroundColor = getStyle(`--cui-${this.model.cor}`);
    this.dataset.pointHoverBorderColor = getStyle(`--cui-${this.model.cor}`);
    this.dataset.pointBackgroundColor = getStyle(`--cui-${this.model.cor}`);
    this.data = {
      labels: this.labels.filter(t => this.model.valorMensal.findIndex(e => e.mes == t.mes) > -1).map(t => t.mesDesc),
      datasets: [this.dataset]
    };
  }
}