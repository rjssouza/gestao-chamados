import { AuthConfig } from 'angular-oauth2-oidc';
import { environment } from '../../environments/environment';

export const authConfig: AuthConfig = {
  issuer: environment.identityServerUrl,
  clientId: 'angularUI',
  postLogoutRedirectUri: 'https://localhost:444/',
  redirectUri:
    `${window.location.origin}${environment.basePathSite}` + '/dashboard',
  scope: 'openid profile email ChamadosApi.full_access',
  oidc: true,
};
