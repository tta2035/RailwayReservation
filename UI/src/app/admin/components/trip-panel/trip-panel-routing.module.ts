import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TripPanelComponent } from './trip-panel.component';

const routes: Routes = [
  { path: '', component: TripPanelComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TripPanelRoutingModule { }
