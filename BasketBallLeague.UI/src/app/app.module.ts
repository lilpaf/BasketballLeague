import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AllTeamsComponent } from './components/all-teams/all-teams.component';
import { RouterModule, Routes } from '@angular/router';
import { AllGamesComponent } from './components/all-games/all-games.component';
import { TopFiveBestOffensiveTeamsComponent } from './components/top-five-best-offensive-teams/top-five-best-offensive-teams.component';
import { TopFiveBestDefensiveTeamsComponent } from './components/top-five-best-defensive-teams/top-five-best-defensive-teams.component';
import { HighlightMatchComponent } from './components/highlight-match/highlight-match.component';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  { path: 'Games', component: AllGamesComponent },
  { path: 'Teams', component: AllTeamsComponent },
  { path: 'TopFiveOffensiveTeams', component: TopFiveBestOffensiveTeamsComponent },
  { path: 'TopFiveDefensiveTeams', component: TopFiveBestDefensiveTeamsComponent },
  { path: 'HighlightMatch', component: HighlightMatchComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    AllTeamsComponent,
    AllGamesComponent,
    TopFiveBestOffensiveTeamsComponent,
    TopFiveBestDefensiveTeamsComponent,
    HighlightMatchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    RouterModule.forRoot(routes),
    FormsModule
  ],
  exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
