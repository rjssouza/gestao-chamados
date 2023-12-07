import { FiltroAreaViewModel } from "../filtros/filtro-area";
import { ListarChamadoAreaViewModel, Status, Tag, Time, Linha, Maquina, Usuario } from './listar-chamado-area';

export class ListarChamadosAreaViewModel {
  filtro?: FiltroAreaViewModel | null;
  chamados?: ListarChamadoAreaViewModel[] | null;
  status?: Status[] | null;
  tags?: Tag[] | null;
  times?: Time[] | null;
  linhas?: Linha[] | null;
  maquinas?: Maquina[] | null;
  usuarios?: Usuario[] | null;
  //incidentesAreas?: IncidentesArea[] | null;
  total?: number | null;

  constructor(options: {
    filtro?: FiltroAreaViewModel;
    chamados?: ListarChamadoAreaViewModel[];
    status?: Status[];
    tags?: Tag[];
    times?: Time[];
    linhas?: Linha[];
    maquinas?: Maquina[];
    usuarios?: Usuario[];
    total?: number;
  } = {}) {
    this.filtro = options.filtro;
    this.chamados = options.chamados;
    this.status = options.status;
    this.tags = options.tags;
    this.times = options.times;
    this.linhas = options.linhas;
    this.maquinas = options.maquinas;
    this.usuarios = options.usuarios;
    this.total = options.total;
  }
}
