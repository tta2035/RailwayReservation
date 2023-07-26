import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private baseURL: string = environment.baseURL;
  
  constructor(
    private http: HttpClient
  ) { }

  getAllBooking() {
    return this.http.get<any>(`${this.baseURL}Booking`);
  }

  getAllPassenger() {
    return this.http.get<any>(`${this.baseURL}Passenger`);
  }

  getAllTrip() {
    return this.http.get<any>(`${this.baseURL}Trip`);
  }

  getAllTicket() {
    return this.http.get<any>(`${this.baseURL}Ticket`);
  }

  getAllRoute() {
    return this.http.get<any>(`${this.baseURL}Route`);
  }

  getAllStation() {
    return this.http.get<any>(`${this.baseURL}Station`);
  }

  getAllTrain() {
    return this.http.get<any>(`${this.baseURL}Train`);
  }

  getAllSeatType() {
    return this.http.get<any>(`${this.baseURL}SeatType`);
  }

  getAllUser() {
    return this.http.get<any>(`${this.baseURL}user`);
  }
}
