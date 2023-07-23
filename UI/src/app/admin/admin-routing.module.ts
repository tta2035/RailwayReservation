import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { TableListComponent } from './table-list/table-list.component';
import { TypographyComponent } from './typography/typography.component';
import { IconsComponent } from './icons/icons.component';
import { MapsComponent } from './maps/maps.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { UpgradeComponent } from './upgrade/upgrade.component';
import { NgModule } from '@angular/core';
import { AdminComponent } from './admin.component';

const routes: Routes = [
    {
        path: '', component: AdminComponent, pathMatch: 'prefix',
        children: [
            { path: '', component: DashboardComponent, pathMatch: 'full' },
            { path: 'dashboard', component: DashboardComponent, pathMatch: 'full' },
            { path: 'user-profile', component: UserProfileComponent, pathMatch: 'full' },
            { path: 'table-list', component: TableListComponent, pathMatch: 'full' },
            { path: 'typography', component: TypographyComponent, pathMatch: 'full' },
            { path: 'icons', component: IconsComponent, pathMatch: 'full' },
            { path: 'maps', component: MapsComponent, pathMatch: 'full' },
            { path: 'notifications', component: NotificationsComponent, pathMatch: 'full' },
            { path: 'upgrade', component: UpgradeComponent, pathMatch: 'full' },
        ]
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }
