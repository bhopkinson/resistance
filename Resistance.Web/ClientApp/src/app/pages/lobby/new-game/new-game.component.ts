import { Component, OnInit } from '@angular/core';
import { LobbyService } from '../../../services/lobby.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-game',
  templateUrl: './new-game.component.html',
  styleUrls: ['./new-game.component.css'],
  providers: [LobbyService]
})
export class NewGameComponent implements OnInit {

  constructor(
    private lobbyService: LobbyService,
    private router: Router) { }

  ngOnInit() {
    this.lobbyService.createGame()
      .subscribe(code => {
        this.router.navigate(["/lobby", code]);
      });
  }

}
