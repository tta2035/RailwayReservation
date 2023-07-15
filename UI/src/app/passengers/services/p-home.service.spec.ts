import { TestBed } from '@angular/core/testing';

import { PHomeService } from './p-home.service';

describe('PHomeService', () => {
  let service: PHomeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PHomeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
