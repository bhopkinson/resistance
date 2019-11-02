import { Component, OnInit } from '@angular/core';
import { GameService } from '../../game.service';
import { timer } from 'rxjs';
import { takeWhile } from 'rxjs/operators';
import { PlayerDetails } from 'src/app/models/PlayerDetails';
import { Router } from '@angular/router';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.scss']
})
export class RoomComponent implements OnInit {

  constructor(private gameService: GameService, private router: Router) { }

  players: PlayerDetails[] = [];
  isPlayerReady = false;
  isCountdownVisible = false;
  countdownTime = 5;
  private minPlayerCount = 5;
  private maxPlayerCount = 11;

  ngOnInit(): void {
    this.registerCountdownListener();
    this.registerPlayerListListener();

    this.gameService.characterAssigned.subscribe(_ =>{
      this.router.navigateByUrl('/player/assign-roles');
    })
  }

  get playerCount(): number {
    if (!this.players){
      return 0;
    }
    return this.players.length;
  }

  get canStartGame(): boolean {
    return this.playerCount >= this.minPlayerCount;
  }

  sendPlayerReady(): void {
    this.isPlayerReady = !this.isPlayerReady;
    this.gameService.PlayerReady(this.isPlayerReady);
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
      .subscribe(_ => this.countdownTime--);

  }

  private stopCountdown(): void {
    this.isCountdownVisible = false;
  }
}
