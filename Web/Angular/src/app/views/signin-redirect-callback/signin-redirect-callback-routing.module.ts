import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SigninRedirectCallbackComponent } from './signin-redirect-callback.component';

const routes: Routes = [
  {
    path: '',
    component: SigninRedirectCallbackComponent,
    data: {
      title: $localize`Sign Callback`
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SigninRedirectRoutingModule {
}
