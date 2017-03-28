/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ZenithSocietyService } from './zenith-society.service';

describe('ZenithSocietyService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ZenithSocietyService]
    });
  });

  it('should ...', inject([ZenithSocietyService], (service: ZenithSocietyService) => {
    expect(service).toBeTruthy();
  }));
});
