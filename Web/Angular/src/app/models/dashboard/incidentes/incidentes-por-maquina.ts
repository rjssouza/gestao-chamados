import { TotalizadorPlanta } from './incidentes-planta';

export class IncidentesMaquinaViewModel {
    total: number;
    totalizadorMaquina?: TotalizadorPlanta[];

    constructor() {
      this.total = 0;
      this.totalizadorMaquina = [];  
    }
  }
  