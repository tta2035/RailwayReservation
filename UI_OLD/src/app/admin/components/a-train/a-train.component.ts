import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-a-train',
  templateUrl: './a-train.component.html',
  styleUrls: ['./a-train.component.css']
})
export class ATrainComponent implements OnInit{

  Trains: Array<any> = [];
  isLoadTrain: boolean = false;
  SeatTypes: Array<any> = [];

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) { }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
}
