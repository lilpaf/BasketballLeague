import { Component, OnInit } from '@angular/core';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-highlight-match',
  templateUrl: './highlight-match.component.html',
  styleUrls: ['./highlight-match.component.css']
})
export class HighlightMatchComponent implements OnInit {
  highlightMatch : Game = new Game;
  index : number = 0;

  constructor (private gameService: GameService) {}

  ngOnInit() : void {
    this.gameService.getHighlightMatch()
    .subscribe((result: Game) => (this.highlightMatch = result))
  }
}
