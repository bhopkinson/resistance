import { Component, OnInit, Input, HostBinding, OnDestroy } from '@angular/core';
import { Player } from '../../models/Player';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { JoinGameDialogComponent } from '../join-game-dialog/join-game-dialog.component';
import { LobbyService } from 'src/app/services/lobby.service';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss'],
  providers: [LobbyService]
})
export class GameCardComponent implements OnInit {

  @Input() gameCode: string;

  public players: Observable<Player[]>;

  constructor(
    public dialog: MatDialog,
    private lobbyService: LobbyService) { }

  ngOnInit() {
    this.players = this.lobbyService.getGamePlayers(this.gameCode);
  }

  openJoinGameDialog(): void {
    const dialogRef = this.dialog.open(JoinGameDialogComponent, {
      width: '250px',
      data: { gameCode: this.gameCode }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
      }
    });
  }

}