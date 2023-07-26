import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SeatTypePanelComponent } from './seat-type-panel.component';

const routes: Routes = [
  { path: '', component: SeatTypePanelComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SeatTypePanelRoutingModule { }
