import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';

import { configureTestSuite } from 'ng-bullet';

import { AuthGuardService } from './auth-guard.service';
import { AuthService } from './auth.service';

describe('AuthGuardService', () => {
  const service = {
    isLoggedIn: jest.fn(),
    saveRedirectUrl: jest.fn()
  };

  const router = {
    navigate: jest.fn()
  };

  let testee = AuthGuardService;

  configureTestSuite(() => {
    TestBed.configureTestingModule({
      providers: [AuthGuardService, { provide: AuthService, useValue: service }, { provide: Router, useValue: router }]
    });
  });

  beforeEach(() => {
    testee = TestBed.get(AuthGuardService);
  });

  it('should be created', () => {
    expect(testee).toBeTruthy();
  });
});
