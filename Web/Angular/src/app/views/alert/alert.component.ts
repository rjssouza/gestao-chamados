import { Component, OnInit, Input } from '@angular/core';
import { AlertMessage } from '../../models/alert-message';
import { AlertMessageModule } from '../../core/alert-message.module';
import { AlertType } from "../../models/enum/alert-type.enum";

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html'
})
export class AlertComponent implements OnInit {
  messageTimeLimit: number = 5000;
  enum: typeof AlertType = AlertType;

  constructor(private alertMessageService: AlertMessageModule) { 
  }

  model!: AlertMessage | null;

  ngOnInit() {
    this.alertMessageService.getMessage().subscribe((alertMessage: any) => {
      this.model = alertMessage;
      setTimeout(() => {
        this.clearMessage();
      }, this.messageTimeLimit);
    })
  }

  clearMessage(){
    this.model = null;
  }
}
