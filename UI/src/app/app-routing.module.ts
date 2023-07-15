import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ALoginComponent } from './admin/components/a-login/a-login.component';
import { AdminComponent } from './admin/admin.component';
import { AStationComponent } from './admin/components/a-station/a-station.component';
import { ADashboardComponent } from './admin/components/a-dashboard/a-dashboard.component';
import { ATicketComponent } from './admin/components/a-ticket/a-ticket.component';
import { ATrainComponent } from './admin/components/a-train/a-train.component';
import { ATripComponent } from './admin/components/a-trip/a-trip.component';
import { ARouteComponent } from './admin/components/a-route/a-route.component';
import { ABookingComponent } from './admin/components/a-booking/a-booking.component';
import { SeatTypeComponent } from './admin/components/seat-type/seat-type.component';
import { APassengerComponent } from './admin/components/a-passenger/a-passenger.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'passenger' },
  {
    path: 'admin', component: AdminComponent, pathMatch: 'prefix',
    children: [
      { path: '', component: ADashboardComponent, pathMatch: 'prefix'},
      { path: 'station', component: AStationComponent, pathMatch: 'full'},
      { path: 'dashboard', component: ADashboardComponent, pathMatch: 'full'},
      { path: 'ticket', component: ATicketComponent, pathMatch: 'full'},
      { path: 'train', component: ATrainComponent, pathMatch: 'full'},
      { path: 'trip', component: ATripComponent, pathMatch: 'full'},
      { path: 'route', component: ARouteComponent, pathMatch: 'full'},
      { path: 'booking', component: ABookingComponent, pathMatch: 'full'},
      { path: 'seat-type', component: SeatTypeComponent, pathMatch: 'full'},
      { path: 'passenger', component: APassengerComponent, pathMatch: 'full'},
    ]
  },
  { path: 'admin/login', component: ALoginComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
