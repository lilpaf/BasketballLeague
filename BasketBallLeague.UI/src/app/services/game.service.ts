import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { AllGames } from "../models/all-games";
import { Game } from "../models/game";


@Injectable({
    providedIn: 'root'
})
export class GameService {
    constructor(private http: HttpClient) { }

    public getGames(currentPage: number): Observable<AllGames> {
        let url = "Games";
        let CurrentPage = "";

        if(currentPage) {
            CurrentPage = `CurrentPage=${currentPage}`;
        }

        return this.http.get<AllGames>(`${environment.apiUrl}/${url}?${CurrentPage}`);
    }

    public getHighlightMatch(): Observable<Game> {
        let url = "HighlightMatch";

        return this.http.get<Game>(`${environment.apiUrl}/${url}`);
    }
}