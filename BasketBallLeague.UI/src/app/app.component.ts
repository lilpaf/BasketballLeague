import { Component } from '@angular/core';
import { BackgroundService } from './services/background.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BasketBallLeague.UI';

  constructor (public backgroundService: BackgroundService) {}

  ngOnInit() : void {
  }
}
