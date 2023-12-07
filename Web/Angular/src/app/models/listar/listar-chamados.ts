import { FiltroBaseViewModel } from '../filtros/filtro-base';
import { ListarChamadoViewModel, Time, Tag, Status, Usuario } from '../listar/listar-chamado';

export class ListarChamadosViewModel {
  filtro?: FiltroBaseViewModel | null;
  result?: ListarChamadoViewModel[] | null;

  times?: Time[] | null;
  tags?: Tag[] | null;
  status?: Status[] | null;
  usuarios?: Usuario[] | null;

  constructor(
    options: {
      filtro?: FiltroBaseViewModel;
      result?: ListarChamadoViewModel[];
      times?: Time[];
      tags?: Tag[];
      status?: Status[];
      usuarios?: Usuario[];
    } = {}
  ) {
    this.filtro = options.filtro;
    this.result = options.result;
    this.times = options.times;
    this.tags = options.tags;
    this.status = options.status;
    this.usuarios = options.usuarios;
  }
}
