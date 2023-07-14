import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs';
import { MatAutocompleteTrigger } from '@angular/material/autocomplete';
import { Router } from '@angular/router';
import { PHomeService } from '../../services/p-home.service';
import { TransferService } from '../../services/transfer.service';
@Component({
  selector: 'app-get-train',
  templateUrl: './get-train.component.html',
  styleUrls: ['./get-train.component.css']
})
export class GetTrainComponent implements OnInit {
  @ViewChild('datepicker') datepicker: ElementRef;
  @Output() sendMessage = new EventEmitter();
  minDate = new Date();
  maxDate = new Date(this.minDate.getFullYear(), 11, 31);
  dateLeave:string="";
  stationFrom: string;
  stationTo: string;
  newDate: Date;
  options: string[] = ['hello', 'world'];
  showSelections: boolean = true;
  myControl = new FormControl();
  filteredOptions: Observable<String[]>;

  isLoadStation: boolean = false;
  ListStation: Array<any> = [];
  
  selectecDestination: string = '';
  isLoadRoute: boolean = false;
  ListRoute: Array<any> = [];
  ListDestinationRoute: Array<any> = [];

  DepartureStationIdSelected: any;

  constructor(
    private observer: BreakpointObserver,
    private router: Router,
    private pHomeService: PHomeService,
    private transferService: TransferService
  ) { }


  ngOnInit(): void {
    this.pHomeService.getAllStationAndRoute()
      .subscribe({
        next: (res) => {
          this.ListRoute = res;
          this.isLoadRoute = true;
          console.log(this.ListRoute);
        }
      });

    this.pHomeService.getAllStation()
      .subscribe({
        next: (res) => {
          this.ListStation = res;
          this.isLoadStation = true;
          console.log(this.ListStation);
        }
      });

    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))
    );
  }

  lessthan: boolean = false;
  ngAfterViewInit() {
    this.observer.observe(['(max-width: 870px)'])
      .subscribe((res) => {
        if (res.matches) {
          this.lessthan = true;
        }
        else {
          this.lessthan = false;
        }
      });
  }

  selectDepartureStation(selected: any) {
    this.DepartureStationIdSelected = selected.value;
    console.log(this.DepartureStationIdSelected);

    this.ListDestinationRoute = this.ListRoute.filter(route => {
      return route.departureStation == this.DepartureStationIdSelected;
    });
    console.log(this.ListDestinationRoute);
  }

  selectDestinationStation(selected: any) {

    this.selectecDestination = selected.value;
    console.log(this.selectecDestination);
  }

  showDepartureTime(selected : any) {
    console.log(selected.value);
  }

  showDepartureTime(selected : any) {
    console.log(selected.value);
  }


  onSubmit() {
    console.log(this.newDate);
    this.transferService.setFrom(this.DepartureStationIdSelected);
    this.transferService.setTo(this.selectecDestination);
    localStorage.setItem('departureStationIdSelected', this.DepartureStationIdSelected);
    localStorage.setItem('selectecDestination',this.selectecDestination);
    this.transferService.setDateLeaveDate(this.newDate.getDate().toString());
    this.transferService.setDateLeaveMonth(this.newDate.getMonth().toString());
    this.transferService.setDateLeaveYear(this.newDate.getFullYear().toString());
    localStorage.setItem('dateLeaveDate', this.newDate.getDate().toString());
    localStorage.setItem('dateLeaveMonth', String(Number(this.newDate.getMonth().toString())+1));
    localStorage.setItem('dateLeaveYear', this.newDate.getFullYear().toString());
    this.gotoTrainDetails();
  }

  private _filter(value: String): String[] {
    const filteredValue = value.toLowerCase();
    let options2: String[] = [];
    if (!this.showSelections) {
      options2 = this.options.filter(option => option.toLowerCase().includes(filteredValue));
    }
    else {
      options2 = []
    }
    return options2;
  }
  onInputChange() {
    if (this.stationFrom.length > 1) {
      this.showSelections = false;
    }
    else {
      this.showSelections = true;
    }
  }
  gotoTrainDetails() {
    this.router.navigate(['passenger/train-details']);
  }
}