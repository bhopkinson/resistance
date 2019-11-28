import { Injectable, OnDestroy } from '@angular/core';
import { Subject, Observable, zip, Subscription, BehaviorSubject, from, combineLatest, merge } from 'rxjs';
import { tap, map, filter, mergeAll, count, withLatestFrom, combineAll } from 'rxjs/operators';
import { Lobby } from '../models/Lobby';
import { IMqttServiceOptions, MqttService, IMqttMessage } from 'ngx-mqtt';
import { decode } from "@msgpack/msgpack";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Game } from '../models/Game';
import { Router } from '@angular/router';
import { GameService } from './game.service';
import { AppMqttService } from './app-mqtt.service';
import { Player } from '../models/Player';

@Injectable()
export class LobbyService {

    constructor(
        private gameService: GameService,
        private http: HttpClient,
        private mqtt: AppMqttService) { }

    public createGame(): Observable<string> {
        return this.http.post<string>("api/game/create", null);
    }

    public joinGame(gameCode: string, name: string): Observable<string> {
        var httpOptions = {
          headers: new HttpHeaders({
              'Content-Type': 'application/json'
          })
        };
        return this.http.post<string>(`api/game/${gameCode}/join`, JSON.stringify(name), httpOptions)
            .pipe(
                tap(token => this.gameService.storeToken(token))
            );
    }

    public getGameCodes(): Observable<string[]> {
        return this.mqtt.observe("lobby/games") as Observable<string[]>;
    }

    public getGamePlayers(gameCode: string): Observable<Player[]> {
        return this.mqtt.observe(`lobby/games/${gameCode}`) as Observable<Player[]>;
    }

    public getCurrentPlayer(gameCode: string): Observable<Player> {
        return combineLatest(
            this.getGamePlayers(gameCode),
            this.gameService.getPlayerId()
        ).pipe(
            map(([players, id]) => players.find(player => player.Id === id))
        );
    }
}
