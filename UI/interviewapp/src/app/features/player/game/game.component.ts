import { Component } from '@angular/core';
import { ObstacleComponent } from '../obstacle/obstacle.component';
import { PlayerComponent } from '../player/player.component';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-game',
  standalone: true,
  imports: [PlayerComponent, ObstacleComponent],
  templateUrl: './game.component.html',
  styleUrl: './game.component.css'
})
export class GameComponent {
  player: PlayerComponent = new PlayerComponent();
  obstacles: ObstacleComponent[] = [];
  score:number = 0;

  // Game logic (e.g., game loop, collision detection)

  // Game logic, game loop, collision detection and scoring

  // End the game if player hits an obstacle or runs out of jumps
}
