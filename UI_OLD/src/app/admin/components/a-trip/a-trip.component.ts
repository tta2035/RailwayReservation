import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../../services/admin.service';
import { DataService } from '../../services/data.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-a-trip',
  templateUrl: './a-trip.component.html',
  styleUrls: ['./a-trip.component.css']
})
export class ATripComponent implements OnInit {

  Trips: Array<any> = [];
  Stations: Array<any> = [];
  Routes: Array<any> = [];
  Trains: Array<any> = [];
  isLoadTrip: boolean = false;

  addForm!: FormGroup;
  editForm!: FormGroup;
  addDepartureStation: string = '';
  addDestinationStation: string = '';

  modalRef: any;

  constructor(
    private router: Router,
    private adminService: AdminService,
    private dataService: DataService,
    private modalService: NgbModal,
    private fb: FormBuilder,
    private toast: NgToastService
  ) {

  }
  ngOnInit(): void {
    this.receivedTrip();
    this.receivedRoute();
    this.receivedStation();
    this.receivedTrain();

    this.addForm = this.fb.group({ 
      RouteId: ['', Validators.required],
      TrainId: ['', Validators.required],
      DepartureTime: ['', Validators.required],
      ArriveTime: ['', Validators.required],
      Description: [''],
      CreateBy: [null],
      CreateTime: [new Date()]
    });
  }

  showAddModal(modal: any) {
    this.modalRef = this.modalService.open(modal, { ariaLabelledBy: 'modal-basic-title' })
  }

  departureDateTime: string;
  formatDateTime(dateTime: string): string {
    return dateTime ? dateTime.slice(0, 16) : '';
  }

  onDateTimeChange(dateTime: any): void {
    console.log(dateTime.value);
  }

  showTripDetail(modal: any, trip: any) {

  }

  resetAddForm() {

  }

  resetEditForm() {

  }

  addTrip() {
    console.log(this.addForm.value);
  }

  editRoute() {

  }

  receivedTrip() {
    this.dataService.receivedTrip$.subscribe((value) => {
      this.Trips = value;
      this.isLoadTrip = true;
      console.log("Trips: ", this.Trips);
    })
  }

  receivedRoute() {
    this.dataService.receivedRoute$.subscribe((value) => {
      this.Routes = value;
      console.log("Route: ", this.Routes);
    })
  }

  receivedStation() {
    this.dataService.receivedStation$.subscribe((value) => {
      this.Stations = value;
      console.log("Station: ", this.Stations);
    })
  }

  receivedTrain() {
    this.dataService.receivedTrain$.subscribe((value) => {
      this.Trains = value;
      console.log("Train: ", this.Trains);
    })
  }

}
