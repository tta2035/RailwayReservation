import { TestBed } from '@angular/core/testing';

import { PTripService } from './p-trip.service';

describe('PTripService', () => {
  let service: PTripService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PTripService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
