import { ComponentFixture, TestBed } from '@angular/core/testing';

import { APassengerComponent } from './a-passenger.component';

describe('APassengerComponent', () => {
  let component: APassengerComponent;
  let fixture: ComponentFixture<APassengerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [APassengerComponent]
    });
    fixture = TestBed.createComponent(APassengerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
