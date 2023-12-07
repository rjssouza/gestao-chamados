import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(protected http: HttpClient) {}

  protected createCompleteRoute = (route: string, envAddress: string) =>    {
    return `${envAddress}/${route}`;
  }
}
