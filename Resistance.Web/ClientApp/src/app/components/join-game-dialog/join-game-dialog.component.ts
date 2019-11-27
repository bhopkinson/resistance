import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LobbyService } from 'src/app/services/lobby.service';
import { MatProgressButtonOptions } from 'mat-progress-buttons';

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

  // Button Options
  joinBtnOptions: MatProgressButtonOptions = {
    active: false,
    text: 'Join',
    spinnerSize: 19,
    raised: false,
    stroked: false,
    buttonColor: 'primary',
    spinnerColor: 'accent',
    fullWidth: false,
    disabled: false,
    mode: 'indeterminate'
  };

  public name: string;

  constructor(
    private lobbyService: LobbyService,
    public dialogRef: MatDialogRef<JoinGameDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: JoinGameDialogData) { }

  onJoinClick(): void {
    this.joinBtnOptions.active = true;
    this.lobbyService.joinGame(this.data.gameCode, this.name)
  }
}
