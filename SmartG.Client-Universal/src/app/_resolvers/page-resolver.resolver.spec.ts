import { TestBed } from '@angular/core/testing';

import { PageResolverResolver } from './page-resolver.resolver';

describe('PageResolverResolver', () => {
  let resolver: PageResolverResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(PageResolverResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});
