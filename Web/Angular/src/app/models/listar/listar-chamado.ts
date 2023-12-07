import { getTextOfJSDocComment } from 'typescript/lib/tsserverlibrary';

export class ListarChamadoViewModel {
  idChamado?: number | null;
  status?: string | null;
  registradoEm?: string | null;
  plantaNome?: string | null;
  planta?: string | null;
  percentualAtendimento: number;
  periodoBase?: string | null;
  ultimaAtividade?: string | null;
  avatar?: string | null;
  statusFlag?: string | null;
  statusCor?: string | null;
  usReg?: number | null;
  usSolicitante?: string | null;
  usSolicitanteNomeCompleto?: string | null;
  time?: string | null;
  idTime?: number | null;
  percentualAtendimentoAdicionar?: number | null;

  constructor(
    options: {
      idChamado?: number;
      status?: string;
      registradoEm?: string;
      plantaNome?: string;
      planta?: string;
      percentualAtendimento?: number;
      periodoBase?: string;
      ultimaAtividade?: string;
      avatar?: string;
      statusFlag?: string;
      statusCor?: string;
      usReg?: number;
      usSolicitante?: string;
      usSolicitanteNomeCompleto?: string;
      time?: string;
      idTime?: number;
    } = {}
  ) {
    this.idChamado = options.idChamado || 0;
    this.usReg = options.usReg || 0;
    this.usSolicitante = options.usSolicitante || '';
    this.usSolicitanteNomeCompleto = options.usSolicitanteNomeCompleto || '';
    this.status = options.status || '';
    this.registradoEm = options.registradoEm || '';
    this.plantaNome = options.plantaNome || '';
    this.planta = options.planta || '';
    this.percentualAtendimento = options.percentualAtendimento || 0;
    this.periodoBase = options.periodoBase || '';
    this.ultimaAtividade = options.ultimaAtividade || '';
    this.avatar = options.avatar || '';
    this.statusFlag = options.statusFlag || '';
    this.statusCor = options.statusCor || '';
    this.idTime = options.idTime || 0;
    this.time = options.time || '';
    this.percentualAtendimentoAdicionar = null;
  }
}

export interface Time {
  dtReg: string;
  usReg: string;
  email: string;
  id: number;
  nomeDoTime: string;
  responsavel: string;
}

export interface Tag {
  dtReg: string;
  usReg: string;
  badge: string;
  id: number;
  tag: string;
}

export interface Status {
  id: number;
  status: string;
}

export interface Usuario {
  usSolicitante: string;
  usSolicitanteNomeCompleto: string;
  usReg: number;
}
