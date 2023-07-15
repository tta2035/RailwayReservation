import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PHomeService } from 'src/app/passengers/services/p-home.service';
import { TransferService } from 'src/app/passengers/services/transfer.service';

@Component({
  selector: 'app-compartment2',
  templateUrl: './compartment2.component.html',
  styleUrls: ['./compartment2.component.css']
})
export class Compartment2Component {
  constructor(private router:Router,private pHomeService:PHomeService,private transferService:TransferService ){

  }
  seats = Array(61).fill(true);
  bookedSeats3AC=Array(57).fill(true);
  seats3AC=Array(57).fill(true);
  chosenSeat:number[]=[];
  compartNo:number=2;
  ListCoachesTrainID:Array<any>=[];
  isLoadCoach:boolean=false;
  ChosenCoachID:string='';
  ListChosenTickets:Array<any>=[];
  ListChosenTicketsSeatID:Array<any>=[];
  ListSeat:Array<any>=[];
  isLoadSeat:boolean=false;
  ChosenCoachIDs:Array<any>=[];
  ngOnInit(){
    this.ChosenCoachIDs=JSON.parse(localStorage.getItem('ChosenCoachIDs')||'[]');
    this.ChosenCoachID=this.ChosenCoachIDs.filter(coach =>{
      return coach.coachNo== this.compartNo;
    })[0]?.id;
    console.log(this.ChosenCoachID);
    this.ListChosenTickets=JSON.parse(localStorage.getItem('chosenTickets')||'[]');
    this.ListChosenTicketsSeatID=this.ListChosenTickets.map(chosen=> {return chosen.seatId}); 
    console.log(this.ListChosenTicketsSeatID);
    this.seats.forEach(ele=>{
      console.log(ele);
    });
    this.pHomeService.getAllSeats().subscribe({
      next: (data) => {
        this.ListSeat = data;
        this.isLoadCoach = true;
        this.ListSeat=this.ListSeat.filter(item => {
          return item.coachId==this.ChosenCoachID;
        });
        // this.ListSeatID=from(this.ListSeat);
        // this.ListSeatID=this.ListSeatID.pipe(map(seat=>{return seat.id;}));
        // this.ListSeatID.subscribe(result => {
        //   console.log(result); 
        // });
        if(JSON.parse(localStorage.getItem('ListSeat')||'')==''){
          localStorage.setItem('ListSeat', JSON.stringify(this.ListSeat));
        }
        this.ListSeat=JSON.parse(localStorage.getItem('ListSeat')||JSON.stringify(this.ListSeat));
        console.log(this.ListSeat);
        this.ListSeat.forEach(result =>{
          if(this.ListChosenTicketsSeatID.includes(result.id)){
            this.seats3AC[Number(result.seatNo.split('-')[1])] = false;
            this.bookedSeats3AC[Number(result.seatNo.split('-')[1])] = false;
            console.log("id:"+result.id);
          }
          else{
            this.bookedSeats3AC[Number(result.seatNo.split('-')[1])] = true;
          }
        });
        localStorage.setItem('bookedSeats', JSON.stringify(this.bookedSeats3AC));
        localStorage.setItem('seats3AC', JSON.stringify(this.seats3AC));
        this.seats3AC=JSON.parse(localStorage.getItem('seats3AC')||JSON.stringify(this.seats3AC));
        this.bookedSeats3AC=JSON.parse(localStorage.getItem('bookedSeats')||JSON.stringify(this.bookedSeats3AC));
      }
    });
    console.log("hello world");
    this.seats3AC=JSON.parse(localStorage.getItem('seats3AC')||JSON.stringify(this.seats3AC));

  }
  changeValue(element:number){
    this.seats[element]=!this.seats[element];
    localStorage.setItem('seats', JSON.stringify(this.seats));
  }
}
