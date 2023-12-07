import { FiltroBaseViewModel } from '../filtros/filtro-base';
import { ListarChamadoViewModel } from '../listar/listar-chamado';

export class DashboardViewModel {
  ehAdmin: boolean;
  constructor() {
    this.ehAdmin = false;
  }
}
