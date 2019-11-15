import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LobbyPageComponent } from './pages/lobby/lobby-page/lobby-page.component';


const routes: Routes = [
  { path: '', redirectTo: 'lobby', pathMatch: 'full' },
  { path: 'lobby', component: LobbyPageComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
