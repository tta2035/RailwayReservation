import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Compartment4Component } from './compartment4.component';

describe('Compartment4Component', () => {
  let component: Compartment4Component;
  let fixture: ComponentFixture<Compartment4Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Compartment4Component]
    });
    fixture = TestBed.createComponent(Compartment4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
