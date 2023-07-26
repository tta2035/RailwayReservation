import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ATT005Component } from './at-t005.component';

describe('ATT005Component', () => {
  let component: ATT005Component;
  let fixture: ComponentFixture<ATT005Component>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ATT005Component]
    });
    fixture = TestBed.createComponent(ATT005Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
