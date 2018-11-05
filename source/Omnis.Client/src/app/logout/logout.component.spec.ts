import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';

import { configureTestSuite } from 'ng-bullet';

import { AuthService } from '../auth/auth.service';
import { LogoutComponent } from './logout.component';

describe('LogoutComponent', () => {
  const service = {
    logout: jest.fn()
  };

  const router = {
    navigate: jest.fn()
  };

  let component: LogoutComponent;
  let fixture: ComponentFixture<LogoutComponent>;

  configureTestSuite(() => {
    TestBed.configureTestingModule({
      declarations: [LogoutComponent],
      providers: [{ provide: AuthService, useValue: service }, { provide: Router, useValue: router }]
    });
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LogoutComponent);
    component = fixture.componentInstance;

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should logout with service', () => {
    expect(service.logout).toHaveBeenCalled();
  });

  it('should navigate to home component', () => {
    expect(router.navigate).toHaveBeenCalledWith(['/home']);
  });
});
