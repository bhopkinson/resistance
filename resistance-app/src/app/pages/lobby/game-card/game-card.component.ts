import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { Player } from 'src/app/models/Player';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss']
})
export class GameCardComponent implements OnInit {
  //@HostBinding('class') gameCard = 'app-game-card';
  //@HostBinding('ngClass.gt-sm') gameCardGtSm = 'app-game-card--gt-sm';

  players: Player[] = [
    {Id: '1', Initials: 'BH', IsReady: false, ImageUrl: 'BH.jpg'},
    {Id: '2', Initials: 'AD', IsReady: true, ImageUrl: 'AD.jpg'},
    {Id: '3', Initials: 'JT', IsReady: true, ImageUrl: 'JT.jpg'},
    {Id: '4', Initials: 'CO', IsReady: false, ImageUrl: 'CO.jpg'},
    {Id: '5', Initials: 'JP', IsReady: false, ImageUrl: 'JP.jpg'},
    {Id: '6', Initials: 'TH', IsReady: false, ImageUrl: 'TH.jpg'},
    {Id: '7', Initials: 'PH', IsReady: true, ImageUrl: 'PH.jpg'},
    {Id: '8', Initials: 'NJ', IsReady: true, ImageUrl: 'NJ.jpg'},
    {Id: '9', Initials: 'DH', IsReady: true, ImageUrl: 'DH.jpg'},
    {Id: '10', Initials: 'MW', IsReady: false, ImageUrl: 'MW.jpg'},
    {Id: '11', Initials: 'BD', IsReady: true, ImageUrl: 'BD.jpg'},
];

  playerCountText = `${this.players.length} player${this.players.length === 1 ? '' : 's'}`; 

  constructor() { } 

  ngOnInit() {
  }

}
