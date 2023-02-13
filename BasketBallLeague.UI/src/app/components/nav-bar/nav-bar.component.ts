import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { BackgroundService } from 'src/app/services/background.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private router: Router, private viewContainerRef: ViewContainerRef, public backgroundService: BackgroundService) 
  { 
  }

  ngOnInit(): void {
  }

  navbarCollapsed = true;

  toggleNavbarCollapsing() {
    this.navbarCollapsed = !this.navbarCollapsed;
  }

  hideRouterOutlets() {
    this.router.navigate(['/your-route']).then(() => {
      this.router.events.subscribe(event => {
        if (event instanceof NavigationEnd) {
          this.viewContainerRef.clear();
          this.backgroundService.setDisplayedComponent(false);
        }
      });
    });
  }
  

}
