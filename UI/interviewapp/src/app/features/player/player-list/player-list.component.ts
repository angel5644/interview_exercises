import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-player-list',
  standalone: true,
  imports: [RouterOutlet, RouterLink, CommonModule],
  templateUrl: './player-list.component.html',
  styleUrl: './player-list.component.css'
})
export class PlayerListComponent implements OnInit{
  players: Player[];
  enableAdd: boolean = true;
  loaded: boolean = false;

  constructor(){
    this.players = [
      {
        id: 1,
        playerName: "John",
        coinsCollected: 0,
        jumpsRemaining: 3
      },
      {
        id: 2,
        playerName: "Angel",
        coinsCollected: 2,
        jumpsRemaining: 5
      },
      {
        id: 3,
        playerName: "Brian",
        coinsCollected: 10,
        jumpsRemaining: 7
      }
    ]

    console.log(JSON.stringify(this.players));
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.players = [
        {
          id: 1,
          playerName: "John",
          coinsCollected: 0,
          jumpsRemaining: 3,
          image: "https://picsum.photos/id/200/300/150",
        },
        {
          id: 2,
          playerName: "Angel",
          coinsCollected: 2,
          jumpsRemaining: 5,
          image: "https://picsum.photos/id/500/300/150",
        },
        {
          id: 3,
          playerName: "Brian",
          coinsCollected: 10,
          jumpsRemaining: 7,
          image: "https://picsum.photos/id/100/300/150",
        }
      ];

      this.loaded = true;
    }, 2000);
  }

  addPlayer(player: Player){
    this.players.push(player);
  }

  // AddPlayer(e:Event){
  //   console.log(e.type);
  // }
}
