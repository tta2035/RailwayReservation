import { Component, OnInit } from '@angular/core';
import { AdminService } from 'app/admin/services/admin.service';
import { DataService } from 'app/admin/services/data.service';

@Component({
  selector: 'app-route-panel',
  templateUrl: './route-panel.component.html',
  styleUrls: ['./route-panel.component.scss']
})
export class RoutePanelComponent implements OnInit {
  Routes: Array<any> = [];
  isLoadRoute: boolean = false;

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    this.dataService.receivedRoute$.subscribe((value) => {
      this.Routes = value;
      console.log(this.Routes);
    })
  }
}
