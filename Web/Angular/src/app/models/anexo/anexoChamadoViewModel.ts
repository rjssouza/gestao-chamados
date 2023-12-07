export class AnexoChamadoArquivoViewModel {
  anexo: string;
  nomeArquivo: string;
  tipoArquivo: string;
  constructor(anexo?: string, nomeArquivo?: string, tipoArquivo?: string) {
    this.anexo = anexo || '';
    this.nomeArquivo = nomeArquivo || '';
    this.tipoArquivo = tipoArquivo || '';
  }
}

export class AnexoChamadoViewModel {
  public idChamado: number;
  public anexoChamadoArquivoViewModel: AnexoChamadoArquivoViewModel[];

  constructor(idChamado?: number) {
    this.idChamado = idChamado || 0;
    this.anexoChamadoArquivoViewModel = [];
  }
}
