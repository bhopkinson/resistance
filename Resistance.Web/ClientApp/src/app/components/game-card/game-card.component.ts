import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { IMqttServiceOptions, MqttService, IMqttMessage } from 'ngx-mqtt';
import { Game } from '../../models/Game';
import { Player } from '../../models/Player';
import { Subject, Subscription, Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { decode } from '@msgpack/msgpack';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss']
})
export class GameCardComponent implements OnInit {

  @Input() gameCode: string;

  private _playersSubscription: Subscription;
  private _players = new BehaviorSubject<Player[]>([]);

  public players: Observable<Player[]>;

  constructor(
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

}
