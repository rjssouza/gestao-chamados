export class ListarChamadoAreaViewModel {
  area?: string | null;
  idChamado?: number | null;
  idTime?: number | null;
  idMaquina?: number | null;
  idLinha?: number | null;
  maquina?: string | null;
  registradoEm?: string | null;
  status?: string | null;
  responsavel?: string | null;
  usReg?: number | null;
  usSolicitanteNomeCompleto?: string | null;

  constructor(
    options: {
      area?: string;
      idChamado?: number;
      idTime?: number;
      idMaquina?: number;
      idLinha?: number;
      maquina?: string;
      registradoEm?: string;
      status?: string;
      responsavel?: string;
      usReg?: number;
      usSolicitanteNomeCompleto?: string;
    } = {}
  ) {
    this.area = options.area || '';
    this.idChamado = options.idChamado || 0;
    this.idTime = options.idTime || 0;
    this.idMaquina = options.idMaquina || 0;
    this.idLinha = options.idLinha || 0;
    this.maquina = options.maquina || '';
    this.registradoEm = options.registradoEm || '';
    this.status = options.status || '';
    this.responsavel = options.responsavel || '';
    this.usReg = options.usReg || 0;
    this.usSolicitanteNomeCompleto = options.usSolicitanteNomeCompleto || '';
  }
}

export interface Status {
  id: number;
  status: string;
}

export interface Tag {
  dtReg: string;
  usReg: string;
  badge: string;
  id: number;
  tag: string;
}

export interface Time {
  dtReg: string;
  usReg: string;
  email: string;
  id: number;
  nomeDoTime: string;
  responsavel: string;
}

export interface Linha {
  bezeichnung: string;
  id: number;
}

export interface Maquina {
  bezeichnung: string;
  id: number;
  liniennummer: number;
}

export interface Usuario {
  usReg: number;
  usSolicitante: string;
  usSolicitanteNomeCompleto: string;
  usEmailSolicitante: string;
}
