import { Injectable, ViewEncapsulation } from '@angular/core';
import { getStyle, hexToRgba } from '@coreui/utils/src';
import { Evolutivo } from 'src/app/models/dashboard/evolutivo/evolutivo';
import { TotalPorcentagem } from 'src/app/models/dashboard/total-porcentagem';
import { Context } from 'chartjs-plugin-datalabels';

export interface IChartProps {
  data?: any;
  labels?: any;
  options?: any;
  colors?: any;
  type?: any;
  legend?: any;
  totalizadores?: TotalPorcentagem[];
  datalabels?: any;
  [propName: string]: any;
}

@Injectable({
  providedIn: 'any',
})
export class DashboardChartsData {
  constructor() {
  }

  public mainChart: IChartProps = {};

  public random(min: number, max: number) {
    return Math.floor(Math.random() * (max - min + 1) + min);
  }

  initMainChart(evolutivo: Evolutivo) {
    this.mainChart['elements'] = 12;
    let labels = [
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
    const datasets = [{}];
    evolutivo.evolucaoMensal.forEach(element => {
      let item = {
          data: element.evolutivoMensal.map(t => t.valor),
          label: element.descricao,
          backgroundColor: getStyle(`--cui-${element.cor}`),
          borderColor: getStyle(`--cui-${element.cor}`),
          pointHoverBackgroundColor: getStyle(`--cui-${element.cor}`),
          borderWidth: 2,
          fill: true,
          datalabels: {
            anchor: 'end',
            color: 'white',
            font: {
              weight: 'bold',
              size: '12',
            },
            textShadowBlur: 4,
            textShadowColor: 'black'
          }
        };
        
        datasets.push(item);
    });
    
    const quantidadeMaxima = Math.max.apply(Math, evolutivo.evolucaoMensal?.map(function(o) { 
      var valor = 0;
      for (var i = 0; i < o.evolutivoMensal.length; i++){
          if(o.evolutivoMensal[i].valor > valor)
            valor = o.evolutivoMensal[i].valor;
      }
      return valor;
    })) + 5;

    //(evolutivo.totalizadores?.map(t => t.porcentagem) ?? 1) + 5;

    const plugins = {
      legend: {
        display: false,
      },
      tooltip: {
        callbacks: {
          labelColor: function (context: any) {
            return {
              backgroundColor: context.dataset.borderColor,
            };
          },
        },
      },
    };

    const options = {
      maintainAspectRatio: false,
      plugins,
      scales: {
        x: {
          grid: {
            drawOnChartArea: false,
          },
        },
        y: {
          beginAtZero: true,
          max: quantidadeMaxima,
          ticks: {
            maxTicksLimit: 5,
            stepSize: Math.ceil(quantidadeMaxima / 5),
          },
        },
      },
      elements: {
        line: {
          tension: 0.4,
        },
        point: {
          radius: 0,
          hitRadius: 10,
          hoverRadius: 4,
          hoverBorderWidth: 3,
        },
      },
    };

    this.mainChart.totalizadores = evolutivo.totalizadores;
    this.mainChart.type = 'bar';
    this.mainChart.options = options;
    this.mainChart.data = {
      datasets,
      labels: labels.map(t => t.mesDesc),
    };

  }
}
