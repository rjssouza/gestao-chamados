import { EvolucaoMensal } from "./evolutivo/evolucao-mensal";

export class TotalPorcentagem {
    descricao: string;
    porcentagem: number;
    total: number;
    cor: string;
    valorMensal!: EvolucaoMensal[];

    constructor() {
      this.descricao = '';
      this.porcentagem = 0;
      this.total = 0;
      this.cor = '';
    }
  }
  