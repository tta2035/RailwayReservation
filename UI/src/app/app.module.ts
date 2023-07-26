import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PassengersModule } from './passengers/passengers.module';
import { SharedModule } from './shared/shared.module';
import { MaterialModule } from './material/material.module';
import { AdminModule } from './admin/admin.module';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    AppRoutingModule,
    PassengersModule,
    AdminModule,
    MaterialModule,
    SharedModule,
  ],
  declarations: [
    AppComponent,
    // AdminComponent,
    // SidebarComponent,
    // NavbarComponent,
    // FooterComponent,
    // DashboardComponent,
    
    // UserProfileComponent,
    // TableListComponent,
    // TypographyComponent,
    // IconsComponent,
    // MapsComponent,
    // NotificationsComponent,
    // UpgradeComponent,

    // TripPanelComponent,
    // TicketPanelComponent,
    // BookingPanelComponent,
    // RoutePanelComponent,
    // TrainPanelComponent,
    // StationPanelComponent,
    // SeatTypePanelComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
