import { Component } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-seat-type',
  templateUrl: './seat-type.component.html',
  styleUrls: ['./seat-type.component.css']
})
export class SeatTypeComponent {
  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) { }
}
