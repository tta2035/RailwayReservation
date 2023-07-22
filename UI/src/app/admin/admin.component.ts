import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AdminService } from './services/admin.service';
import { DataService } from './services/data.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  @ViewChild('dropdownMenu') dropdownMenu!: ElementRef;
  dropdownStates: { [key: string]: boolean } = {};

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) { }
  ngOnInit(): void {

    this.getAllBooking();
    this.getAllDashboard();
    // this.getAllPassenger();
    this.getAllRoute();
    this.getAllStation();
    this.getAllTicket();
    this.getAllTrain();
    this.getAllTrip();
    this.getAllSeatType();

  }

  getAllBooking() {
    this.adminService.getAllBooking()
      .subscribe({
        next: (data) => {
          this.dataService.sendBooking(data);
        }
      })
  }

  getAllDashboard() {
    // this.adminService.getAllBooking
  }

  getAllPassenger() {
    this.adminService.getAllPassenger()
      .subscribe({
        next: (data) => {
          this.dataService.sendPassenger(data);
        }
      })
  }

  getAllRoute() {
    this.adminService.getAllRoute()
      .subscribe({
        next: (data) => {
          this.dataService.sendRoute(data);
        }
      })
  }

  getAllStation() {
    this.adminService.getAllStation()
      .subscribe({
        next: (data) => {
          this.dataService.sendStation(data);
        }
      })
  }

  getAllTicket() {
    this.adminService.getAllTicket()
      .subscribe({
        next: (data) => {
          this.dataService.sendTicket(data);
        }
      })
  }

  getAllTrain() {
    this.adminService.getAllTrain()
      .subscribe({
        next: (data) => {
          this.dataService.sendTrain(data);
        }
      })
  }

  getAllTrip() {
    this.adminService.getAllTrip()
      .subscribe({
        next: (data) => {
          this.dataService.sendTrip(data);
        }
      })
  }

  getAllSeatType() {
    this.adminService.getAllSeatType()
      .subscribe({
        next: (data) => {
          this.dataService.sendSeatType(data);
        }
      })
  }


  toggleDropdown(dropdownId: string) {
    this.dropdownStates[dropdownId] = !this.dropdownStates[dropdownId];
  }

  
}
