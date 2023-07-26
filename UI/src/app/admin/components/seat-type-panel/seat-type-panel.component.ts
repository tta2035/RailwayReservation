import { Component, OnInit } from '@angular/core';
import { AdminService } from 'app/admin/services/admin.service';
import { DataService } from 'app/admin/services/data.service';

@Component({
  selector: 'app-seat-type-panel',
  templateUrl: './seat-type-panel.component.html',
  styleUrls: ['./seat-type-panel.component.scss']
})
export class SeatTypePanelComponent implements OnInit {
  SeatTypes: Array<any> = [];
  isLoadSeatType: boolean = false;

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    this.dataService.receivedSeatType$.subscribe((value) => {
      this.SeatTypes = value;
      console.log(this.SeatTypes);
    })
  }
}
