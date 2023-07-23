import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AStationComponent } from './a-station.component';

describe('AStationComponent', () => {
  let component: AStationComponent;
  let fixture: ComponentFixture<AStationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AStationComponent]
    });
    fixture = TestBed.createComponent(AStationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
