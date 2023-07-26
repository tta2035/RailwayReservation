import { Component, OnInit } from '@angular/core';
import { AdminService } from 'app/admin/services/admin.service';
import { DataService } from 'app/admin/services/data.service';

@Component({
  selector: 'app-booking-panel',
  templateUrl: './booking-panel.component.html',
  styleUrls: ['./booking-panel.component.scss']
})
export class BookingPanelComponent implements OnInit {
  Bookings: Array<any> = [];
  isLoadBooking: boolean = false;

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    this.dataService.receivedBooking$.subscribe((value) => {
      this.Bookings = value;
      console.log(this.Bookings);
    })
  }
}
