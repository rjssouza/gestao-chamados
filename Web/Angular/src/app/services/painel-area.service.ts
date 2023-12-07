import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { environment } from '../../environments/environment';

import { ApiService } from './api.service';
import { ListarChamadosAreaViewModel } from '../models/painel-area/listar-chamados-area';
import { PainelIncidentesAreaStatus } from '../models/painel-area/incidentes/painel-incidentes-area-status';
import { PainelSituacoesAreaStatus } from '../models/painel-area/incidentes/painel-situacoes-area-status';
import { MaquinasImpactadasAreaViewModel } from '../models/painel-area/totalizadores/maquinas-impactadas-area';

@Injectable({
  providedIn: 'root'
})
export class PainelAreaService extends ApiService {

  constructor(http: HttpClient) {
    super(http);
  }

  listarChamadosArea(): Observable<ListarChamadosAreaViewModel> {
    var result = this.http.get<ListarChamadosAreaViewModel>(
      this.createCompleteRoute(
        `chamados-area`,
        environment.baseUrl
      )
    );
    return result;
  }

  listarPainelSituacoesAreaStatus(): Observable<PainelSituacoesAreaStatus> {
    var result = this.http.get<PainelSituacoesAreaStatus>(
      this.createCompleteRoute(
        `chamados-area/incidentesPorAreaStatus`,
        environment.baseUrl
      )
    );
    return result;
  }

  listarMaquinasImpactadasArea(): Observable<MaquinasImpactadasAreaViewModel> {
    var result = this.http.get<MaquinasImpactadasAreaViewModel>(
      this.createCompleteRoute(
        `chamados-area/totalMaquinasImpactadas`,
        environment.baseUrl
      )
    );
    return result;
  }

}
