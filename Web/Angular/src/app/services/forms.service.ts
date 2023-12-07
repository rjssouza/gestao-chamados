import { Injectable } from '@angular/core';
import { FormularioQuestionario } from '../models/formulario/formulario-questionario';
import { ApiService } from './api.service'
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FormsService extends ApiService {
  constructor(http: HttpClient) {
    super(http);
  }

  obterFormulario() : Observable<FormularioQuestionario> {
    var result = this.http.get<FormularioQuestionario>(this.createCompleteRoute("api/formulario/1", environment.baseUrl));

    return result;
  }
}

