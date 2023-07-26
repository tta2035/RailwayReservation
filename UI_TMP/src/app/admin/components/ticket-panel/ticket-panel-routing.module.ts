import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TicketPanelComponent } from './ticket-panel.component';

const routes: Routes = [
  { path: '', component: TicketPanelComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TicketPanelRoutingModule { }
