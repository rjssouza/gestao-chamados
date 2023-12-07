import { Component, OnInit } from '@angular/core';
import { AuthGuard } from 'src/app/core/auth-guard';
import { authConfig } from 'src/app/core/auth-config';
import { OAuthService } from 'angular-oauth2-oidc';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';

@Component({
  selector: 'app-navs',
  templateUrl: './navs.component.html',
  styleUrls: ['./navs.component.scss']
})
export class NavsComponent {

  constructor() { 
  }
}

