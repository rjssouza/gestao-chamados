import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

import { IconSetService } from '@coreui/icons-angular';
import { iconSubset } from './icons/icon-subset';
import { Title } from '@angular/platform-browser';

import { OAuthService } from 'angular-oauth2-oidc';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
import { authConfig } from './core/auth-config';
import { SecureService } from './services/security.service';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit {
  title = 'Nemak | Innovative Lightweighting';
  public userAuthenticated = false;

  constructor(
    private router: Router,
    private titleService: Title,
    private oauthService: OAuthService,
    private iconSetService: IconSetService,
    private _authService: SecureService
  ) {
    titleService.setTitle(this.title);
    // iconSet singleton
    iconSetService.icons = { ...iconSubset };

    this._authService.loginChanged.subscribe((userAuthenticated) => {
      this.userAuthenticated = userAuthenticated;
    });
  }

  ngOnInit(): void {
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
    });

    this._authService.isAuthenticated().then((userAuthenticated) => {
      this.userAuthenticated = userAuthenticated;
    });
  }

  private configure() {
    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }

  public login() {
    this.oauthService.initLoginFlow();
  }

  public isLogged() {
    return this.oauthService.hasValidAccessToken();
  }

  public logoff() {
    this.oauthService.logOut();
  }
}
