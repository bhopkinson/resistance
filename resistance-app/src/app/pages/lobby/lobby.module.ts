import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LobbyPageComponent } from './lobby-page/lobby-page.component';
import { GameCardComponent } from './game-card/game-card.component';
import { AppMaterialModule } from 'src/app/app-material.module';
import { PlayerChipComponent } from 'src/app/components/player-chip/player-chip.component';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule
  ],
  declarations: [
    LobbyPageComponent,
    GameCardComponent,
    PlayerChipComponent
  ]
})
export class LobbyModule { }
