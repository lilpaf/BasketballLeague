import { Component, OnInit } from '@angular/core';
import { AllGames } from 'src/app/models/all-games';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-all-games',
  templateUrl: './all-games.component.html',
  styleUrls: ['./all-games.component.css', '../../app.component.css']
})
export class AllGamesComponent implements OnInit {
  games: Game[] = [];
  index: number = 0;
  currentPage: number = 1;
  maxPage : number = 0;

  constructor(private gameService: GameService) { }
  
  ngOnInit(): void {
    this.gameService.getGames(this.currentPage)
      .subscribe((result: AllGames) => 
      (this.games = result.games, this.maxPage = Math.ceil(result.totalGames / result.gamesPerPage)));
  }

  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.gameService.getGames(this.currentPage)
        .subscribe((result: AllGames) => 
        (this.games = result.games));
    }
  }

  nextPage() {
    this.currentPage++;
    this.gameService.getGames(this.currentPage)
      .subscribe((result: AllGames) => 
      (this.games = result.games));
  }
}
