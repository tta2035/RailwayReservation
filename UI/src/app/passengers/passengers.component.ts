import { Component, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';
import { MatDialog } from '@angular/material/dialog';
import { GetTrainComponent } from './components/get-train/get-train.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-passengers',
  templateUrl: './passengers.component.html',
  styleUrls: ['./passengers.component.css']
})
export class PassengersComponent {
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  constructor(
    private observer: BreakpointObserver,
    private dialog: MatDialog,
    private router: Router
  ) { }
  ngOnInit() {
    if (this.router.url == '/passenger/home' || this.router.url == '' || this.router.url == '/passenger') {
      this.router.navigate(['/passenger/home']);
    }
  }
  lessthan: boolean = false;
  ngAfterViewInit() {
    this.observer.observe(['(max-width: 870px)'])
      .subscribe((res) => {
        if (res.matches) {
          this.lessthan = true;
        }
        else {
          this.lessthan = false;
          this.sidenav.close();
        }
      });
  }
  openDialog() {
    this.dialog.open(GetTrainComponent, {
      height: '50%',
      width: '75%'
    });
  }

  gotoTrainDetails(){
    this.router.navigate(['passenger/home']);
  }
}
