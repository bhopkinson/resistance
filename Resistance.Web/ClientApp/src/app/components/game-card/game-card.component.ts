import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { Game } from '../../models/Game';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss']
})
export class GameCardComponent implements OnInit {

  @Input() game: Game;

  // players: Player[] = [
  //   {Id: '1', Initials: 'BH', IsReady: false, ImageUrl: 'BH.jpg'},
  //   {Id: '2', Initials: 'AD', IsReady: true, ImageUrl: 'AD.jpg'},
  //   {Id: '3', Initials: 'JT', IsReady: true, ImageUrl: 'JT.jpg'},
  //   {Id: '4', Initials: 'CO', IsReady: false, ImageUrl: 'CO.jpg'},
  //   {Id: '5', Initials: 'JP', IsReady: false, ImageUrl: 'JP.jpg'},
  //   {Id: '6', Initials: 'TH', IsReady: false, ImageUrl: 'TH.jpg'},
  //   // {Id: '7', Initials: 'PH', IsReady: true, ImageUrl: 'PH.jpg'},
  //   // {Id: '8', Initials: 'NJ', IsReady: true, ImageUrl: 'NJ.jpg'},
  //   // {Id: '9', Initials: 'DH', IsReady: true, ImageUrl: 'DH.jpg'},
  //   // {Id: '10', Initials: 'MW', IsReady: false, ImageUrl: 'MW.jpg'},
  //   // {Id: '11', Initials: 'BD', IsReady: true, ImageUrl: 'BD.jpg'},
  //];

  public getPlayerCountText()
  {
    return `${this.game.Players.length} player${this.game.Players.length === 1 ? '' : 's'}`;
  }

  constructor() { }

  ngOnInit() {
  }

}
