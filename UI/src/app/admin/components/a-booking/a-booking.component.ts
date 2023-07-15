import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-a-booking',
  templateUrl: './a-booking.component.html',
  styleUrls: ['./a-booking.component.css']
})
export class ABookingComponent implements OnInit {

  isLoadBooking: boolean = false;
  Bookings: Array<any> = [];

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) { }
  
  ngOnInit(): void {
    this.dataService.receivedBooking$.subscribe((value) => {
      this.Bookings = value;
      console.log(this.Bookings);
    })
  }

}
