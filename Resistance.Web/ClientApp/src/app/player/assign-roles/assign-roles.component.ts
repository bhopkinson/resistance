import { Component, OnInit } from '@angular/core';
import { Character } from 'src/app/models/Character';
import { GameService } from 'src/app/game.service';
import { RoleUtil } from 'src/app/models/Role';
import { TeamUtil } from 'src/app/models/Team';

@Component({
  selector: 'app-assign-roles',
  templateUrl: './assign-roles.component.html',
  styleUrls: ['./assign-roles.component.scss']
})
export class AssignRolesComponent implements OnInit {

  constructor(private gameService: GameService) { }

  public character: Character;
  public leader: string;
  public showCharacter = false;
  public isLeader = false;
  public roleAssigned = false;

  ngOnInit() {
    this.character = this.gameService.character;
    this.leader = this.gameService.leader;

    if (this.gameService.initials === this.gameService.leader) {
      this.isLeader = true;
    }

    this.gameService.characterAssigned
      .subscribe((characterAssigned: boolean) => {
        this.showCharacter = characterAssigned;
        if(characterAssigned) {
          this.roleAssigned = true;
        }
      });
  }

  getRole(): string {
    return TeamUtil.toString(this.character.team) + ' (' + RoleUtil.toString(this.character.role) + ')';
  }

  getLeader(): string {
    return this.leader;
  }

  finishedReadingScript(): void {
    console.log('finished reading script');
  }

  hideCharacter(): void {
    this.showCharacter = false;
    this.gameService.PlayerReady(true);
  }
}
