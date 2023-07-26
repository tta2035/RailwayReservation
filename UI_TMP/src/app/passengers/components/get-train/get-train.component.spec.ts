import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTrainComponent } from './get-train.component';

describe('GetTrainComponent', () => {
  let component: GetTrainComponent;
  let fixture: ComponentFixture<GetTrainComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetTrainComponent]
    });
    fixture = TestBed.createComponent(GetTrainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
