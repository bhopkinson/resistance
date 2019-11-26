import { Injectable } from '@angular/core';
import { Subject, Observable, Subscription, BehaviorSubject, from } from 'rxjs';
import { Lobby } from '../models/Lobby';
import { IMqttServiceOptions, MqttService, IMqttMessage } from 'ngx-mqtt';
import { decode } from "@msgpack/msgpack";
import { HttpClient } from '@angular/common/http';
import { Game } from '../models/Game';

export const MQTT_SERVICE_OPTIONS: IMqttServiceOptions = {
    hostname: "localhost",
    port: 5000,
    protocol: "ws",
    username: "lobby"
};

@Injectable()
export class LobbyService {

    private _gamesSubscription: Subscription;
    private _lobbySubsciption: Subscription;
    private _lobbyGamesSubscription: Subscription;

    public games = new Observable<Observable<Game>[]>();

    private _games = new BehaviorSubject<Map<string, Subject<Game>>>(new Map<string, Subject<Game>>());

    constructor(
        private http: HttpClient,
        private mqtt: MqttService) {
        
        this.mqtt.connect(MQTT_SERVICE_OPTIONS);
        this.registerSubscriptions();
    }
    
    public ngOnDestroy(): void {
        this._gamesSubscription.unsubscribe();
        this._lobbySubsciption.unsubscribe();
        this._lobbyGamesSubscription.unsubscribe();
    }

    public createGame(): Observable<string> {
        return this.http.post<string>("api/game/create", null);
    }

    private registerSubscriptions(): void {
        
        this._gamesSubscription = this._games.subscribe(map => this.games.next());

        this._lobbySubsciption = this.mqtt.observe("lobby").subscribe((message: IMqttMessage) => {
            // Fresh list of game codes from server
            const freshGameCodes = decode(message.payload) as string[];

            // New map of games
            const newGameMap = new Map<string, Subject<Game>>();

            // Add all existing games into the new map
            this._games.getValue().forEach((game, code) => {
                if (freshGameCodes.includes(code)) {
                    newGameMap.set(code, game);
                }
            });

            // Get new game codes and add them to the map
            const newGameCodes = freshGameCodes.filter(code => !newGameMap.has(code));
            newGameCodes.forEach(code => {
                newGameMap.set(code, new Subject<Game>())
            });

            // Push updated map
            this._games.next(newGameMap);
        });

        this._lobbyGamesSubscription = this.mqtt.observe("lobby/+").subscribe((message: IMqttMessage) => {
            const gameCode = message.topic.split('/')[1];
            const game = this._games.getValue().get(gameCode);
            game.next(decode(message.payload) as Game);
        });
    }

    // public CreateGame() {
    //     this._hubConnection.invoke('CreateGame')
    //         .catch(err => console.error(err));
    // }

    // private registerOnClientEvents(): void {
    //     this._hubConnection.onreconnecting(() => {
    //         this._connectionEstablished.next(false);
    //     });

    //     this._hubConnection.onclose(() => {
    //         this._connectionEstablished.next(false);
    //     });
    // }

    // private registerOnServerEvents(): void {
    //     this._hubConnection.on('UpdateLobby', (data: Lobby) => {
    //         this._lobbyData.next(data);
    //     });
    // }
}
