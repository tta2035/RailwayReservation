import { Component, OnInit } from '@angular/core';
import { AdminService } from 'app/admin/services/admin.service';
import { DataService } from 'app/admin/services/data.service';

@Component({
  selector: 'app-ticket-panel',
  templateUrl: './ticket-panel.component.html',
  styleUrls: ['./ticket-panel.component.scss']
})
export class TicketPanelComponent implements OnInit {
  Tickets: Array<any> = [];
  isLoadTicket: boolean = false;

  constructor(
    private adminService: AdminService,
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    this.dataService.receivedTicket$.subscribe((value) => {
      this.Tickets = value;
      console.log(this.Tickets);
    })
  }
}
