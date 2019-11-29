import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Player } from '../../models/Player';
import { Observable, BehaviorSubject, Subscription } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { JoinGameDialogComponent } from '../join-game-dialog/join-game-dialog.component';
import { LobbyService } from 'src/app/services/lobby.service';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss'],
  providers: [LobbyService]
})
export class GameCardComponent implements OnInit, OnDestroy {

  @Input() gameCode: string;

  public players: Observable<Player[]>;
  public player = new BehaviorSubject<Player>(null);

  private _playerReadySubscription: Subscription;

  constructor(
    public dialog: MatDialog,
    private lobbyService: LobbyService) { }

  ngOnInit() {
    this.players = this.lobbyService.getGamePlayers(this.gameCode);
    this._playerReadySubscription = this.lobbyService.getCurrentPlayer(this.gameCode)
      .subscribe({ next: (player) => this.player.next(player) });
  }

  ngOnDestroy() {
    this._playerReadySubscription.unsubscribe();
  }

  openJoinGameDialog(): void {
    const dialogRef = this.dialog.open(JoinGameDialogComponent, {
      width: '250px',
      data: { gameCode: this.gameCode }
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  readyClick(): void {
    this.lobbyService.playerReady(!this.player.value.IsReady);
  }

}