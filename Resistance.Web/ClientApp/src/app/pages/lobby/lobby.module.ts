import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LobbyPageComponent } from './lobby-page/lobby-page.component';
import { GameCardComponent } from '../../components/game-card/game-card.component';
import { AppMaterialModule } from 'src/app/app-material.module';
import { PlayerChipComponent } from 'src/app/components/player-chip/player-chip.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AppRoutingModule } from '../../app-routing.module';
import { NewGameComponent } from './new-game/new-game.component';
import { JoinGameDialogComponent } from '../../components/join-game-dialog/join-game-dialog.component';
import { FormsModule } from '@angular/forms';
import { AppDirectivesModule } from '../../directives/app-directives.module';
import { MatSpinner } from '@angular/material';
import { AppPipesModule } from '../../pipes/app-pipes.module';
import { GameLobbyPageComponent } from './game-lobby-page/game-lobby-page.component';

@NgModule({
  imports: [
    CommonModule,
    AppDirectivesModule,
    AppMaterialModule,
    AppPipesModule,
    AppRoutingModule,
    FlexLayoutModule,
    FormsModule,
  ],
  declarations: [
    GameLobbyPageComponent,
    LobbyPageComponent,
    NewGameComponent,
    GameCardComponent,
    JoinGameDialogComponent,
    PlayerChipComponent,
  ],
  providers: [
  ],
  entryComponents: [
    JoinGameDialogComponent,
    MatSpinner
  ]
})
export class LobbyModule { }
