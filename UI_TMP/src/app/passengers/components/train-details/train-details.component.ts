import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TransferService } from '../../services/transfer.service';
import { PTripService } from '../../services/trips/p-trip.service';
import { PHomeService } from '../../services/p-home.service';
@Component({
  selector: 'app-train-details',
  templateUrl: './train-details.component.html',
  styleUrls: ['./train-details.component.css']
})
export class TrainDetailsComponent implements OnInit {
  constructor(private router:Router,private transferService:TransferService,private pHomeService:PHomeService){

  }
  time:String="09:05";
  statusTime:String="On time";
  from:String="London Bridge";
  to:String="Brighton";
  time_travel:String="1h 8m";
  stopNo:String="10 stops";
  statusSeat:String="Some seats available";
  platform:String="Platform 4";
  plannedDate:Date=new Date();
  plannedDateList:string[]=[];
  plannedDate1:string[]=[];
  plannedDateLeave:string="";
  Trips: Array<any> = [];
  chosenTrips:Array<any> = [];
  isLoadTrip: boolean = false;
  ListCoaches:Array<any>=[];
  isLoadCoach:boolean=false;
  ChosenCoachIDs:Array<any>=[];
  ListTickets:Array<any>=[];
  isLoadTickets:boolean=false;
  ngOnInit(): void {
    this.from=localStorage.getItem('departureStationIdSelected')||"";
    this.to=localStorage.getItem('selectecDestination')||"";
    console.log(this.transferService.getDateLeaveDate());
    this.plannedDate.setDate(Number(localStorage.getItem("dateLeaveDate")));
    this.plannedDate.setMonth(Number(localStorage.getItem("dateLeaveMonth")));
    this.plannedDate.setFullYear(Number(localStorage.getItem("dateLeaveYear")));
    this.plannedDateList=this.plannedDate.toUTCString().split(' ');
    this.plannedDateLeave=this.plannedDateList[0]+" "+this.plannedDateList[1]+" "+this.plannedDateList[2]+", "+this.plannedDateList[3];
    console.log(this.plannedDateLeave);
    this.pHomeService.getAllTrips().subscribe((value) => {
      this.Trips = value;
      this.isLoadTrip = true;
      console.log(this.Trips);
      console.log("hello world");
      this.chosenTrips=this.Trips.filter(value=>{
          this.plannedDate1=value.departureTime.split('T')[0].split('-');
          return this.plannedDate1[0]==localStorage.getItem("dateLeaveYear")&&
          String(Number(this.plannedDate1[1]))==localStorage.getItem("dateLeaveMonth")&&
          this.plannedDate1[2]==localStorage.getItem("dateLeaveDate")&&
          localStorage.getItem('departureStationIdSelected')==value.departureStation&&
          localStorage.getItem('selectecDestination')==value.destinationStation;
      });
      this.pHomeService.getAllCoaches().subscribe({
        next: (data) => {
          this.ListCoaches = data;
          this.isLoadCoach = true;
          console.log(this.ListCoaches);
          
        }
      });
      this.pHomeService.getAllTickets().subscribe(tickets =>{
        this.ListTickets=tickets;
        this.isLoadTickets=true;
      });
      console.log(this.chosenTrips);
      localStorage.setItem('chosenTrips', JSON.stringify(this.chosenTrips));
    })
    
    
    
  }
  chooseSeat(value:any){
    this.transferService.setTrainID(value.trainId);
    this.ChosenCoachIDs=this.ListCoaches.filter(coach =>
      {
        return coach.trainId==value.trainId;
      });
    this.transferService.setChosenTripID(
      this.chosenTrips.filter(trip =>{
        return trip.trainId==value.trainId;
      })[0].id
    ); 
    this.transferService.setChosenTickets(
      this.ListTickets.filter(ticket =>{
        return ticket.tripId=this.transferService.getChosenTickets();
      })
    )
    if(JSON.parse(localStorage.getItem('chosenTickets')||'')==''){
      localStorage.setItem('chosenTickets', JSON.stringify(this.transferService.getChosenTickets()));
    }
    if(JSON.parse(localStorage.getItem('ChosenCoachIDs')||'')==''){
      localStorage.setItem('ChosenCoachIDs',JSON.stringify(this.ChosenCoachIDs));
    }
    if(localStorage.getItem('trainName')||''==''){
      localStorage.setItem('trainName',value.trainName.toLowerCase());
    }
    this.transferService.setCoaches(JSON.parse(localStorage.getItem('ChosenCoachIDs')||'[]'));
    this.router.navigate(['passenger/seat/',value.trainName.toLowerCase()]);
  }

  // receivedTrip() {
  //   this.pTripService.receivedTrip$.subscribe((value) => {
  //     this.Trips = value;
  //     this.isLoadTrip = true;
  //     console.log(this.Trips);
  //   })
  // }
}
