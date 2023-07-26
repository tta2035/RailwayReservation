import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatTypePanelComponent } from './seat-type-panel.component';

describe('SeatTypePanelComponent', () => {
  let component: SeatTypePanelComponent;
  let fixture: ComponentFixture<SeatTypePanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeatTypePanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SeatTypePanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
