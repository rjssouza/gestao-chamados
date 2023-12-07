import { OpcaoControleBase } from '../opcao/opcao-base';

export class QuestaoBase {
    id: number;
    titulo: string;
    textoComplementar: string;
    opcoes: OpcaoControleBase<string>[];
    ehUltimo: boolean;
    idFormulario: number;

    constructor(options: {
        id?: number;
        titulo?: string;
        textoComplementar?: string;
        opcoes?: OpcaoControleBase<string>[];
        ehUltimo?: boolean;
        idFormulario?: number;
      } = {}) {
        this.id = 0;
        this.titulo = "";
        this.textoComplementar = "";
        this.ehUltimo = false;
        this.idFormulario = options.idFormulario || 0;
        this.opcoes = [];
    }
  }