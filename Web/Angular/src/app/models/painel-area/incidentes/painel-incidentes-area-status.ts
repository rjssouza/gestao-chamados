export class PainelIncidentesAreaStatus {
  area?: string | null;
  id?: number | null;
  situacao?: string | null;
  total?: number | null;

  constructor() {
    this.area = '';
    this.id = 0;
    this.situacao = '';
    this.total = 0;
  }
}
