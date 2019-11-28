import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LobbyService } from 'src/app/services/lobby.service';
import { Router } from '@angular/router';

export interface JoinGameDialogData {
  gameCode: string;
}

@Component({
  selector: 'app-join-game-dialog',
  templateUrl: './join-game-dialog.component.html',
  styleUrls: ['./join-game-dialog.component.css'],
  providers: [LobbyService]
})
export class JoinGameDialogComponent {

  public name: string;
  public isJoining: boolean;

  constructor(
    private router: Router,
    private lobbyService: LobbyService,
    public dialogRef: MatDialogRef<JoinGameDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: JoinGameDialogData) { }

  onJoinClick(): void {
    this.isJoining = true;
    this.lobbyService.joinGame(this.data.gameCode, this.name)
    .subscribe(() => {
      this.isJoining = false;
      this.dialogRef.close();
    });
  }
}
