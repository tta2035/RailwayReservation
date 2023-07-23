import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }

  private account$ = new BehaviorSubject<any>({});
  receivedAccount$ = this.account$.asObservable();

  private booking$ = new BehaviorSubject<any>({});
  receivedBooking$ = this.booking$.asObservable();

  private dashboard$ = new BehaviorSubject<any>({});
  receivedDashboard$ = this.dashboard$.asObservable();

  private passenger$ = new BehaviorSubject<any>({});
  receivedPassenger$ = this.passenger$.asObservable();

  private route$ = new BehaviorSubject<any>({});
  receivedRoute$ = this.route$.asObservable();

  private seatType$ = new BehaviorSubject<any>({});
  receivedSeatType$ = this.seatType$.asObservable();

  private station$ = new BehaviorSubject<any>({});
  receivedStation$ = this.station$.asObservable();

  private ticket$ = new BehaviorSubject<any>({});
  receivedTicket$ = this.ticket$.asObservable();

  private train$ = new BehaviorSubject<any>({});
  receivedTrain$ = this.train$.asObservable();

  private trip$ = new BehaviorSubject<any>({});
  receivedTrip$ = this.trip$.asObservable();

  sendAccount(data: any) {
    this.account$.next(data);
  }

  sendBooking(data: any) {
    this.booking$.next(data);
  }

  sendPassenger(data: any) {
    this.passenger$.next(data);
  }

  sendRoute(data: any) {
    this.route$.next(data);
  }

  sendSeatType(data: any) {
    this.seatType$.next(data);
  }

  sendStation(data: any) {
    this.station$.next(data);
  }

  sendTicket(data: any) {
    this.ticket$.next(data);
  }

  sendTrain(data: any) {
    this.train$.next(data);
  }

  sendTrip(data: any) {
    this.trip$.next(data);
  }
}
