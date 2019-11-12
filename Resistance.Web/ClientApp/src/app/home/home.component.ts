import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { GameService } from '../game.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    constructor(
        private gameService: GameService,
        private router: Router) { }

    createGame() {
        this.gameService.CreateGame();
    }

  goToTvPage(){
    this.router.navigateByUrl('/tv/room',{skipLocationChange: true});
  }

  goToPlayerPage(){
    this.router.navigateByUrl('/player/join-game',{skipLocationChange: true});
  }
}
