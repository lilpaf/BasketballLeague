import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { AllTeams } from '../models/all-teams';
import { Team } from '../models/team';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  constructor(private http: HttpClient) { }

  public getTeams(currentPage: number, searchTerm?: string) : Observable<AllTeams> {
    let url = "Teams";
    let CurrentPage = "";
    let SearchTerm = "";

    if(currentPage) {
      CurrentPage = `CurrentPage=${currentPage}`;
    }

    if(searchTerm) {
      SearchTerm = `SearchTerm=${searchTerm}`;
    }

    return this.http.get<AllTeams>(`${environment.apiUrl}/${url}?${CurrentPage}&${SearchTerm}`);
  }

  public getTopFiveOffensiveTeams() : Observable<Team[]> {
    let url = "TopFiveOffensiveTeams";

    return this.http.get<Team[]>(`${environment.apiUrl}/${url}`);
  }

  public getTopFiveDefensiveTeams() : Observable<Team[]> {
    let url = "TopFiveDefensiveTeams";

    return this.http.get<Team[]>(`${environment.apiUrl}/${url}`);
  }
}
