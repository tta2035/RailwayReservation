import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { TrainDetailsComponent } from './components/train-details/train-details.component';
import { PassengersComponent } from './passengers.component';
import { SeatComponent } from './components/seat/seat.component';
import { TicketsComponent } from './components/tickets/tickets.component';
import { ATT003Component } from './components/list-train/at-t003/at-t003.component';
import { Compartment1Component } from './components/list-train/at-t003/compartment1/compartment1.component';
import { Compartment2Component } from './components/list-train/at-t003/compartment2/compartment2.component';
import { Compartment3Component } from './components/list-train/at-t003/compartment3/compartment3.component';
import { Compartment4Component } from './components/list-train/at-t003/compartment4/compartment4.component';
import { Compartment5Component } from './components/list-train/at-t003/compartment5/compartment5.component';

const routes: Routes = [
  {
    path: 'passenger', component: PassengersComponent, children: [
      { path: 'home', component: HomeComponent },
      { path: 'train-details', component: TrainDetailsComponent },
      { path: 'seat', component: SeatComponent,children:[
        {path:'at-003',component:ATT003Component,children:[
          {path:'compart1',component:Compartment1Component},
          {path:'compart2',component:Compartment2Component},
          {path:'compart3',component:Compartment3Component},
          {path:'compart4',component:Compartment4Component},
          {path:'compart5',component:Compartment5Component}
        ]}
      ] },
      {path:'tickets', component: TicketsComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PassengersRoutingModule { }
