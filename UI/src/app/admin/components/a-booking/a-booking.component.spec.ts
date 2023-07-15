import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ABookingComponent } from './a-booking.component';

describe('ABookingComponent', () => {
  let component: ABookingComponent;
  let fixture: ComponentFixture<ABookingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ABookingComponent]
    });
    fixture = TestBed.createComponent(ABookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
