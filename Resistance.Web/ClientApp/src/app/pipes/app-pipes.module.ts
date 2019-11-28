import { NgModule } from "@angular/core";
import { PlayerCountPipe } from "./player-count.pipe";

@NgModule({
    imports: [],
    declarations: [
      PlayerCountPipe
    ],
    exports: [
      PlayerCountPipe
    ]
  })
  export class AppPipesModule { }