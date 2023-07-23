import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ATrainComponent } from './a-train.component';

describe('ATrainComponent', () => {
  let component: ATrainComponent;
  let fixture: ComponentFixture<ATrainComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ATrainComponent]
    });
    fixture = TestBed.createComponent(ATrainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
