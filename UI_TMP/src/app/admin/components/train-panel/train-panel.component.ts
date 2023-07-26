import { Component, OnInit } from '@angular/core';
import { AdminService } from 'app/admin/services/admin.service';
import { DataService } from 'app/admin/services/data.service';

@Component({
  selector: 'app-train-panel',
  templateUrl: './train-panel.component.html',
  styleUrls: ['./train-panel.component.scss']
})
export class TrainPanelComponent implements OnInit {
  Trains: Array<any> = [];
  isLoadTrain: boolean = false;

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    this.dataService.receivedTrain$.subscribe((value) => {
      this.Trains = value;
      console.log(this.Trains);
    })
  }
}
