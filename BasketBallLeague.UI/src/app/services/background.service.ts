import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BackgroundService {
  displayedBackGround: boolean;

  constructor() {
    this.displayedBackGround = true;
  }

  setDisplayedComponent(value: boolean) {
    this.displayedBackGround = value;
  }
}
