import { Injectable } from '@angular/core';
import { authConfig } from '../core/auth-config';
import { OAuthService } from 'angular-oauth2-oidc';
import { UserManager, User, UserManagerSettings } from 'oidc-client';
import { Subject } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SecureService {
  private get idpSettings(): UserManagerSettings {
    return {
      authority: authConfig.issuer,
      client_id: authConfig.clientId,
      redirect_uri: `${window.location.origin}${environment.basePathSite}/#/signin-callback`,
      scope: 'openid profile email ChamadosApi.full_access PedidosApi.full_access',
      response_type: 'code',
      post_logout_redirect_uri: `${window.location.origin}${environment.basePathSite}`,
    };
  }

  private _userManager: UserManager;
  private _user: User | null;
  private _loginChangedSubject = new Subject<boolean>();

  constructor(private oauthService: OAuthService) {
    this._userManager = new UserManager(this.idpSettings);
    this._user = null;
  }

  public loginChanged = this._loginChangedSubject.asObservable();

  public removeLastUrl = (): any => {
    localStorage.removeItem("lastUrl");
  };
  
  public saveCurrentUrl = (): any => {
    var currentUrl = window.location.hash;
    if(currentUrl == '#/dashboard'){
      return;
    }
    localStorage.setItem("lastUrl", currentUrl);
  };

  public getLastUrlOrDefault = (): any => {
    var lastUrl = localStorage.getItem("lastUrl");
    return lastUrl ?? "/";
  };

  public getAccessToken = (): Promise<string | null> => {
    return this._userManager.getUser().then((user) => {
      return !!user && !user.expired ? user.access_token : null;
    });
  };

  public getUserName = (): Promise<string | null> => {
    return this._userManager.getUser().then((user) => {
      return !!user && !user.expired ? user.profile['username'] : null;
    });
  };

  public getUserPhotoUrl = (): Promise<string | null> => {
    return this._userManager.getUser().then((user) => {
      var valid = !!user && !user.expired;
      if (!valid) return null;

      return `${authConfig.issuer}/auth/api/photo/${user?.profile['username']}`;
    });
  };

  public isAuthenticated = (): Promise<boolean> => {
    return this._userManager.getUser().then((user) => {
      if (this._user !== user) {
        this._loginChangedSubject.next(this.checkUser(user));
      }

      this._user = user;

      return this.checkUser(user);
    });
  };

  private checkUser = (user: User | null): boolean => {
    return !!user && !user.expired;
  };

  public finishLogin = (): Promise<User> => {
    return this._userManager.signinRedirectCallback().then((user) => {
      this._user = user;
      this._loginChangedSubject.next(this.checkUser(user));
      return user;
    });
  };

  public login = () => {
    return this._userManager.signinRedirect();
  };

  public logout = () => {
    this._userManager.signoutRedirect();
  };

  public finishLogout = () => {
    this._user = null;
    return this._userManager.signoutRedirectCallback();
  };
}
