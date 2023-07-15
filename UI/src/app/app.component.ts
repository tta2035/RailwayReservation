import { Component, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';
import { MatDialog } from '@angular/material/dialog';
import { GetTrainComponent } from './passengers/components/get-train/get-train.component';
import { Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = "UI";
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  constructor(
    private observer: BreakpointObserver,
    private dialog: MatDialog,
    private router: Router) {

  }
  lessthan: boolean = false;
  openDialog() {
    this.dialog.open(GetTrainComponent, {
      height: '50%',
      width: '75%'
    });
  }
  gotoTrainDetails() {
    this.router.navigate(['']);
  }
}
