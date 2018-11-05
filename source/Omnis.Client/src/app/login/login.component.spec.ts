import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { configureTestSuite } from 'ng-bullet';
import { of, throwError } from 'rxjs';

import { AuthService } from '../auth/auth.service';
import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  const service = {
    login: jest.fn()
  };

  const router = {
    navigate: jest.fn()
  };

  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  configureTestSuite(() => {
    TestBed.configureTestingModule({
      imports: [ReactiveFormsModule],
      declarations: [LoginComponent],
      providers: [{ provide: AuthService, useValue: service }, { provide: Router, useValue: router }]
    });
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should expose empty failure message', () => {
    fixture.detectChanges();
    expect(component.failureMessage).toBe('');
  });

  it('should have invalid form when no entries were made', () => {
    fixture.detectChanges();
    expect(component.loginForm.valid).toBe(false);
  });

  it('should have valid form when email and password are provided', () => {
    fixture.detectChanges();
    component.loginForm.setValue({
      email: 'john@doe.com',
      password: 'LetMeIn'
    });

    expect(component.loginForm.valid).toBe(true);
  });

  it('should call auth service on submit and reset failure message on success', () => {
    component.loginForm.setValue({
      email: 'john@doe.com',
      password: 'LetMeIn'
    });

    component.failureMessage = 'some previous failre';

    service.login.mockImplementationOnce(() => of(true));

    fixture.detectChanges();
    component.onSubmit();

    expect(component.failureMessage).toBe('');
  });

  it('should call auth service on submit and expose failure message on failure', () => {
    component.loginForm.setValue({
      email: 'john@doe.com',
      password: 'WrongPassword'
    });

    service.login.mockImplementationOnce(() => throwError(401));

    fixture.detectChanges();
    component.onSubmit();

    expect(component.failureMessage).toBe('Login failed. Please check your email & password.');
  });
});
