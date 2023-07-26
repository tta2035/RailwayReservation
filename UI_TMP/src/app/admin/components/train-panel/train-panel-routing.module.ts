import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrainPanelComponent } from './train-panel.component';

const routes: Routes = [
  { path: '', component: TrainPanelComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TrainPanelRoutingModule { }
