import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { ClassToggleService, HeaderComponent } from '@coreui/angular';
import { SecureService } from 'src/app/services/security.service';

@Component({
  selector: 'app-default-header',
  templateUrl: './default-header.component.html',
})
export class DefaultHeaderComponent extends HeaderComponent implements OnInit {
  @Input() sidebarId: string = 'sidebar';

  public newMessages = new Array(4);
  public newTasks = new Array(5);
  public newNotifications = new Array(5);
  public isUserAuthenticated: boolean = false;
  public imageUrl!: string | null; 

  constructor(
    private classToggler: ClassToggleService,
    private _authService: SecureService
  ) {
    super();
  }
  
  ngOnInit(): void {
    this._authService.loginChanged.subscribe((res) => {
      this.isUserAuthenticated = res;

      this._authService.getUserPhotoUrl().then((result) => {
        this.imageUrl = result;
      });
    });
  }

  public logout() {
    this._authService.logout();
  }
}
