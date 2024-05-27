import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  private token!: string;
  decodedToken: any;
  constructor() {}

  setToken(token: string) {
    this.token = token;
  }

  getToken(): string | null {
    return this.token;
  }

  decode(): number{
    this.decodedToken = jwtDecode(this.token);
    const userID = this.decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    return parseInt(userID);
  }
}
