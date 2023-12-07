import { TestBed } from '@angular/core/testing';

import { PainelAreaService } from './painel-area.service';

describe('PainelAreaService', () => {
  let service: PainelAreaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PainelAreaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
