import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PassengerPanelComponent } from './passenger-panel.component';

describe('PassengerPanelComponent', () => {
  let component: PassengerPanelComponent;
  let fixture: ComponentFixture<PassengerPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PassengerPanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PassengerPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
