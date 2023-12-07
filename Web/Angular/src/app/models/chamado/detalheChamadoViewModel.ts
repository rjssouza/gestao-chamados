export interface ResultDetalheChamadoViewModel {
  filtro: any;
  times: Time[];
  ehAdministrador: boolean;
  result: DetalheChamadoViewModel[];
}

export class DetalheChamadoViewModel {
  id: number;
  atendimento?: any;
  chamadoPai?: DetalheChamadoViewModel;
  classificacao?: Classificacao;
  chamadoTime?: Time;
  historico?: Historico[];
  idChamadoTime?: number;
  progressoChamadoViewModel?: ProgressoChamadoViewModel[];
  prioridade?: Prioridade;
  tag?: Tag[];
  tipo?: Tipo;
  maquina?: Maquina;
  anexos?: Anexo[];
  comentarios?: Comentario[];
  descricao?: string;
  dtAtendimento?: Date;
  dtFechamento?: Date;
  dtRecebimento?: Date;
  emAtendimento?: boolean;
  estahAtrasado?: boolean;
  estahPendente?: boolean;
  idChamadoClassificacao?: number;
  idChamadoPai?: number;
  idChamadoPrioridade?: number;
  idChamadoTipo?: number;
  idFormularioResposta?: number;
  idNorisMaquina?: number;
  percentualAtendimento?: number;
  status?: number;
  ultimaAtualizacao?: Date;
  usSolicitante?: string;
  usSolicitanteNomeCompleto?: string;
  usReg?: string;
  dtReg?: Date;
  novoComentario?: string;

  constructor(
    id?: number,
    atendimento?: string,
    chamadoPai?: DetalheChamadoViewModel,
    classificacao?: Classificacao,
    chamadoTime?: Time,
    anexos?: Anexo[],
    historico?: Historico[],
    prioridade?: Prioridade,
    tag?: Tag[],
    tipo?: Tipo,
    maquina?: Maquina,
    comentarios?: Comentario[],
    descricao?: string,
    dtAtendimento?: Date,
    dtFechamento?: Date,
    dtRecebimento?: Date,
    emAtendimento?: boolean,
    estahAtrasado?: boolean,
    estahPendente?: boolean,
    idChamadoClassificacao?: number,
    idChamadoPai?: number,
    idChamadoPrioridade?: number,
    idChamadoTipo?: number,
    idFormularioResposta?: number,
    idNorisMaquina?: number,
    percentualAtendimento?: number,
    status?: number,
    ultimaAtualizacao?: Date,
    usSolicitante?: string,
    usSolicitanteNomeCompleto?: string,
    usReg?: string,
    dtReg?: Date,
    novoComentario?: string,
    idChamadoTime?: number
  ) {
    this.id = id || 0;
    this.atendimento = atendimento;
    this.chamadoPai = chamadoPai;
    this.classificacao = classificacao;
    this.historico = historico;
    this.prioridade = prioridade;
    this.tag = tag;
    this.tipo = tipo;
    this.maquina = maquina;
    this.anexos = anexos;
    this.comentarios = comentarios;
    this.descricao = descricao;
    this.dtAtendimento = dtAtendimento;
    this.dtFechamento = dtFechamento;
    this.dtRecebimento = dtRecebimento;
    this.emAtendimento = emAtendimento;
    this.estahAtrasado = estahAtrasado;
    this.estahPendente = estahPendente;
    this.idChamadoClassificacao = idChamadoClassificacao;
    this.idChamadoPai = idChamadoPai;
    this.idChamadoPrioridade = idChamadoPrioridade;
    this.idChamadoTipo = idChamadoTipo;
    this.idFormularioResposta = idFormularioResposta;
    this.idNorisMaquina = idNorisMaquina;
    this.percentualAtendimento = percentualAtendimento;
    this.status = status;
    this.ultimaAtualizacao = ultimaAtualizacao;
    this.usSolicitante = usSolicitante;
    this.usSolicitanteNomeCompleto = usSolicitanteNomeCompleto;
    this.usReg = usReg;
    this.dtReg = dtReg;
    this.novoComentario = novoComentario || '';
    this.idChamadoTime = idChamadoTime;
    this.chamadoTime = chamadoTime;
  }
}

export interface ProgressoChamadoViewModel {
  comentario?: string;
  idChamado?: number;
  percentual?: number;
  usAtendente?: string;
}
export interface Anexo {
  id: number;
  anexo: string;
  nomeArquivo: string;
  tipoArquivo: string;
  icone: string;
  usAnexo: string;
}

export interface Classificacao {
  id: number;
  classificacao: string;
  idChamadoClassPai: any;
  idChamadoTime: any;
  time: Time;
  chamadoPai: any;
  idChamado: number;
  usReg: any;
  dtReg: any;
}

export interface Comentario {
  id: number;
  comentario: string;
  chamado: any;
  idChamado: number;
  usReg: string;
  dtReg: string;
  usComentario: string;
  ehAtualSolicitante: boolean;
}

export interface Historico {
  id: number;
  de: string;
  para: string;
  chamado: any;
  idChamado: number;
  usReg: string;
  dtReg: string;
  usHistorico: string;
}

export interface Prioridade {
  id: number;
  prioridade: number;
  slaAtendimentoHoras: number;
  slaRecebimentoHoras: number;
  ativo: boolean;
  usReg: string;
  dtReg: string;
}

export interface Tag {
  id: number;
  tag: string;
  usReg: any;
  dtReg: any;
  badge: string;
}

export interface Time {
  id: number;
  email: string;
  nomeDoTime: string;
  responsavel: string;
  usReg: any;
  dtReg: any;
}

export interface Tipo {
  id: number;
  chamadoTipo: any;
  ordem: number;
  usPrimeiroCombate: string;
  cor: string;
  ativo: boolean;
  idChamadoClassificacao: number;
  chamadoClassificacao: any;
  usReg: any;
  dtReg: any;
}

export interface Maquina {
  id: number;
  bezeichnung: string;
  liniennummer: number;
}
