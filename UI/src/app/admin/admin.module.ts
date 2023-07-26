import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from 'app/shared/shared.module';
import { AdminComponent } from './admin.component';
import { SidebarComponent } from './components/layout/sidebar/sidebar.component';
import { NavbarComponent } from './components/layout/navbar/navbar.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { TableListComponent } from './components/table-list/table-list.component';
import { TypographyComponent } from './components/typography/typography.component';
import { IconsComponent } from './components/icons/icons.component';
import { MapsComponent } from './components/maps/maps.component';
import { NotificationsComponent } from './components/notifications/notifications.component';
import { UpgradeComponent } from './components/upgrade/upgrade.component';
import { TripPanelComponent } from './components/trip-panel/trip-panel.component';
import { TicketPanelComponent } from './components/ticket-panel/ticket-panel.component';
import { BookingPanelComponent } from './components/booking-panel/booking-panel.component';
import { RoutePanelComponent } from './components/route-panel/route-panel.component';
import { TrainPanelComponent } from './components/train-panel/train-panel.component';
import { StationPanelComponent } from './components/station-panel/station-panel.component';
import { SeatTypePanelComponent } from './components/seat-type-panel/seat-type-panel.component';

@NgModule({
  
  declarations: [
    AdminComponent,
    SidebarComponent,
    NavbarComponent,
    FooterComponent,
    DashboardComponent,
    
    UserProfileComponent,
    TableListComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
    UpgradeComponent,

    TripPanelComponent,
    TicketPanelComponent,
    BookingPanelComponent,
    RoutePanelComponent,
    TrainPanelComponent,
    StationPanelComponent,
    SeatTypePanelComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule,
  ],
})

export class AdminModule {}
