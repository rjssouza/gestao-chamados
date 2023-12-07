import { QuestaoBase } from '../questao/questao-base';

export class OpcaoControleBase<T> {
    value: T|undefined;
    id: number;
    key: string;
    label: string;
    required: boolean;
    order: number;
    controlType: string;
    type: string;
    texto: string;
    idQuestao: number;
    dropDownOptions: {key: string, value: string}[];
    proximaQuestao: QuestaoBase | null;

    constructor(options: {
        value?: T;
        id?: number;
        key?: string;
        label?: string;
        required?: boolean;
        order?: number;
        controlType?: string;
        type?: string;
        texto?: string;
        idQuestao?: number;
        dropDownOptions?: {key: string, value: string}[];
        proximaQuestao?: QuestaoBase | null;
      } = {}) {
      this.value = options.value;
      this.id = options.id || 0;
      this.key = options.key || '';
      this.label = options.label || '';
      this.required = !!options.required;
      this.order = options.order === undefined ? 1 : options.order;
      this.controlType = options.controlType || '';
      this.type = options.type || '';
      this.texto = options.texto || '';
      this.idQuestao = options.idQuestao || 0;
      this.dropDownOptions = options.dropDownOptions || [];
      this.proximaQuestao = options.proximaQuestao || null;
    }
  }