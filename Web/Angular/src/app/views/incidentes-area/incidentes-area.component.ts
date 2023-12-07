import { Component, Input, OnInit } from '@angular/core';

import { IncidentesPorArea } from 'src/app/models/dashboard/incidentes/incidentes-por-area';
import { IncidentesPorAreaStatus } from 'src/app/models/dashboard/incidentes/incidentes-por-area-status';
import { IncidentesAreaStatus } from 'src/app/models/dashboard/incidentes/incidentes-areaStatus';
import { IncidentesAreaTipo } from 'src/app/models/dashboard/incidentes/incidentes-areaTipo';
import { IncidentesPorAreaTipo } from 'src/app/models/dashboard/incidentes/incidentes-por-area-tipo';

import { Chart } from 'chart.js';
import ChartDataLabels from 'chartjs-plugin-datalabels';

@Component({
  selector: 'incidentes-area',
  templateUrl: './incidentes-area.component.html',
})
export class IncidentesAreaComponent implements OnInit {

  @Input() modelStatus!: IncidentesPorAreaStatus;
  @Input() modelTipo!: IncidentesPorAreaTipo;

  porStatus: boolean = true;
  porTipo: boolean = false;

  chartDoughnutDataHPDC: any;
  chartDoughnutDataUsi: any;
  chartDoughnutDataSPM: any;
  chartDoughnutData: any;

  novo: string = 'Novo';
  atendimento: string = 'Atendimento';
  finalizado: string = 'Finalizado';

  duvida: string = 'Dúvida';
  erroEmRelatorio: string = 'Erro em relatório';
  paradaDeMaquina: string = 'Parada de máquina';
  touchPanel: string = 'Touch Panel';
  sugestoes: string = 'Sugestões e reclamações';
  modificacaoDeRelatorio: string = 'Modificação de relatório';
  novoRelatorio: string = 'Novo relatório';


  arrayArea: string[] = [];

  constructor() {
  }

  ngOnInit(): void {
    Chart.register(ChartDataLabels);
    this.atualizaGraficos();
  }

  atualizaGraficos() {

    this.arrayArea = this.porStatus ? [this.novo,this.atendimento, this.finalizado] : [this.duvida, this.erroEmRelatorio, this.paradaDeMaquina, this.touchPanel, this.sugestoes, this.modificacaoDeRelatorio, this.novoRelatorio];

    this.chartDoughnutDataHPDC = {
      //labels: this.getLabels(),
      datasets: [
        {
          backgroundColor: this.getColors(),
          data: this.getValores('HPDC'),
          datalabels: this.customDataLabels
        },
      ],
      //plugins: [ChartDataLabels],
    };

    this.chartDoughnutDataUsi = {
      //labels: this.getLabels(),
      datasets: [
        {
          backgroundColor: this.getColors(),
          data: this.getValores('Usinagem'),
          datalabels: this.customDataLabels
        },
      ],
    };

    this.chartDoughnutDataSPM = {
      //labels: this.getLabels(),
      datasets: [
        {
          backgroundColor: this.getColors(),
          data: this.getValores('SPM'),
          datalabels: this.customDataLabels
        },
      ],
    };

    this.chartDoughnutData = {
      //labels: this.getLabels(),
      datasets: [
        {
          backgroundColor: this.getColors(),
          data: this.getValores('Outras áreas'),
          datalabels: this.customDataLabels
        },
      ],
    };
  }

  customDataLabels = {
    anchor: 'center',
    color: 'white',
    font: {
      weight: 'bold',
      size: '20'
    }
  }

  alternarTipoStatus() {
    this.porStatus = !this.porStatus;
    this.porTipo = !this.porTipo;

    this.atualizaGraficos();
  }

  getValores(area: string) {

    if(!this.arrayArea)
      return;

    const valores: any[] = [];

    this.arrayArea.forEach((element) => {
      valores.push(this.getValorArea(area, element));
    });

    return valores;
  }

  getLabels() {
    return this.porStatus ? [this.novo,this.atendimento, this.finalizado] : [this.duvida, this.erroEmRelatorio, this.paradaDeMaquina, this.touchPanel, this.sugestoes, this.modificacaoDeRelatorio, this.novoRelatorio];
  }

  getColors() {
    return this.porStatus ? ['#39f', '#FBBC04','#2eb85c'] : ['#EA4335', '#FBBC04', '#FF6D01', '#8B4513' ,'#34A853', '#39f' , '#808080'];
  }

  getValorArea(nome: string, param: string) {

    if (this.porStatus) {

      if (!this.modelStatus)
        return;

      return this.modelStatus.situacoes.find((el: IncidentesAreaStatus) => el.area === nome && el.situacao === param)?.total ?? '';

    } else {
      if (!this.modelTipo)
      return;

      return this.modelTipo.tipos.find((el: IncidentesAreaTipo) => el.area === nome && el.chamadoTipo === param)?.total ?? '';
    }
  }
}
