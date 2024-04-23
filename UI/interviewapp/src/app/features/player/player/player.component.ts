import { Component, HostListener, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-player',
  standalone: true,
  imports: [RouterLink, RouterOutlet],
  templateUrl: './player.component.html',
  styleUrl: './player.component.css'
})
export class PlayerComponent implements OnInit {
  isJumping: boolean = false;

  // Properties
  player: Player;

  // Methods
  constructor(){
    this.player = {
      id: 1,
      playerName: "Angel",
      coinsCollected: 0,
    };
  }
  ngOnInit(): void {
    this.player = {
      id: 1,
      playerName: "Angel",
      coinsCollected: 0,
    }
  }

  jump(){

    if(!this.isJumping){

      this.isJumping = true;

      setTimeout(() => {

        this.isJumping = false;

      }, 500); // Adjust timing to match animation duration
    }
  }

}


