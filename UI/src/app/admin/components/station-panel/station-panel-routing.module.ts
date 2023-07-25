import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StationPanelComponent } from './station-panel.component';

const routes: Routes = [
  { path: '', component: StationPanelComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StationPanelRoutingModule { }
