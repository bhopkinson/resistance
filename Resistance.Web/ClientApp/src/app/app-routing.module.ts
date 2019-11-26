import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LobbyPageComponent } from './pages/lobby/lobby-page/lobby-page.component';
import { NewGameComponent } from './pages/lobby/new-game/new-game.component';
import { GameLobbyPageComponent } from './pages/game/game-lobby-page/game-lobby-page.component';


const routes: Routes = [
  { path: '', redirectTo: 'lobby', pathMatch: 'full' },
  { path: 'lobby', component: LobbyPageComponent },
  { path: 'new', component: NewGameComponent },
  { path: 'game/:code', component: GameLobbyPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
