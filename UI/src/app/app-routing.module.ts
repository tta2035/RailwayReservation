import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { UserProfileComponent } from './admin/components/user-profile/user-profile.component';
import { TableListComponent } from './admin/components/table-list/table-list.component';
import { TypographyComponent } from './admin/components/typography/typography.component';
import { IconsComponent } from './admin/components/icons/icons.component';
import { MapsComponent } from './admin/components/maps/maps.component';
import { NotificationsComponent } from './admin/components/notifications/notifications.component';
import { UpgradeComponent } from './admin/components/upgrade/upgrade.component';
import { TripPanelComponent } from './admin/components/trip-panel/trip-panel.component';
import { TicketPanelComponent } from './admin/components/ticket-panel/ticket-panel.component';
import { BookingPanelComponent } from './admin/components/booking-panel/booking-panel.component';
import { RoutePanelComponent } from './admin/components/route-panel/route-panel.component';
import { StationPanelComponent } from './admin/components/station-panel/station-panel.component';
import { TrainPanelComponent } from './admin/components/train-panel/train-panel.component';
import { SeatTypePanelComponent } from './admin/components/seat-type-panel/seat-type-panel.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'passenger' },
  { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)},
  // {
  //   path: 'admin', component: AdminComponent,
  //   children: [
  //     { path: '', redirectTo: 'station-panel', pathMatch: 'full' },
  //     { path: 'dashboard', component: DashboardComponent, },
  //     { path: 'user-profile', component: UserProfileComponent, },
  //     { path: 'trip-panel', component: TripPanelComponent, },
  //     { path: 'ticket-panel', component: TicketPanelComponent, },
  //     { path: 'booking-panel', component: BookingPanelComponent, },
  //     { path: 'route-panel', component: RoutePanelComponent, },
  //     { path: 'station-panel', component: StationPanelComponent, },
  //     { path: 'train-panel', component: TrainPanelComponent, },
  //     { path: 'seat-type-panel', component: SeatTypePanelComponent, },
  // ]
  // },
  { path: 'admin/login' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
})
export class AppRoutingModule { }
