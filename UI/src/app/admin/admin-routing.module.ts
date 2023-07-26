import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { TableListComponent } from './components/table-list/table-list.component';
import { TypographyComponent } from './components/typography/typography.component';
import { IconsComponent } from './components/icons/icons.component';
import { MapsComponent } from './components/maps/maps.component';
import { NotificationsComponent } from './components/notifications/notifications.component';
import { UpgradeComponent } from './components/upgrade/upgrade.component';
import { NgModule } from '@angular/core';
import { AdminComponent } from './admin.component';
import { CommonModule } from '@angular/common';
import { TripPanelComponent } from './components/trip-panel/trip-panel.component';
import { TicketPanelComponent } from './components/ticket-panel/ticket-panel.component';
import { BookingPanelComponent } from './components/booking-panel/booking-panel.component';
import { RoutePanelComponent } from './components/route-panel/route-panel.component';
import { StationPanelComponent } from './components/station-panel/station-panel.component';
import { TrainPanelComponent } from './components/train-panel/train-panel.component';
import { SeatTypePanelComponent } from './components/seat-type-panel/seat-type-panel.component';

const routes: Routes = [
    // { path: '', loadChildren: () => import('../admin/admin.module').then(m => m.AdminModule)},
    {
        path: '', component: AdminComponent, pathMatch: 'prefix',
        children: [
            { path: '', redirectTo: 'station-panel', pathMatch: 'full' },
            { path: 'dashboard', loadChildren: () => import('./components/dashboard/dashboard.module').then(m => m.DashboardModule) },
            { path: 'user-profile', loadChildren: () => import('./components/user-profile/user-profile.module').then(m => m.UserProfileModule) },
            { path: 'trip-panel', loadChildren: () => import('./components/trip-panel/trip-panel.module').then(m => m.TripPanelModule) },
            { path: 'ticket-panel', loadChildren: () => import('./components/ticket-panel/ticket-panel.module').then(m => m.TicketPanelModule) },
            { path: 'booking-panel', loadChildren: () => import('./components/booking-panel/booking-panel.module').then(m => m.BookingPanelModule) },
            { path: 'route-panel', loadChildren: () => import('./components/route-panel/route-panel.module').then(m => m.RoutePanelModule) },
            { path: 'station-panel', loadChildren: () => import('./components/station-panel/station-panel.module').then(m => m.StationPanelModule) },
            { path: 'train-panel', loadChildren: () => import('./components/train-panel/train-panel.module').then(m => m.TrainPanelModule) },
            { path: 'seat-type-panel', loadChildren: () => import('./components/seat-type-panel/seat-type-panel.module').then(m => m.SeatTypePanelModule) },
        ]
    },
];

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})
export class AdminRoutingModule { }
