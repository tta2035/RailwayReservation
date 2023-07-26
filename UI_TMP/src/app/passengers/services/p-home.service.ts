import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PHomeService {
  private baseURL: string = environment.baseURL; 

  constructor(
    private http: HttpClient
  ) { }

  getAllStationAndRoute() {
    return this.http.get<any>(`${this.baseURL}Route`);
  }

  getAllStation() {
    return this.http.get<any>(`${this.baseURL}Station`);
  }
  getAllTrips() {
    return this.http.get<any>(`${this.baseURL}Trip`);
  }
  getAllCoaches() {
    return this.http.get<any>(`${this.baseURL}api/Coach`);
  }
  getAllTickets(){
    return this.http.get<any>(`${this.baseURL}Ticket`);
  }
  getAllSeats(){
    return this.http.get<any>(`${this.baseURL}Seat`);
  }
}
