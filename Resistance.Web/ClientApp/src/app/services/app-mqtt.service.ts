import { Injectable } from '@angular/core';
import { IMqttMessage, MqttService, IOnErrorEvent, IMqttServiceOptions } from 'ngx-mqtt';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { decode } from '@msgpack/msgpack';

const MQTT_SERVICE_OPTIONS: IMqttServiceOptions = {
  hostname: "localhost",
  port: 5000,
  path: '/mqtt',
  protocol: "ws",
  username: "resistance",
};

@Injectable({providedIn: 'root'})
export class AppMqttService {

  constructor(
    private mqtt: MqttService) {
      this.mqtt.onError.subscribe({
        next: (error: IOnErrorEvent) => {
          if (error.type === "ERR_CONNECTION_REFUSED"){
            this.reconnect(null);
          }
        }
      })
  }
 
  public reconnect(token: string)
  {
    const options = MQTT_SERVICE_OPTIONS;
    options.password = token;
    this.mqtt.disconnect();
    this.mqtt.connect(options);
  }

  public observe(topic: string): Observable<unknown> {
    return this.mqtt.observeRetained(topic)
      .pipe(
        //tap((message: IMqttMessage) => console.log(`MQTT message received on topic '${message.topic}'`)),
        tap(o => console.log(o.payload.toString())),
        map((message: IMqttMessage) => JSON.parse(message.payload.toString())),
        //tap((object: unknown) => console.log(object))
      );
  }

  public publish(topic: string, payload: any): Observable<void> {
    return this.mqtt.publish(topic, JSON.stringify(payload), { qos: 2 });
  }
}