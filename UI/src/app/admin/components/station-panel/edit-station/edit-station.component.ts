import { Component } from '@angular/core';
import { SharedModule } from 'app/shared/shared.module';

@Component({
  selector: 'app-edit-station',
  templateUrl: './edit-station.component.html',
  styleUrls: ['./edit-station.component.scss'],
  standalone: true,
  imports: [SharedModule]
})
export class EditStationComponent {

}
