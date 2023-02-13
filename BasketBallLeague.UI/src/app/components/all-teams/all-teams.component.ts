import { Component, OnInit } from '@angular/core';
import { AllTeams } from 'src/app/models/all-teams';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-all-teams',
  templateUrl: './all-teams.component.html',
  styleUrls: ['./all-teams.component.css', '../../app.component.css']
})
export class AllTeamsComponent implements OnInit {
  
  teams : Team[] = [];
  index : number = 0;
  searchTerm : string = "";
  currentPage = 1;
  maxPage : number = 0;

  constructor (private teamService: TeamService) {}

  ngOnInit() : void {
    this.teamService.getTeams(this.currentPage)
    .subscribe((result: AllTeams) => 
    (this.teams = result.teams, this.maxPage = Math.ceil(result.totalTeams / result.teamsPerPage)));
  }

  search() {
    this.teamService.getTeams(this.currentPage, this.searchTerm)
    .subscribe((result: AllTeams) => 
    (this.teams = result.teams, this.maxPage = Math.ceil(result.totalTeams / result.teamsPerPage)));
  }

  previousPage() {
    if (this.currentPage > 1) {
      
      this.currentPage--;
      
      if(this.searchTerm.length > 0) {
        this.teamService.getTeams(this.currentPage, this.searchTerm)
        .subscribe((result: AllTeams) => 
        (this.teams = result.teams, this.maxPage = Math.ceil(result.totalTeams / result.teamsPerPage)));
      }
      else {
        this.teamService.getTeams(this.currentPage)
        .subscribe((result: AllTeams) => 
        (this.teams = result.teams, this.maxPage = Math.ceil(result.totalTeams / result.teamsPerPage)));
      }
    }
  }

  nextPage() {
    
    this.currentPage++;
    
    if(this.searchTerm.length > 0) {
      this.teamService.getTeams(this.currentPage, this.searchTerm)
      .subscribe((result: AllTeams) => 
      (this.teams = result.teams, this.maxPage = Math.ceil(result.totalTeams / result.teamsPerPage)));
    }
    else {
      this.teamService.getTeams(this.currentPage)
      .subscribe((result: AllTeams) => 
      (this.teams = result.teams, this.maxPage = Math.ceil(result.totalTeams / result.teamsPerPage)));
    }
  }
}
