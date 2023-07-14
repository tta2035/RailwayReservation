import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Compartment3Component } from './compartment3.component';

describe('Compartment3Component', () => {
  let component: Compartment3Component;
  let fixture: ComponentFixture<Compartment3Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Compartment3Component]
    });
    fixture = TestBed.createComponent(Compartment3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
