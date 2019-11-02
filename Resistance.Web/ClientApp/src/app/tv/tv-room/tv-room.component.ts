import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/game.service';
import { PlayerDetails } from 'src/app/models/PlayerDetails';
import { timer } from 'rxjs';
import { takeWhile } from 'rxjs/operators';

@Component({
  selector: 'app-tv-room',
  templateUrl: './tv-room.component.html',
  styleUrls: ['./tv-room.component.scss']
})
export class TvRoomComponent implements OnInit {

  constructor(private gameService: GameService) { }

  players: PlayerDetails[] = [];
  isPlayerReady = false;
  isCountdownVisible = false;
  countdownTime = 5;
  private minPlayerCount = 5;
  private maxPlayerCount = 11;

  ngOnInit(): void {
    this.gameService.CreateGame()
    this.registerCountdownListener();
    this.registerPlayerListListener();
  }

  get playerCount(): number {
    if (!this.players){
      return 0;
    }
    return this.players.length;
  }

  private registerCountdownListener(): void {
    this.gameService.countdown$.subscribe((isCountdownStarting) => {
      isCountdownStarting
        ? this.startCountdown()
        : this.stopCountdown();
    })
  }

  private registerPlayerListListener(): void {
    this.gameService.players$.subscribe((playersList) => {
      this.players = playersList;
    })
  }

  private startCountdown(): void {
    this.countdownTime = 5;
    this.isCountdownVisible = true;
    timer(1000,1000)
      .pipe(takeWhile(_ => this.countdownTime > 0 && this.isCountdownVisible))
      .subscribe(_ => {
        this.countdownTime--;
        console.log(this.countdownTime);
        if (this.countdownTime === 0) {
          this.gameService.StartGame();
        }
      });

  }

  private stopCountdown(): void {
    this.isCountdownVisible = false;
  }
}
