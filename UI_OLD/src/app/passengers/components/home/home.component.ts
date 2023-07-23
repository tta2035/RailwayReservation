import { Component, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';
import { MatDialog } from '@angular/material/dialog';
import { GetTrainComponent } from '../get-train/get-train.component';
import { PHomeService } from '../../services/p-home.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  

  lessthan: boolean = false;
  constructor(
    private pHomeService: PHomeService,
    private observer: BreakpointObserver,
    public dialog: MatDialog
  ) {
  }
  ngOnInit(): void {
    
  }
  ngAfterViewInit() {
    this.observer.observe(['(max-width: 870px)'])
      .subscribe((res) => {
        if (res.matches) {
          this.lessthan = true;
        }
        else {
          this.lessthan = false;
        }
      });
  }
  openDialog() {
    let dialogRef = this.dialog.open(GetTrainComponent, {
      height: '50%',
      width: '75%'
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('${result}');
    });
  }
}
