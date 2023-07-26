import { Component, OnInit } from '@angular/core';
import { AdminService } from 'app/admin/services/admin.service';
import { DataService } from 'app/admin/services/data.service';

@Component({
  selector: 'app-trip-panel',
  templateUrl: './trip-panel.component.html',
  styleUrls: ['./trip-panel.component.scss']
})
export class TripPanelComponent implements OnInit {
  Trips: Array<any> = [];
  isLoadTrips: boolean = false;

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    this.dataService.receivedTrip$.subscribe((value) => {
      this.Trips = value;
      console.log(this.Trips);
    })
  }
}
