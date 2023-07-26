import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Compartment1Component } from './compartment1.component';

describe('Compartment1Component', () => {
  let component: Compartment1Component;
  let fixture: ComponentFixture<Compartment1Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Compartment1Component]
    });
    fixture = TestBed.createComponent(Compartment1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
