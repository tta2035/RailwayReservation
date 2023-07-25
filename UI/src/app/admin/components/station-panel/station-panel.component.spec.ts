import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StationPanelComponent } from './station-panel.component';

describe('StationPanelComponent', () => {
  let component: StationPanelComponent;
  let fixture: ComponentFixture<StationPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StationPanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StationPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
