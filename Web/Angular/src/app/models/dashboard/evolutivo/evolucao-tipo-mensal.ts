import { EvolucaoMensal } from "./evolucao-mensal";

export class EvolucaoTipoMensal {
    descricao: string;
    evolutivoMensal: EvolucaoMensal[];
    cor: string;

    constructor() {
      this.descricao = '';
      this.cor = '';
      this.evolutivoMensal = [];
    }
  }
  