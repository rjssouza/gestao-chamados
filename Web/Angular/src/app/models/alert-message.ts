import { AlertType } from './enum/alert-type.enum'

export class AlertMessage {
  alertType: AlertType = AlertType.Alert;
  message!: string;

  constructor(messageType: AlertType, message: string) {
    this.setMessageType(messageType);
    this.setMessage(message);
  }

  getMessage(): string{
    return this.message;
  }

  setMessage(message: string){
    this.message = message;
  }

  setMessageType(alertType: AlertType){
    this.alertType = alertType;
  }

  getAlertType(): AlertType{
    return this.alertType;
  }
}
