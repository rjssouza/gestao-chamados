import { AnexoChamadoArquivoViewModel } from '../anexo/anexoChamadoViewModel';
import { FormularioRespostaOpcao } from './formulario-resposta-opcao';

export class FormularioResposta {
  idFormulario: number;
  respostas: FormularioRespostaOpcao[] = [];
  anexos: AnexoChamadoArquivoViewModel[] = [];

  constructor(
    options: {
      idFormulario?: number;
    } = {}
  ) {
    this.idFormulario = options.idFormulario || 0;
  }
}
