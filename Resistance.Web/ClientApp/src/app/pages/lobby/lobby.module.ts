import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LobbyPageComponent } from './lobby-page/lobby-page.component';
import { GameCardComponent } from '../../components/game-card/game-card.component';
import { AppMaterialModule } from 'src/app/app-material.module';
import { PlayerChipComponent } from 'src/app/components/player-chip/player-chip.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MqttService } from 'ngx-mqtt';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    FlexLayoutModule,
  ],
  declarations: [
    LobbyPageComponent,
    GameCardComponent,
    PlayerChipComponent
  ],
  providers: [
    MqttService
  ]
})
export class LobbyModule { }
