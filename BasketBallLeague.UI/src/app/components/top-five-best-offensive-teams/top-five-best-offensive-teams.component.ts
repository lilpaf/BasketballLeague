import { Component, OnInit } from '@angular/core';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-top-five-best-offensive-teams',
  templateUrl: './top-five-best-offensive-teams.component.html',
  styleUrls: ['./top-five-best-offensive-teams.component.css']
})
export class TopFiveBestOffensiveTeamsComponent implements OnInit {
  
  teams : Team[] = [];
  index : number = 0;

  constructor (private teamService: TeamService) {}

  ngOnInit() : void {
    this.teamService.getTopFiveOffensiveTeams()
    .subscribe((result: Team[]) => (this.teams = result))
  }
}
