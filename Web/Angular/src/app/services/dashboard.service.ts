import { Injectable } from '@angular/core';
import {
  HttpClient
} from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, from } from 'rxjs';
import { FiltroBaseViewModel } from '../models/filtros/filtro-base';
import { ListarChamadosViewModel } from '../models/listar/listar-chamados';
import { ApiService } from './api.service'
import { DashboardViewModel } from '../models/dashboard/dashboard'
import { Evolutivo } from '../models/dashboard/evolutivo/evolutivo'
import { IncidentesPorArea } from '../models/dashboard/incidentes/incidentes-por-area'
import { IncidentesPorAreaStatus } from '../models/dashboard/incidentes/incidentes-por-area-status'
import { IncidentesPorAreaTipo } from '../models/dashboard/incidentes/incidentes-por-area-tipo'
import { Totalizador } from '../models/dashboard/totalizadores/totalizador'

@Injectable({
  providedIn: 'root',
})
export class DashboardService extends ApiService {
  constructor(http: HttpClient) {
    super(http);
  }

  obterDashboardViewModel(): Observable<DashboardViewModel> {
    var result = this.http.get<DashboardViewModel>(
      this.createCompleteRoute(
        `api/dashboard`,
        environment.baseUrl
      )
    );

    return result;
  }  

  listarChamados(
    filtro: FiltroBaseViewModel
  ): Observable<ListarChamadosViewModel> {
    var result = this.http.get<ListarChamadosViewModel>(
      this.createCompleteRoute(
        `api/dashboard/chamados/${filtro?.skip}/${filtro?.take}`,
        environment.baseUrl
      )
    );

    return result;
  }

  obterEvolutivo(): Observable<Evolutivo> {
    var result = this.http.get<Evolutivo>(
      this.createCompleteRoute(
        `api/dashboard/evolutivo`,
        environment.baseUrl
      )
    );

    return result;
  }   
  
  obterIncidentes(): Observable<IncidentesPorArea> {
    var result = this.http.get<IncidentesPorArea>(
      this.createCompleteRoute(
        `api/dashboard/incidentes`,
        environment.baseUrl
      )
    );

    return result;
  }     

  obterIncidentesPorAreaStatus(): Observable<IncidentesPorAreaStatus> {
    var result = this.http.get<IncidentesPorAreaStatus>(
      this.createCompleteRoute(
        `api/dashboard/incidentesPorAreaStatus`,
        environment.baseUrl
      )
    );

    return result;
  }     

  obterIncidentesPorAreaTipo(): Observable<IncidentesPorAreaTipo> {
    var result = this.http.get<IncidentesPorAreaTipo>(
      this.createCompleteRoute(
        `api/dashboard/incidentesPorAreaTipo`,
        environment.baseUrl
      )
    );

    return result;
  }     

  obterTotalizadores(): Observable<Totalizador> {
    var result = this.http.get<Totalizador>(
      this.createCompleteRoute(
        `api/dashboard/totalizadores`,
        environment.baseUrl
      )
    );

    return result;
  }       
}
