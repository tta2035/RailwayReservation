import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import {  Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { UserStoreService } from '../../services/user-store.service';
import ValidateForm from 'src/app/helpers/ValidateForm';

@Component({
  selector: 'app-a-login',
  templateUrl: './a-login.component.html',
  styleUrls: ['./a-login.component.css']
})
export class ALoginComponent implements OnInit{
  
  loginForm!: FormGroup;


  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private route: Router,
    private toast: NgToastService,
    private userStoreService: UserStoreService
  ) {

  } 
   ngOnInit(): void {
    this.loginForm = this.fb.group( {
      email: ['', Validators.required],
      password: ['', Validators.required],
      token: ['']
    });
  }

  onLogin() {
    if(this.loginForm.valid) {
      console.log("login: ", this.loginForm.value);
    } else {
      console.log("form không hợp lệ");
      ValidateForm.validateFormFields(this.loginForm);
    }
    
  }

}
