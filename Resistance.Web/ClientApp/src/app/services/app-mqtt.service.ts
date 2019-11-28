import { Injectable } from '@angular/core';
import {
    IMqttMessage,
    MqttService
  } from 'ngx-mqtt';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { decode } from '@msgpack/msgpack';

@Injectable({providedIn: 'root'})
export class AppMqttService {

  constructor(
    private mqtt: MqttService
  ) { }
 
  public observe(topic: string): Observable<unknown> {
    return this.mqtt.observe(topic)
      .pipe(
        tap((message: IMqttMessage) => console.log(`MQTT message received on topic ${message.topic}`)),
        map((message: IMqttMessage) => decode(message.payload)),
        tap((object: unknown) => console.log(object))
      );
  }

}