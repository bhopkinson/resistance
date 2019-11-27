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
import { JoinGameDialogComponent } from './components/join-game-dialog/join-game-dialog.component';
import { FormsModule } from '@angular/forms';

export const MQTT_SERVICE_OPTIONS: IMqttServiceOptions = {
  hostname: 'localhost',
  port: 5000,
  path: '/mqtt',
  connectOnCreate: false
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
    MqttModule.forRoot(MQTT_SERVICE_OPTIONS)
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
