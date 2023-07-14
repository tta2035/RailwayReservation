import { Component } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-a-passenger',
  templateUrl: './a-passenger.component.html',
  styleUrls: ['./a-passenger.component.css']
})
export class APassengerComponent {
  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) { }
}
