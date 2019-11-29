import { Injectable, OnDestroy } from '@angular/core';
import { Subject, ReplaySubject, BehaviorSubject, Observable, Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { PlayerDetails } from '../models/PlayerDetails';
import { GamePlayer } from '../models/GamePlayer';
import { GameBoard } from '../models/GameBoard';
import { Character } from '../models/Character';
import { Team } from '../models/Team';
import { Role } from '../models/Role';
import { StorageMap } from '@ngx-pwa/local-storage';
import * as jwt_decode from 'jwt-decode';
import { map } from 'rxjs/internal/operators/map';
import { tap } from 'rxjs/internal/operators/tap';
import { filter, defaultIfEmpty } from 'rxjs/operators';
import { AppMqttService } from './app-mqtt.service';

@Injectable({
  providedIn: 'root'
})
export class GameService implements OnDestroy {
    private _messageReceived = new Subject();
    private _connectionEstablished = new Subject<Boolean>(); 
    private _countdown = new Subject<boolean>();
    private _players = new ReplaySubject<PlayerDetails[]>();
    private _gameBoard = new Subject<GameBoard>();
    private _showLeaderScript = new Subject<boolean>();
    private _characterAssigned = new ReplaySubject<boolean>(1);

    public messageReceived = this._messageReceived.asObservable();
    public connectionEstablished = this._connectionEstablished.asObservable();
    public countdown$ = this._countdown.asObservable();
    public players$ = this._players.asObservable();
    public gameBoard$ = this._gameBoard.asObservable();
    public character: Character = null;
    public leader: string = null;
    public characterAssigned = this._characterAssigned.asObservable();
    public initials: string;
    public showLeaderScript = this._showLeaderScript.asObservable();

    private _tokenSubscription: Subscription;
    private _token = new BehaviorSubject<string>(null);
    private _gameCode = new BehaviorSubject<string>(null);
    private _playerId = new BehaviorSubject<string>(null);

    public gameCode: Observable<string>;
    public playerId: Observable<string>;

    constructor(
      private mqtt: AppMqttService,
      private storage: StorageMap) {

      this.gameCode = this._gameCode;
      this.playerId = this._playerId;

      this._tokenSubscription = this._token.pipe(
          map(token => token ? jwt_decode(token) : null),
          tap(token => this._gameCode.next(token ? token['game_code'] : null)),
          tap(token => this._playerId.next(token ? token['player_id'] : null))
        ).subscribe({next: () => { } });

        this.storage.get("token", { type: 'string' }).subscribe({
          next: (token) => {
            this._token.next(token as string);
          }
        });
    }

    ngOnDestroy(){
      this._tokenSubscription.unsubscribe();
    }

    public storeToken(token: string): void {
      this._token.next(token);
      this.storage.set("token", token).subscribe({next: () => { }});
    }

    // public getGameCode(): Observable<string> {
    //   return this._token
    //     .pipe(map(token => token ? jwt_decode(token)['game_code'] : null));
    // }

    // public getPlayerId(): Observable<string> {
    //   return this._token
    //     .pipe(map(token => token ? jwt_decode(token)['player_id'] : null));
    // }

    public playerReady(ready: boolean): void {
      this.mqtt
        .publish(`game/${this._gameCode.value}/${this._playerId.value}/ready/command`, ready)
        .subscribe({ next: () => {} });
    }

    // public JoinGame(initials: string) {
    //     this.initials = initials;
    //     let player: GamePlayer = { gameId: '0', playerInitials: initials };
    //     this._hubConnection.invoke('JoinGame', player)
    //     .catch(err => console.error(err));
    // }

    // public PlayerReady(ready: boolean) {
    //     this._hubConnection.invoke('PlayerReady', ready)
    //     .catch(err => console.error(err));
    // }

    // public StartGame() {
    //     this._hubConnection.invoke('StartGame')
    //         .catch(err => console.error(err));
    // }

    // private createConnection() {
    //     this._hubConnection = new HubConnectionBuilder()
    //         .withUrl(window.location.href + 'game')
    //         .configureLogging(signalR.LogLevel.Information)
    //     .build();
    // }

    // private startConnection(): void {
    //     this._hubConnection
    //     .start()
    //     .then(() => {
    //         this._connectionEstablished.next(true);
    //     })
    //     .catch(err => {
    //         setTimeout(function () { this.startConnection(); }, 1000);
    //     }); 
    // }

    // private registerOnClientEvents(): void {
    //     this._hubConnection.onreconnected((connectionId: string, ) => {
    //         this._connectionEstablished.next(true);
    //         this._hubConnection.invoke('Reconnect');
    //     });

    //     this._hubConnection.onreconnecting(() => {
    //         this._connectionEstablished.next(false);
    //     });

    //     this._hubConnection.onclose(() => {
    //         this._connectionEstablished.next(false);
    //     });
    // }

    // private registerOnServerEvents(): void {
    //     this._hubConnection.on('UpdatePlayersList', (players: PlayerDetails[]) => {
    //         this._players.next(players);
    //     });
    //     this._hubConnection.on('Countdown', (started: boolean) => {
    //         this._countdown.next(started);
    //     });
    //     this._hubConnection.on('GameBoardChange', (gameBoard: GameBoard) => {
    //         this._gameBoard.next(gameBoard);
    //         this.leader = gameBoard.Leader;
    //     });
    //     this._hubConnection.on('ShowCharacter', (character: Character) => {
    //         this.character = character;
    //         this._characterAssigned.next(true);
            
    //     });
    //     this._hubConnection.on('ShowLeaderScript', (showScript: boolean) => {
    //         this._showLeaderScript.next(showScript);
    //     });
    // }
}
