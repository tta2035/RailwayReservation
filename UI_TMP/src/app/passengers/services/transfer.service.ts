import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TransferService {

  constructor() { }
  private to:String;
  private from:String;
  private dateLeaveDate:String;
  private dateLeaveMonth:String;
  private dateLeaveYear:String;
  private trainID:String;
  private coaches:Array<any>=[];
  private chosenTripID:String;
  private chosenTickets:Array<any>=[];
  setTo(to:String) { this.to = to; }
  setFrom(from:String) { this.from = from; }
  setDateLeaveDate(dateLeave:String) { this.dateLeaveDate = dateLeave; }
  setDateLeaveMonth(dateLeave:String) { this.dateLeaveMonth=dateLeave; }
  setDateLeaveYear(dateLeave:String) { this.dateLeaveYear=dateLeave; }
  setTrainID(trainID:String) { this.trainID=trainID; }
  setCoaches(coaches:Array<any>) { this.coaches=coaches; }
  setChosenTripID(chosenTripID:String) { this.chosenTripID=chosenTripID; }
  setChosenTickets(chosenTickets:Array<any>) { this.chosenTickets=chosenTickets; }
  getTo() { return this.to; }
  getFrom() { return this.from; }
  getDateLeaveDate() { return this.dateLeaveDate; }
  getDateLeaveMonth() {return this.dateLeaveMonth; }
  getDateLeaveYear() { return this.dateLeaveYear; }
  getTrainID() { return this.trainID; }
  getCoaches() { return this.coaches; }
  getChosenTripID() { return this.chosenTripID; }
  getChosenTickets() { return this.chosenTickets; }
}
