import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'JW_Angular';

  constructor(private jwtHelper: JwtHelperService) {}

  isUserAuthenticated() {
    const token: string | null = localStorage.getItem("jwt");
    if(token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else{
      return false;
    }
  }

  logOut() {
    localStorage.removeItem("jwt");
  }
}
