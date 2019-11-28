import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Player } from '../../../models/Player';
import { LobbyService } from '../../../services/lobby.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-game-lobby-page',
  templateUrl: './game-lobby-page.component.html',
  styleUrls: ['./game-lobby-page.component.css'],
  providers: [LobbyService]
})
export class GameLobbyPageComponent implements OnInit {

  private gameCode: string;

  public players: Observable<Player[]>;

  constructor(
    private route: ActivatedRoute,
    private lobbyService: LobbyService) { }

  ngOnInit() {
    this.route.params
      .subscribe({
        next: params => {
        this.gameCode = params.code;
      }});

      console.log("gamecode: "+ this.gameCode);

    this.players = this.lobbyService.getGamePlayers(this.gameCode);
  }

}
