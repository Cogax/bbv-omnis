import { TestBed } from '@angular/core/testing';

import { configureTestSuite } from 'ng-bullet';

import { AuthInterceptorService } from './auth-interceptor.service';
import { AuthService } from './auth.service';

describe('AuthInterceptorService', () => {
  const service = {
    getToken: jest.fn()
  };

  configureTestSuite(() =>
    TestBed.configureTestingModule({
      providers: [AuthInterceptorService, { provide: AuthService, useValue: service }]
    })
  );

  it('should be created', () => {
    const testee: AuthInterceptorService = TestBed.get(AuthInterceptorService); /*?. */
    expect(testee).toBeTruthy(); /*?. */
  });
});
