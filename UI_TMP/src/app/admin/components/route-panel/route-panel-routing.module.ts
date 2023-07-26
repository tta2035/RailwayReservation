import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoutePanelComponent } from './route-panel.component';

const routes: Routes = [
  { path: '', component: RoutePanelComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoutePanelRoutingModule { }
