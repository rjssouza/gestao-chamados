import { Component } from '@angular/core';
import { UserManager, UserManagerSettings, User } from 'oidc-client';
import { environment } from '../../../../environments/environment';

import { OAuthService } from 'angular-oauth2-oidc';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
import { authConfig } from '../../../core/auth-config';
import { SecureService } from '../../../services/security.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  model: any = {};

  constructor(private secureService: SecureService,
    private _authService: SecureService) {}

  login() {
    this._authService.login();

    console.log(this.model);
  }
}
