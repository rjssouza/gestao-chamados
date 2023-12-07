export class FiltroBaseViewModel {
  skip?: number | null;
  take?: number | null;
  dataInicial?: Date | null;
  dataFinal?: Date | null;

  constructor(
    options: {
      skip?: number;
      take?: number;
      dataInicial?: Date;
      dataFinal?: Date;
    } = {}
  ) {
    this.skip = options.skip;
    this.take = options.take;
    this.dataInicial = options.dataInicial;
    this.dataFinal = options.dataFinal;
  }
}
