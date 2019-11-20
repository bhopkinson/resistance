import { Injectable } from '@angular/core';
import {
    IMqttMessage,
    MqttModule,
    IMqttServiceOptions
  } from 'ngx-mqtt';

@Injectable()
export class MyMqttService {

constructor(private mqttService: MqttService) { }

}
