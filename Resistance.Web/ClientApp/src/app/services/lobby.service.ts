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

    private _lobbyGamesSubscription: Subscription;

    public gameCodes: Observable<string[]>;

    private _gameCodes = new BehaviorSubject<string[]>([]);

    constructor(
        private http: HttpClient,
        private mqtt: MqttService) {
        
        this.mqtt.connect(MQTT_SERVICE_OPTIONS);
        this.registerSubscriptions();
        this.gameCodes = this._gameCodes;
    }
    
    public ngOnDestroy(): void {
        this._lobbyGamesSubscription.unsubscribe();
    }

    public createGame(): Observable<string> {
        return this.http.post<string>("api/game/create", null);
    }

    public joinGame(gameCode: string, name: string): Observable<string> {
        console.log("Joining game");
        return this.http.post<string>(`api/game/${gameCode}/join`, name);
    }

    private registerSubscriptions(): void {
        
        //this._gamesSubscription = this._gameCodes.subscribe(gameCodes => this.gameCodes.next([...gameCodes.values()]));

        this._lobbyGamesSubscription = this.mqtt.observe("lobby/games").subscribe((message: IMqttMessage) => {
            this._gameCodes.next(decode(message.payload) as string[]);
        });

        // this._lobbySubsciption = this.mqtt.observe("lobby/games").subscribe((message: IMqttMessage) => {
        //     // Fresh list of game codes from server
        //     const freshGameCodes = decode(message.payload) as string[];

        //     // New map of games
        //     const newGameMap = new Map<string, Subject<Game>>();

        //     // Add all existing games into the new map
        //     this._gameCodes.getValue().forEach((game, code) => {
        //         if (freshGameCodes.includes(code)) {
        //             newGameMap.set(code, game);
        //         }
        //     });

        //     // Get new game codes and add them to the map
        //     const newGameCodes = freshGameCodes.filter(code => !newGameMap.has(code));
        //     newGameCodes.forEach(code => {
        //         newGameMap.set(code, new Subject<Game>())
        //     });

        //     // Push updated map
        //     this._games.next(newGameMap);
        // });

        // this._lobbyGamesSubscription = this.mqtt.observe("lobby/games/+").subscribe((message: IMqttMessage) => {
        //     const gameCode = message.topic.split('/')[1];
        //     const game = this._games.getValue().get(gameCode);
        //     game.next(decode(message.payload) as Game);
        // });
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
