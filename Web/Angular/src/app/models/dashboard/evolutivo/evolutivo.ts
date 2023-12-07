import { TotalPorcentagem } from "../total-porcentagem";
import { EvolucaoTipoMensal } from "./evolucao-tipo-mensal";

export class Evolutivo {
    evolucaoMensal: (EvolucaoTipoMensal)[];
    totalizadores: (TotalPorcentagem)[];
    /**
     *
     */
    constructor() {
      this.evolucaoMensal = [];
      this.totalizadores = [];
    }
  }
