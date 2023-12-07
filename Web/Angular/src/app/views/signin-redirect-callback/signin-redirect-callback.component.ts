import { Component, OnInit } from '@angular/core';
import { SecureService } from '../../services/security.service';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-signin-redirect-callback',
  template: `<div></div>`
})
export class SigninRedirectCallbackComponent implements OnInit {

  constructor(private _authService: SecureService, 
    private _router: Router) { }

  ngOnInit(): void {
    this._authService.finishLogin()
    .then(_ => {
      var url = this._authService.getLastUrlOrDefault();
      this._authService.removeLastUrl();
      if(url != '/'){
        window.location.href = `${environment.basePathSite}/${url}`;
      }else{
        this._router.navigate([url], { replaceUrl: true });
      }
    }).catch((err) => {});
  }
}