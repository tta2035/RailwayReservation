import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ATT003Component } from './at-t003.component';

describe('ATT003Component', () => {
  let component: ATT003Component;
  let fixture: ComponentFixture<ATT003Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ATT003Component]
    });
    fixture = TestBed.createComponent(ATT003Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
