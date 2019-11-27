import { Component, OnInit } from '@angular/core';
import { LobbyService } from '../../../services/lobby.service';
import { Observable, BehaviorSubject, Subscription, Subject, ReplaySubject } from 'rxjs';
import { Lobby } from '../../../models/Lobby';
import { Game } from 'src/app/models/Game';

@Component({
  selector: 'app-lobby-page',
  templateUrl: './lobby-page.component.html',
  styleUrls: ['./lobby-page.component.scss'],
  providers: [LobbyService]
})
export class LobbyPageComponent implements OnInit {

  public gameCodes = new Subject<string[]>();
  private gameCodesSubscription: Subscription;

  constructor(private lobbyService: LobbyService) { }

  ngOnInit() {
    this.gameCodesSubscription = this.lobbyService.gameCodes.subscribe(gameCodes => {
      this.gameCodes.next(gameCodes);
    })
  }

  ngOnDestroy(): void {
    this.gameCodesSubscription.unsubscribe();
  }

}
