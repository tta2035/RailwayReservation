import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

import { CanActivate } from './CanActivate';
import { AuthService } from '../services/auth.service';
import { NgToastService } from 'ng-angular-popup';

@Injectable({
  providedIn: 'root'
})
export class authGuard implements CanActivate {

  constructor(
    private auth: AuthService, 
    private router: Router, 
    private toast: NgToastService
    ) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    
    if(this.auth.isLoggedIn()) {
      return true;
    }
    this.toast.error({ detail: "Error", summary: "Bạn chưa đăng nhập", duration: 5000 });
    alert("Bạn chưa đăng nhập");
    this.router.navigate(['/login']);
    return false;
  }

}



