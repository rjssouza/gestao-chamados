export class FormularioRespostaOpcao {
  idQuestao: number;
  idResposta: number;
  descricao?: string;

  constructor(
    options: {
      idQuestao?: number;
      idResposta?: number;
      descricao?: string;
    } = {}
  ) {
    this.idQuestao  = options.idQuestao  || 0;
    this.idResposta = options.idResposta || 0;
    this.descricao = options.descricao;
  }
}
