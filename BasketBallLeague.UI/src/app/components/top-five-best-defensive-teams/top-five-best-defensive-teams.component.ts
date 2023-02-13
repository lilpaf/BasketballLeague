import { Component, OnInit } from '@angular/core';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-top-five-best-defensive-teams',
  templateUrl: './top-five-best-defensive-teams.component.html',
  styleUrls: ['./top-five-best-defensive-teams.component.css']
})
export class TopFiveBestDefensiveTeamsComponent implements OnInit {
  
  teams : Team[] = [];
  index : number = 0;

  constructor (private teamService: TeamService) {}

  ngOnInit() : void {
    this.teamService.getTopFiveDefensiveTeams()
    .subscribe((result: Team[]) => (this.teams = result))
  }
}
