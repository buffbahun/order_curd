import { TestBed } from '@angular/core/testing';

import { UpdateOrderService } from './update-order.service';

describe('UpdateOrderService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UpdateOrderService = TestBed.get(UpdateOrderService);
    expect(service).toBeTruthy();
  });
});
