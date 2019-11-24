import { Injectable } from '@angular/core';
import {
    IMqttMessage,
    MqttModule,
    IMqttServiceOptions,
    MqttService
  } from 'ngx-mqtt';
import { LobbyModule } from '../pages/lobby';

@Injectable()
export class MyMqttService {

  constructor() { }
 
  public ConnectLobby(){

    //this.mqttService.connect()
  }

}