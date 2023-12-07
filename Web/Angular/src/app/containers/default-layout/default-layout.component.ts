import { Component } from '@angular/core';
import { INavData } from '@coreui/angular';
import { SecureService } from 'src/app/services/security.service';

import { navItems } from './_nav';

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
})
export class DefaultLayoutComponent {

  public navItems: INavData[];

  public perfectScrollbarConfig = {
    suppressScrollX: true,
  };

  constructor(private _authService: SecureService) {
    // TODO implementar segurança para exibir menu aqui
    this.navItems = navItems;
  }
}
