import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ARouteComponent } from './a-route.component';

describe('ARouteComponent', () => {
  let component: ARouteComponent;
  let fixture: ComponentFixture<ARouteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ARouteComponent]
    });
    fixture = TestBed.createComponent(ARouteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
