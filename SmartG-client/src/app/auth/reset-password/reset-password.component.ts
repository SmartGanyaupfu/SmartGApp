import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ResetPassword } from 'src/app/_interfaces/reset-password';
import { AuthService } from 'src/app/_services/auth.service';
import { PasswordConfirmationValidatorService } from 'src/app/_services/password-confirmation-validator.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  public resetPasswordForm: UntypedFormGroup;
  public showSuccess: boolean;
  public showError: boolean;
  public errorMessage: string;
  private _token: string;
  private _email: string;
  constructor(private _authService: AuthService, private _passConfValidator: PasswordConfirmationValidatorService, 
    private _route: ActivatedRoute,private route:Router) { }
  ngOnInit(): void {
    this.resetPasswordForm = new UntypedFormGroup({
      password: new UntypedFormControl('', [Validators.required]),
      confirm: new UntypedFormControl('')
    });
    this.resetPasswordForm.get('confirm').setValidators([Validators.required,
      this._passConfValidator.validateConfirmPassword(this.resetPasswordForm.get('password'))]);
    
      this._token = this._route.snapshot.queryParams['token'];
      this._email = this._route.snapshot.queryParams['email'];
  }
  public validateControl = (controlName: string) => {
    return this.resetPasswordForm.controls[controlName].invalid && this.resetPasswordForm.controls[controlName].touched
  }
  
  public hasError = (controlName: string, errorName: string) => {
    return this.resetPasswordForm.controls[controlName].hasError(errorName)
  }
  
  public resetPassword = (resetPasswordFormValue) => {
    this.showError = this.showSuccess = false;
  
    const resetPass = { ... resetPasswordFormValue };
    const resetPassDto: ResetPassword = {
      password: resetPass.password,
      confirmPassword: resetPass.confirm,
      token: this._token,
      email: this._email
    }
  
    this._authService.resetPassword(resetPassDto)
    .subscribe(_ => {
      this.showSuccess = true;
    },
    error => {
      this.showError = true;
      this.errorMessage = error.error;
      this.route.navigate(['/auth/login'])
    })
  }

}
