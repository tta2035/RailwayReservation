import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PassengersRoutingModule } from './passengers-routing.module';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    PassengersRoutingModule
  ]
})
export class PassengersModule { }
