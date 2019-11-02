import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GameService } from './game.service';
import { RoomComponent } from './player/room/room.component';
import { JoinGameComponent } from './player/join-game/join-game.component';
import { AssignRolesComponent } from './player/assign-roles/assign-roles.component';
import { TeamPickComponent } from './player/team-pick/team-pick.component';
import { TeamApprovalComponent } from './player/team-approval/team-approval.component';
import { MissionComponent } from './player/mission/mission.component';
import { AccusationComponent } from './player/accusation/accusation.component';
import { InvestigationComponent } from './player/investigation/investigation.component';
import { GameOverComponent } from './player/game-over/game-over.component';
import { TvRoomComponent } from './tv/tv-room/tv-room.component';
import { TvAssignRolesComponent } from './tv/tv-assign-roles/tv-assign-roles.component';
import { TvTeamPickComponent } from './tv/tv-team-pick/tv-team-pick.component';
import { TvTeamApprovalComponent } from './tv/tv-team-approval/tv-team-approval.component';
import { TvMissionComponent } from './tv/tv-mission/tv-mission.component';
import { HuntingComponent } from './tv/hunting/hunting.component';
import { TvInvestigationComponent } from './tv/tv-investigation/tv-investigation.component';
import { TvGameOverComponent } from './tv/tv-game-over/tv-game-over.component';
import { GameBoardComponent } from './shared/game-board/game-board.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RoomComponent,
    JoinGameComponent,
    AssignRolesComponent,
    TeamPickComponent,
    TeamApprovalComponent,
    MissionComponent,
    AccusationComponent,
    InvestigationComponent,
    GameOverComponent,
    TvRoomComponent,
    TvAssignRolesComponent,
    TvTeamPickComponent,
    TvTeamApprovalComponent,
    TvMissionComponent,
    HuntingComponent,
    TvInvestigationComponent,
    TvGameOverComponent,
    GameBoardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'player/room', component: RoomComponent, pathMatch: 'full'},
      { path: 'player/join-game', component: JoinGameComponent, pathMatch: 'full'},
      { path: 'player/assign-roles', component: AssignRolesComponent, pathMatch: 'full'},
      { path: 'player/team-pick', component: TeamPickComponent, pathMatch: 'full'},
      { path: 'player/team-approval', component: TeamApprovalComponent, pathMatch: 'full'},
      { path: 'player/mission', component: MissionComponent, pathMatch: 'full'},
      { path: 'player/accusation', component: AccusationComponent, pathMatch: 'full'},
      { path: 'player/investigation', component: InvestigationComponent, pathMatch: 'full'},
      { path: 'player/game-over', component: GameOverComponent, pathMatch: 'full'},
      { path: 'tv/room', component: TvRoomComponent, pathMatch: 'full'},
      { path: 'tv/assign-roles', component: TvAssignRolesComponent, pathMatch: 'full'},
      { path: 'tv/team-pick', component: TvTeamPickComponent, pathMatch: 'full'},
      { path: 'tv/team-approval', component: TvTeamApprovalComponent, pathMatch: 'full'},
      { path: 'tv/mission', component: TvMissionComponent, pathMatch: 'full'},
      { path: 'tv/hunting', component: HuntingComponent, pathMatch: 'full'},
      { path: 'tv/investigation', component: TvInvestigationComponent, pathMatch: 'full'},
      { path: 'tv/game-over', component: TvGameOverComponent, pathMatch: 'full'},
    ])
  ],
  providers: [GameService],
  bootstrap: [AppComponent]
})
export class AppModule { }
