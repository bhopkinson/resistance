import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LobbyPageComponent } from './lobby-page/lobby-page.component';
import { GameCardComponent } from '../../components/game-card/game-card.component';
import { AppMaterialModule } from 'src/app/app-material.module';
import { PlayerChipComponent } from 'src/app/components/player-chip/player-chip.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MqttService } from 'ngx-mqtt';
import { AppRoutingModule } from '../../app-routing.module';
import { NewGameComponent } from './new-game/new-game.component';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    AppRoutingModule,
    FlexLayoutModule,
  ],
  declarations: [
    LobbyPageComponent,
    NewGameComponent,
    GameCardComponent,
    PlayerChipComponent
  ],
  providers: [
    MqttService
  ]
})
export class LobbyModule { }
