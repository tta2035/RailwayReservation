import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatTypeComponent } from './seat-type.component';

describe('SeatTypeComponent', () => {
  let component: SeatTypeComponent;
  let fixture: ComponentFixture<SeatTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SeatTypeComponent]
    });
    fixture = TestBed.createComponent(SeatTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
