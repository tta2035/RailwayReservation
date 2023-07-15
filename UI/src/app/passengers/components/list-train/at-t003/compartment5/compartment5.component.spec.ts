import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Compartment5Component } from './compartment5.component';

describe('Compartment5Component', () => {
  let component: Compartment5Component;
  let fixture: ComponentFixture<Compartment5Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Compartment5Component]
    });
    fixture = TestBed.createComponent(Compartment5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
