import { Component, OnInit, HostBinding, Input } from '@angular/core';
import { Player } from 'src/app/models/Player';

@Component({
  selector: 'app-player-chip',
  templateUrl: './player-chip.component.html',
  styleUrls: ['./player-chip.component.scss']
})
export class PlayerChipComponent implements OnInit {
  @HostBinding('class') playerChip = 'app-player-chip';

  @Input() player: Player;

  constructor() { }

  ngOnInit() {
  }

}
