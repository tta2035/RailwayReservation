import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ATripComponent } from './a-trip.component';

describe('ATripComponent', () => {
  let component: ATripComponent;
  let fixture: ComponentFixture<ATripComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ATripComponent]
    });
    fixture = TestBed.createComponent(ATripComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
