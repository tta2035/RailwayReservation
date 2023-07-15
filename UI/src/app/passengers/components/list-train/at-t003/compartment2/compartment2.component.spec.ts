import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Compartment2Component } from './compartment2.component';

describe('Compartment2Component', () => {
  let component: Compartment2Component;
  let fixture: ComponentFixture<Compartment2Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Compartment2Component]
    });
    fixture = TestBed.createComponent(Compartment2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
