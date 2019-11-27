import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { IMqttServiceOptions, MqttService, IMqttMessage } from 'ngx-mqtt';
import { Player } from '../../models/Player';
import { Subject, Subscription, Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { decode } from '@msgpack/msgpack';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { JoinGameDialogComponent } from '../join-game-dialog/join-game-dialog.component';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss'],
})
export class GameCardComponent implements OnInit {

  @Input() gameCode: string;

  private _playersSubscription: Subscription;
  private _players = new BehaviorSubject<Player[]>([]);

  public players: Observable<Player[]>;

  constructor(
    public dialog: MatDialog,
    private mqtt: MqttService) {
      this.players = this._players;
  }

  ngOnInit() {
    this._playersSubscription = this.mqtt.observe(`lobby/games/${this.gameCode}`).subscribe((message: IMqttMessage) => {
      this._players.next(decode(message.payload) as Player[]);
    });
  }

  ngOnDestroy(): void {
    this._playersSubscription.unsubscribe();
  }
 
  public getPlayerCountText(): Observable<string>
  {
    return this.players.pipe(
      map(players => `${players.length} player${players.length === 1 ? '' : 's'}`)
    );
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