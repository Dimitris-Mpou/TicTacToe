import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService: AccountService) {

  }

  canActivate(): Observable<boolean>{
    return this.accountService.CurrentUser$.pipe(
      map(user => {
        if (user) return true
        console.log("You have no access, either log in or register")
      })
    )
  }
  
}
