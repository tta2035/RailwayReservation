import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/app/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseURL: string = environment.baseURL;
  private userPayload: any;
  constructor(
    private http: HttpClient
  ) { }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
}
