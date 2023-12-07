import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { CardModule, GridModule } from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { SigninRedirectCallbackComponent } from '../signin-redirect-callback/signin-redirect-callback.component';
import { SigninRedirectRoutingModule } from '../signin-redirect-callback/signin-redirect-callback-routing.module';


@NgModule({
  imports: [
    SigninRedirectRoutingModule,
    CardModule,
    GridModule,
    IconModule,
    CommonModule,
  ],
  declarations: [
    SigninRedirectCallbackComponent
  ]
})
export class SigninRedirectCallbackModule {
}
