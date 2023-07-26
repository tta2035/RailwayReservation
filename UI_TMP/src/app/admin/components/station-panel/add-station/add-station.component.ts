import { Component } from '@angular/core';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { SharedModule } from 'app/shared/shared.module';

@Component({
  selector: 'app-add-station',
  templateUrl: './add-station.component.html',
  styleUrls: ['./add-station.component.scss'],
  standalone: true,
  imports: [SharedModule]
})
export class AddStationComponent {
  constructor(
    public dialogRef: MatDialogRef<AddStationComponent>
  ) {}
}
