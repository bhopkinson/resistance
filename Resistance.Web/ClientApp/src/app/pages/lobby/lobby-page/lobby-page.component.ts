import { Component, OnInit } from '@angular/core';
import { LobbyService } from '../../../services/lobby.service';
import { Observable } from 'rxjs';
import { Lobby } from '../../../models/Lobby';

@Component({
  selector: 'app-lobby-page',
  templateUrl: './lobby-page.component.html',
  styleUrls: ['./lobby-page.component.scss'],
  providers: [LobbyService]
})
export class LobbyPageComponent implements OnInit {

  public lobbyData: Observable<Lobby>;

  constructor(lobbyService: LobbyService) {
    this.lobbyData = lobbyService.lobbyData;
  }

  ngOnInit() {
  }

}
