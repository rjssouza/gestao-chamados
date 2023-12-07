import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { FormularioResposta } from '../models/formulario/formulario-resposta';
import { AnexoChamadoViewModel } from '../models/anexo/anexoChamadoViewModel';
import { RegistrarProgressoChamadoViewModel } from '../models/chamado/registrarProgressoChamadoViewModel';
import { ResultProgressoChamadoViewModel } from '../models/chamado/resultProgressoChamadoViewModel';

import {
  DetalheChamadoViewModel,
  ResultDetalheChamadoViewModel,
} from '../models/chamado/detalheChamadoViewModel';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root',
})
export class ChamadoService extends ApiService {
  constructor(http: HttpClient) {
    super(http);
  }

  abrirChamado(resposta: FormularioResposta): Observable<number> {
    var result = this.http.post<number>(
      this.createCompleteRoute('api/chamado', environment.baseUrl),
      resposta
    );

    return result;
  }

  obterDetalheChamado(
    idChamado: number
  ): Observable<ResultDetalheChamadoViewModel> {
    var result = this.http.get<ResultDetalheChamadoViewModel>(
      this.createCompleteRoute(
        `api/chamado?idChamado=${idChamado}`,
        environment.baseUrl
      )
    );

    return result;
  }

  registrarProgresso(
    registrarProgressoChamadoViewModel: RegistrarProgressoChamadoViewModel
  ): Observable<ResultProgressoChamadoViewModel> {
    var result = this.http.post<ResultProgressoChamadoViewModel>(
      this.createCompleteRoute(
        `api/chamado/progresso`,
        environment.baseUrl
      ), registrarProgressoChamadoViewModel
    );

    return result;
  }

  salvarDetalheChamado(
    detalheChamado: DetalheChamadoViewModel
  ): Observable<ResultDetalheChamadoViewModel> {
    var result = this.http.put<ResultDetalheChamadoViewModel>(
      this.createCompleteRoute('api/chamado', environment.baseUrl),
      detalheChamado
    );
    return result;
  }

  adicionarComentario(
    idChamado: number,
    comentario: string
  ): Observable<ResultDetalheChamadoViewModel> {
    var result = this.http.post<ResultDetalheChamadoViewModel>(
      this.createCompleteRoute('api/chamado/comentario', environment.baseUrl),
      {
        idChamado: idChamado,
        comentario: comentario,
      }
    );
    return result;
  }

  fecharChamado(
    idChamado: number,
    atendimento: string
  ): Observable<ResultDetalheChamadoViewModel> {
    var result = this.http.post<ResultDetalheChamadoViewModel>(
      this.createCompleteRoute(
        `api/chamado/fechar?idChamado=${idChamado}&atendimento=${atendimento}`,
        environment.baseUrl
      ),
      null
    );

    return result;
  }

  iniciaratendimento(
    idChamado: number
  ): Observable<ResultDetalheChamadoViewModel> {
    var result = this.http.post<ResultDetalheChamadoViewModel>(
      this.createCompleteRoute(
        `api/chamado/iniciaratendimento?idChamado=${idChamado}`,
        environment.baseUrl
      ),
      null
    );

    return result;
  }

  mudarAtendente(
    idChamado: number,
    email: string
  ): Observable<ResultDetalheChamadoViewModel> {
    var result = this.http.post<ResultDetalheChamadoViewModel>(
      this.createCompleteRoute('api/chamado/atendente', environment.baseUrl),
      {
        idChamado: idChamado,
        usPrimeiroCombate: email,
      }
    );
    return result;
  }

  adicionarAnexo(
    anexos: AnexoChamadoViewModel
  ): Observable<ResultDetalheChamadoViewModel> {
    var result = this.http.post<ResultDetalheChamadoViewModel>(
      this.createCompleteRoute('api/chamado/anexo', environment.baseUrl),
      anexos
    );
    return result;
  }

  baixarAnexo(idAnexo: number): any {
    var result = this.http.get<Blob>(
      this.createCompleteRoute(
        `api/chamado/anexo?idAnexo=${idAnexo}`,
        environment.baseUrl
      ),
      {
        reportProgress: true,
        observe: 'events',
        responseType: 'blob' as 'json',
      }
    );
    return result;
  }

  removerAnexo(idAnexo: number): Observable<ResultDetalheChamadoViewModel> {
    var result = this.http.delete<ResultDetalheChamadoViewModel>(
      this.createCompleteRoute(
        `api/chamado/anexo?idAnexo=${idAnexo}`,
        environment.baseUrl
      )
    );
    return result;
  }
}
