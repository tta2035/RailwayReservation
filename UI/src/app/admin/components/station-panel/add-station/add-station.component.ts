import { Component, OnInit, Inject, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Station } from 'app/admin/interface/station';
import { StationService } from 'app/admin/services/station/station.service';
import { SharedModule } from 'app/shared/shared.module';

@Component({
  selector: 'app-add-station',
  templateUrl: './add-station.component.html',
  styleUrls: ['./add-station.component.scss'],
  standalone: true,
  imports: [SharedModule]
})
export class AddStationComponent implements OnInit {

  addStationForm!: FormGroup;
  isNewStationExist: boolean = false;
  @Output() onDataAdded: EventEmitter<void> = new EventEmitter<void>();

  constructor(
    @Inject(MAT_DIALOG_DATA) private stations: Station[],
    public dialogRef: MatDialogRef<AddStationComponent>,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private stationService: StationService
  ) { }
  ngOnInit(): void {
    console.log("Station data nhận từ cha: ", this.stations);
    this.addStationForm = this.fb.group({
      stationName: ['', Validators.required],
      description: ['']
    })
  }

  changeStationName(data: any) {
    console.log("enter station: ", data);

    // kiểm tra station này đã tồn tại nay chưa
    var findStation = this.stations.find(item => {
      return item.stationName == this.addStationForm.value.stationName;
    });
    if (findStation) {
      console.log("Station đã tồn tại: ", findStation);
      this.isNewStationExist = true;
    } else {
      this.isNewStationExist = false;
    }
  }
  addStationSubmit() {
    
    if (this.addStationForm.valid) {
      console.log("form hợp lệ: ", this.addStationForm.value);

      if (!this.isNewStationExist)  {
        this.stationService.addStation(this.addStationForm.value)
          .subscribe({
            next: (res) => {
              this.dialogRef.close();
              this.snackBar.open('Add New Station Success!', '', {
                duration: 5000,
                panelClass: 'success-snackbar',
                verticalPosition: 'top',
              });
            },
            error: (err) => {
              this.snackBar.open('Error occurred!', '', {
                duration: 5000,
                panelClass: 'error-snackbar',
                verticalPosition: 'top',
              });
            }
          })
      }
    }
  }
}
