import { Component, OnInit, HostBinding } from '@angular/core';

@Component({
  selector: 'app-player-chip',
  templateUrl: './player-chip.component.html',
  styleUrls: ['./player-chip.component.scss']
})
export class PlayerChipComponent implements OnInit {
  @HostBinding('class') playerChip = 'app-player-chip';

  ready = true;

  constructor() { }

  ngOnInit() {
  }

}
