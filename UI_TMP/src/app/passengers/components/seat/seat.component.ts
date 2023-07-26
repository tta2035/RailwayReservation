import { Component, OnInit, ViewChild, ElementRef, QueryList, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { PHomeService } from '../../services/p-home.service';
import { TransferService } from '../../services/transfer.service';
import { Observable, from, map } from 'rxjs';
@Component({
  selector: 'app-seat',
  templateUrl: './seat.component.html',
  styleUrls: ['./seat.component.css']
})
export class SeatComponent implements OnInit {
  // @ViewChild("seats") seats: ElementRef;
  constructor(private router:Router,private pHomeService:PHomeService,private transferService:TransferService ){

  }
  ngOnInit(): void {
    
  }
  btnStyle: string;
  seats = Array(61).fill(true);
  chosenSeat:number[]=[];
  
  navToBuyTicket(){
    let i:number=1;
    this.seats.forEach(ele=>{
      if(!ele)
        {
          this.chosenSeat.push(i);
          console.log(i);
        }
      i+=1;
    });
    this.router.navigate(['passenger/tickets']);
  }
  compart1Chosen(){
    console.log('passenger/seat/'+localStorage.getItem('trainName')+'/compart1');
    this.router.navigate(['passenger/seat/'+localStorage.getItem('trainName')+'/compart1']);
  }
  compart2Chosen(){
    this.router.navigate(['passenger/seat/'+localStorage.getItem('trainName')+'/compart2']);
  }
  compart3Chosen(){
    this.router.navigate(['passenger/seat/'+localStorage.getItem('trainName')+'/compart3']);
  }
  compart4Chosen(){
    this.router.navigate(['passenger/seat/'+localStorage.getItem('trainName')+'/compart4']);
  }
  compart5Chosen(){
    this.router.navigate(['passenger/seat/'+localStorage.getItem('trainName')+'/compart5']);
  }
  // changeSeat(){
  //   console.log(this.seats.nativeElement.innerHTML);
  // }
  // ngAfterViewInit() {
  //   // Access the elements using changes property of QueryList
  //   this.seats.changes.subscribe(elements => {
  //     console.log(elements.toArray());
  //   });
  // }
}
