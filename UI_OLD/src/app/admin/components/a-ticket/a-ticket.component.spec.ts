import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ATicketComponent } from './a-ticket.component';

describe('ATicketComponent', () => {
  let component: ATicketComponent;
  let fixture: ComponentFixture<ATicketComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ATicketComponent]
    });
    fixture = TestBed.createComponent(ATicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
