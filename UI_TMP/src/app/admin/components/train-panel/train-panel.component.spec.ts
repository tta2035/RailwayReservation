import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainPanelComponent } from './train-panel.component';

describe('TrainPanelComponent', () => {
  let component: TrainPanelComponent;
  let fixture: ComponentFixture<TrainPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrainPanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
