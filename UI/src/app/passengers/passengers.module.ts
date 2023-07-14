import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule } from '@angular/common/http';
import { PassengersRoutingModule } from './passengers-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../material/material.module';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { PassengersComponent } from './passengers.component';
import { TicketsComponent } from './components/tickets/tickets.component';
import { SeatComponent } from './components/seat/seat.component';
import { ATT003Component } from './components/list-train/at-t003/at-t003.component';
import { ATT005Component } from './components/list-train/at-t005/at-t005.component';
import { Compartment1Component } from './components/list-train/at-t003/compartment1/compartment1.component';
import { Compartment2Component } from './components/list-train/at-t003/compartment2/compartment2.component';
import { Compartment3Component } from './components/list-train/at-t003/compartment3/compartment3.component';
import { Compartment4Component } from './components/list-train/at-t003/compartment4/compartment4.component';
import { Compartment5Component } from './components/list-train/at-t003/compartment5/compartment5.component';
@NgModule({
  declarations: [
    PassengersComponent,
    TicketsComponent,
    SeatComponent,
    ATT003Component,
    ATT005Component,
    Compartment1Component,
    Compartment2Component,
    Compartment3Component,
    Compartment4Component,
    Compartment5Component,
  ],
  imports: [
    CommonModule,
    PassengersRoutingModule,
    MaterialModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports:[
    CommonModule,
    PassengersRoutingModule,
    MaterialModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  bootstrap:[PassengersComponent]
})
export class PassengersModule { }
