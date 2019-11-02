import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/game.service';
import { Mission } from 'src/app/models/Mission';
import { MissionState } from 'src/app/models/MissionState';

@Component({
  selector: 'app-game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.scss']
})
export class GameBoardComponent implements OnInit {

  constructor(private gameService: GameService) { }

  voteCount = 1;
  missions: Mission[] = [];
  MissionState = MissionState;

  ngOnInit() {
    this.registerGameBoardChangeListener();
  }

  registerGameBoardChangeListener(): void {
    this.gameService.gameBoard$.subscribe((gameBoard) => {
      this.missions = gameBoard.Missions;
      this.voteCount = gameBoard.VoteCount
    })
    // TODO remove fake stuff when done
    this.voteCount = this.fakeVoteCount;
    this.missions = this.fameMissions;
  }

  getShowMissionSize(mission: Mission): boolean {
    return mission.state === MissionState.Current
      || mission.state === MissionState.Future;
  }

  fakeVoteCount = 3;
  fameMissions: Mission[] = [
    {state: MissionState.Pass, missionNo: 1, failsRequired: 1, numberOfPlayers: 3},
    {state: MissionState.Fail, missionNo: 2, failsRequired: 1, numberOfPlayers: 4},
    {state: MissionState.Current, missionNo: 3, failsRequired: 1, numberOfPlayers: 4},
    {state: MissionState.Future, missionNo: 4, failsRequired: 2, numberOfPlayers: 5},
    {state: MissionState.Future, missionNo: 5, failsRequired: 1, numberOfPlayers: 5},
  ]


}
