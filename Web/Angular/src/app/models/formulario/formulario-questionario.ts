import { QuestaoBase } from '../../views/dynamic-form/questao/questao-base';
import { OpcaoControleBase } from '../../views/dynamic-form/opcao/opcao-base';

export class FormularioQuestionario {
    area: string;
    primeiraQuestao: QuestaoBase;
    nome: string;
    idFormulario: number;

    constructor(options: {
        area?: string;
        primeiraQuestao?: QuestaoBase;
        nome?: string;
        idFormulario?: number;
      } = {}) {
        this.area = options.area || "";
        this.primeiraQuestao = options.primeiraQuestao || new QuestaoBase();
        this.nome = options.nome || "";
        this.idFormulario = options.idFormulario || 0;
    }
  }