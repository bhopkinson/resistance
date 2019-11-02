import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/game.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-join-game',
  templateUrl: './join-game.component.html',
  styleUrls: ['./join-game.component.scss']
})
export class JoinGameComponent implements OnInit {
  ngOnInit(): void {
    this.gameService.players$.subscribe(_ => {
      if(this.joinGameRequested){
        this.router.navigateByUrl('/player/room', {skipLocationChange: true});
      }
    });
  }

  constructor(private gameService: GameService, private router: Router){}

  initials: string = "";
  joinGameRequested = false;
  private lettersRegEx = /^[a-zA-Z]+$/;
  private nullInitialsMessage = 'Please enter some initials.';
  private nonLettersInInitialsMessage = 'Initals must only have letters';
  private incorrectInitialsLengthMessage = 'Initals must only have two letters';

  joinGame(): void {
    if(!this.areInitialsValid()){
      return;
    }
    this.gameService.JoinGame(this.initials.toUpperCase());
    this.joinGameRequested = true;
  }

  private areInitialsValid(): boolean {
    const initials = this.initials;
    if(!initials){
      alert(this.nullInitialsMessage);
      return false;
    }
    if (!initials.match(this.lettersRegEx)){
      alert(this.nonLettersInInitialsMessage);
      return false
    }
    if (this.initials.length !== 2){
      alert(this.incorrectInitialsLengthMessage);
      return false;
    }
    return true;
  }

}
