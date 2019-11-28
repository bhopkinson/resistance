import { Component } from '@angular/core';
import { LobbyService } from '../../../services/lobby.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-lobby-page',
  templateUrl: './lobby-page.component.html',
  styleUrls: ['./lobby-page.component.scss'],
  providers: [LobbyService]
})
export class LobbyPageComponent {

  public gameCodes: Observable<string[]>;

  constructor(
    private lobbyService: LobbyService) {
      this.gameCodes = this.lobbyService.getGameCodes();
    }
}
