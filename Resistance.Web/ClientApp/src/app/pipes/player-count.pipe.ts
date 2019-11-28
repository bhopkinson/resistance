import { Pipe, PipeTransform } from '@angular/core';
import { Player } from '../models/Player';

@Pipe({
  name: 'playercount'
})
export class PlayerCountPipe implements PipeTransform {

  transform(players: Player[]): string {
    var temp = players ? players : [];
    return `${temp.length} player${temp.length === 1 ? '' : 's'}`;
  }

}
