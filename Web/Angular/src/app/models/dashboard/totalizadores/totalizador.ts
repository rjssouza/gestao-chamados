import { TotalPorcentagem } from "../total-porcentagem";
import { TotalizadorDetalhes } from "./totalizador-detalhes";

export class Totalizador {
    chamadosAbertos: TotalizadorDetalhes;
    chamadosEmAtraso: TotalizadorDetalhes;
    chamadosEncerrados: TotalizadorDetalhes;
    chamadosPendentes: TotalizadorDetalhes;
    outrasAreas: TotalizadorDetalhes;

    constructor() {
      this.chamadosAbertos = new TotalizadorDetalhes();
      this.chamadosEmAtraso = new TotalizadorDetalhes();
      this.chamadosEncerrados = new TotalizadorDetalhes();
      this.chamadosPendentes = new TotalizadorDetalhes();
      this.outrasAreas = new TotalizadorDetalhes();
    }
  }
  