export class RegistrarProgressoChamadoViewModel {
  comentario?: string;
  idChamado?: number;
  percentual?: number;

  constructor(
    comentario?: string,
    idChamado?: number,
    percentual?: number,
 ){
    this.comentario = comentario;
    this.idChamado = idChamado;
    this.percentual = percentual;
  }
}
