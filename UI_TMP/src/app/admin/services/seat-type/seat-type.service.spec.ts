import { TestBed } from '@angular/core/testing';

import { SeatTypeService } from './seat-type.service';

describe('SeatTypeService', () => {
  let service: SeatTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SeatTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
