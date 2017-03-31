/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ZenithActivityService } from './zenith-activity.service';

describe('ZenithActivityService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ZenithActivityService]
    });
  });

  it('should ...', inject([ZenithActivityService], (service: ZenithActivityService) => {
    expect(service).toBeTruthy();
  }));
});
