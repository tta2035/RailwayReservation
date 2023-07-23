import { Component } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-a-ticket',
  templateUrl: './a-ticket.component.html',
  styleUrls: ['./a-ticket.component.css']
})
export class ATicketComponent {
  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) { }
}
