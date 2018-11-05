import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { ErrorStateMatcher } from '@angular/material/core';

import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'omnis-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  failureMessage: string;

  constructor(private formBuilder: FormBuilder, private authService: AuthService) {
    this.createForm();
  }

  ngOnInit() {
    this.failureMessage = '';
  }

  login() {
    this.authService.login(this.loginForm.value.username, this.loginForm.value.password).subscribe(
      () => {
        this.failureMessage = '';
      },
      () => {
        this.failureMessage = 'Login failed. Please check your user name & password.';
      }
    );
  }

  private createForm() {
    this.loginForm = this.formBuilder.group({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', Validators.required)
    });
  }
}
