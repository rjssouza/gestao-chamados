import { TotalPorcentagem } from '../total-porcentagem';
import { TotalizadorPlanta } from './incidentes-planta';
import { IncidentesMaquinaViewModel } from './incidentes-por-maquina';

export class IncidentesPorArea {
  hpdc: IncidentesMaquinaViewModel;
  coreshop: IncidentesMaquinaViewModel;
  spm: IncidentesMaquinaViewModel;
  totalizadorPlanta?: TotalizadorPlanta[] | null;
  usinagem: IncidentesMaquinaViewModel;
  comParagem: TotalPorcentagem;
  semParagem: TotalPorcentagem;

  constructor() {
    this.hpdc = new IncidentesMaquinaViewModel();
    this.coreshop = new IncidentesMaquinaViewModel();
    this.spm = new IncidentesMaquinaViewModel();
    this.usinagem = new IncidentesMaquinaViewModel();
    this.comParagem = new TotalPorcentagem();
    this.semParagem = new TotalPorcentagem();
  }
}
