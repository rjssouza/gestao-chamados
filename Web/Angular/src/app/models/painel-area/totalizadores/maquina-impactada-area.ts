export class MaquinaImpactadaViewModel {
  area?: string | null;
  nomeMaquina?: string | null;
  quantidadeChamados?: number | null;

  constructor() {
    this.area = '';
    this.nomeMaquina = '';
    this.quantidadeChamados = 0;
  }
}
