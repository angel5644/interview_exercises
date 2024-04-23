import { Routes } from '@angular/router';
import { PlayerListComponent } from './features/player/player-list/player-list.component';
import { PlayerComponent } from './features/player/player/player.component';

export const routes: Routes = [
    {path: 'players', component: PlayerListComponent},
    {path: 'player', component: PlayerComponent}
];
