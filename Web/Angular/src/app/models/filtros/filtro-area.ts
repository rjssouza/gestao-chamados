export class FiltroAreaViewModel {
  dataFinal?: string | null;
  dataInicial?: string | null;
  ehColaborador?: boolean | null;
  area?: string | null;
  skip?: number | null;
  take?: number | null;
  usuarioAtual?: string | null;

  constructor(options: {
    dataFinal?: string;
    dataInicial?: string;
    ehColaborador?: boolean;
    area?: string;
    skip?: number;
    take?: number;
    usuarioAtual?: string
  } = {}) {
    this.dataFinal = options.dataFinal || '';
    this.dataInicial = options.dataInicial || '';
    this.ehColaborador = options.ehColaborador || false;
    this.area = options.area || '';
    this.skip = options.skip || 0;
    this.take = options.take || 0;
    this.usuarioAtual = options.usuarioAtual || '';
  }
}
