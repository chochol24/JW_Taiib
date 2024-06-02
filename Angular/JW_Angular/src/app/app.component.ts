import { Component, inject } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { jwtDecode } from 'jwt-decode';
import { TokenService } from './token.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'JW_Angular';
  public readonly apiToken = inject(TokenService);

  constructor(private jwtHelper: JwtHelperService) {}

  isUserAuthenticated() {
    const token: string | null = localStorage.getItem("jwt");
    if(token && !this.jwtHelper.isTokenExpired(token)) {
      this.apiToken.setToken(token);
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
