import { Component, OnInit } from '@angular/core';
import { LobbyService } from '../../../services/lobby.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { Lobby } from '../../../models/Lobby';
import { Utils } from '../../../utils';

@Component({
  selector: 'app-lobby-page',
  templateUrl: './lobby-page.component.html',
  styleUrls: ['./lobby-page.component.scss'],
  providers: [LobbyService]
})
export class LobbyPageComponent implements OnInit {

  public lobbyData: BehaviorSubject<Lobby>;
  
  public shouldShowNoGamesMessage() {
    return this.lobbyData.value.games.length > 0;
  }

  constructor(lobbyService: LobbyService) {
    this.lobbyData = Utils.convertObservableToBehaviorSubject(lobbyService.lobbyData, null);
  }

  ngOnInit() {
  }

}
