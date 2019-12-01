import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppMaterialModule } from './app-material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LobbyModule } from './pages/lobby';
import { MqttModule, IMqttServiceOptions } from 'ngx-mqtt';
import { HttpClientModule } from '@angular/common/http';
import { GameModule } from './pages/game';
import { StorageModule } from '@ngx-pwa/local-storage';

const MQTT_SERVICE_OPTIONS: IMqttServiceOptions = {
  hostname: "localhost",
  port: 5000,
  path: '/mqtt',
  protocol: "ws",
  username: "resistance",
};

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppMaterialModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LobbyModule,
    GameModule,
    HttpClientModule,
    MqttModule.forRoot(MQTT_SERVICE_OPTIONS),
    StorageModule.forRoot({ IDBNoWrap: true }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
