import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StationService {
  private baseURL: string = environment.baseURL;

  constructor(
    private http: HttpClient
  ) { }

  addStation(data: any) {
    return this.http.post<any>(`${this.baseURL}Station`, data);
  }
}
