import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-a-station',
  templateUrl: './a-station.component.html',
  styleUrls: ['./a-station.component.css']
})
export class AStationComponent implements OnInit {

  Stations: Array<any> = [];
  isLoadStation: boolean = false;

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) { }
  ngOnInit(): void {
    this.dataService.receivedStation$.subscribe((value) => {
      this.Stations = value;
      console.log(this.Stations);
    })
  }
}
