import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { GetTrainComponent } from './passengers/components/get-train/get-train.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './passengers/components/home/home.component';
import { TrainDetailsComponent } from './passengers/components/train-details/train-details.component';
import { PassengersModule } from './passengers/passengers.module';
import { AdminComponent } from './admin/admin.component';
import { AStationComponent } from './admin/components/a-station/a-station.component';
import { ADashboardComponent } from './admin/components/a-dashboard/a-dashboard.component';
import { ATicketComponent } from './admin/components/a-ticket/a-ticket.component';
import { ATrainComponent } from './admin/components/a-train/a-train.component';
import { ATripComponent } from './admin/components/a-trip/a-trip.component';
import { SharedModule } from './admin/shared/shared/shared.module';
import { CommonModule } from '@angular/common';
import { ABookingComponent } from './admin/components/a-booking/a-booking.component';
import { ALoginComponent } from './admin/components/a-login/a-login.component';
import { APassengerComponent } from './admin/components/a-passenger/a-passenger.component';
import { ARouteComponent } from './admin/components/a-route/a-route.component';
import { SeatTypeComponent } from './admin/components/seat-type/seat-type.component';
import { NgToastModule } from 'ng-angular-popup';
import { SidebarComponent } from './admin/components/sidebar/sidebar.component';
import { NavbarComponent } from './admin/components/navbar/navbar.component';
import { FooterComponent } from './admin/components/footer/footer.component';
@NgModule({
  declarations: [
    AppComponent,
    GetTrainComponent,
    HomeComponent,
    TrainDetailsComponent,
    AdminComponent,
    ABookingComponent,
    AStationComponent,
    ADashboardComponent,
    ALoginComponent,
    APassengerComponent,
    ARouteComponent,
    ATicketComponent,
    ATrainComponent,
    ATripComponent,
    SeatTypeComponent,
    SidebarComponent,
    NavbarComponent,
    FooterComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    PassengersModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

