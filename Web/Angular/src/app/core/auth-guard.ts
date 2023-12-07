import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';
import { SecureService } from '../services/security.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(
    private oauthService: OAuthService,
    private router: Router,
    private secureService: SecureService
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    return true;
    // if( this.oauthService.hasValidAccessToken()){
    //   return true;
    // }

    // this.router.navigate(['']);
    // return false;
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
