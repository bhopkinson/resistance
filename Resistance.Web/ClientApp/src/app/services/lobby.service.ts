import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import * as signalR from '@microsoft/signalr';
import { RetryPolicy } from './RetryPolicy';
import { Subject, Observable } from 'rxjs';
import { Lobby } from '../models/Lobby';

@Injectable()
export class LobbyService {

    private _hubConnection: HubConnection;
    private _connectionEstablished = new Subject<Boolean>(); 

    private _lobbyData = new Subject<Lobby>();

    public lobbyData: Observable<Lobby> = this._lobbyData;

    constructor() {
        this.createConnection();
        this.registerOnClientEvents();
        this.registerOnServerEvents();
        this.startConnection();
    }

    public CreateGame() {
        this._hubConnection.invoke('CreateGame')
            .catch(err => console.error(err));
    }

    private startConnection(): void {
        this._hubConnection
        .start()
        .then(() => {
            this._connectionEstablished.next(true);
        })
        .catch(err => {
            setTimeout(function () { this.startConnection(); }, 1000);
        }); 
    }

    private createConnection() {
        this._hubConnection = new HubConnectionBuilder()
            .withUrl(window.location.href + 'lobby')
            .withAutomaticReconnect(new RetryPolicy())
            .configureLogging(signalR.LogLevel.Information)
        .build();
    }

    private registerOnClientEvents(): void {
        this._hubConnection.onreconnecting(() => {
            this._connectionEstablished.next(false);
        });

        this._hubConnection.onclose(() => {
            this._connectionEstablished.next(false);
        });
    }

    private registerOnServerEvents(): void {
        this._hubConnection.on('UpdateLobby', (data: Lobby) => {
            this._lobbyData.next(data);
        });
    }
}
