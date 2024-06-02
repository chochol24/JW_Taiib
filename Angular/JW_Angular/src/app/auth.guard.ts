import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
class PermissionsService {

  constructor(private jwtHelper: JwtHelperService, private router: Router) {}
  private readonly apiToken = inject(TokenService);
  
  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
      const token = localStorage.getItem("jwt");
      if(token && !this.jwtHelper.isTokenExpired(token)){
        if(state.url.includes('orders/all') && !this.apiToken.isAdmin())
          return false;
        return true;
      }
      this.router.navigate(["login"]);
      return false;
  }
}

export const authGuard: CanActivateFn = (next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
  return inject(PermissionsService).canActivate(next,state);
}