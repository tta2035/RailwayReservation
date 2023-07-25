import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { AdminService } from 'app/admin/services/admin.service';
import { DataService } from 'app/admin/services/data.service';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { Station } from 'app/admin/interface/station';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { AddStationComponent } from './add-station/add-station.component';

@Component({
  selector: 'app-station-panel',
  templateUrl: './station-panel.component.html',
  styleUrls: ['./station-panel.component.scss'],
})
export class StationPanelComponent implements OnInit, AfterViewInit  {

  Stations: Station[] = [];
  isLoadStation: boolean = false;

  // displayedColumns: string[] = ['stationName', 'description'];
  // dataSource = new MatTableDataSource<Station>(this.Stations);
  displayedColumns: string[] = ['stationName', 'description', 'edit'];
  dataSource = new MatTableDataSource<Station>(this.Stations);

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private adminService: AdminService,
    private dataService: DataService,
    public dialog: MatDialog
  ) {}
  ngAfterViewInit(): void {
    console.log("data in ngAfterView: ", this.Stations);
    this.dataSource.paginator = this.paginator;

    this.dataService.receivedStation$.subscribe((value) => {
      this.isLoadStation = true;
      this.Stations = value;
      this.dataSource.data = this.Stations;
      console.log(this.isLoadStation, this.Stations);
    })
  }

  openAddStationDialog(): void {
    console.log("thêm station mới thui");
    const addStationDialogRef = this.dialog.open(AddStationComponent);
    addStationDialogRef.afterClosed().subscribe(result => {
      console.log(result);
    });
  }

  ngOnInit(): void {
    
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}


