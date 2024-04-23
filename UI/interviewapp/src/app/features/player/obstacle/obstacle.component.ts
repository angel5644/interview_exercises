import { Component } from '@angular/core';

@Component({
  selector: 'app-obstacle',
  standalone: true,
  imports: [],
  templateUrl: './obstacle.component.html',
  styleUrl: './obstacle.component.css'
})
export class ObstacleComponent {
  // Logic for generating random obstacles and detecting collisions
  // Emit an event when an obstacle is avoided
}
