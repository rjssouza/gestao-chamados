import { EvolucaoMensal } from "../evolutivo/evolucao-mensal";
import {TotalPorcentagem } from "../total-porcentagem";

export class TotalizadorDetalhes {
    total: number;
    valorMensal!: EvolucaoMensal[];
    descricao: string;
    porcentagem: number;
    cor: string;
    arrow: string;
    encerrados: TotalPorcentagem;
    pendentes: TotalPorcentagem;
    emAtraso: TotalPorcentagem;
    
    constructor() {
      this.total = 0;
      this.descricao = "";
      this.porcentagem = 0;
      this.cor = "primary";
      this.arrow = "cilArrowTop";
      this.encerrados = new TotalPorcentagem();
      this.pendentes = new TotalPorcentagem();
      this.emAtraso = new TotalPorcentagem();
    }
  }
  