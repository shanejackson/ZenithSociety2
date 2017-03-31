/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ZenithAccountService } from './zenith-account.service';

describe('ZenithAccountService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ZenithAccountService]
    });
  });

  it('should ...', inject([ZenithAccountService], (service: ZenithAccountService) => {
    expect(service).toBeTruthy();
  }));
});
