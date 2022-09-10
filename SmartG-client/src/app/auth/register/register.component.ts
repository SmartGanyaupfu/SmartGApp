import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Role } from 'src/app/_interfaces/role';
import { AuthService } from 'src/app/_services/auth.service';
import { PasswordConfirmationValidatorService } from 'src/app/_services/password-confirmation-validator.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  showSuccess:boolean=false;
  successMessage="";
  roles : Role[]=[];
  createUserForm:UntypedFormGroup=new UntypedFormGroup({});
    constructor(private authService:AuthService,private fb: UntypedFormBuilder,
      private _passConfValidator: PasswordConfirmationValidatorService,private toastr:ToastrService) { 
      this.initialiseForm();
    }
  
    ngOnInit(): void {
      this.getData();
      this.initialiseForm();
      this.createUserForm.get('confirmPassword').setValidators([Validators.required,
        this._passConfValidator.validateConfirmPassword(this.createUserForm.get('password'))]);
    }
    public validateControl = (controlName: string) => {
      return this.createUserForm.controls[controlName].invalid && this.createUserForm.controls[controlName].touched
    }
    public hasError = (controlName: string, errorName: string) => {
      return this.createUserForm.controls[controlName].hasError(errorName)
    }
    initialiseForm(){

      let rolesFGs = this.roles.map(x => {
        return this.fb.group({
          
          name: x.name,
          isActive: x.isActive
        });
      });

      this.createUserForm=new UntypedFormGroup({
 
        firstName: new UntypedFormControl('',[Validators.required]),
        lastName:new UntypedFormControl('',[Validators.required]),
       
        userName: new UntypedFormControl('',[Validators.required]),
        email: new UntypedFormControl('',[Validators.required, Validators.email]),
        phoneNumber:new UntypedFormControl('',[Validators.required]),
       
        password: new UntypedFormControl('',[Validators.required]),
        confirmPassword: new UntypedFormControl(),
        clientURI:  new UntypedFormControl(environment.clientUrl),
      
        roles:  this.fb.array(rolesFGs)
        
      }
        
      );
    }

    get firstName() { return this.createUserForm.get('firstName'); }
    get lastName() { return this.createUserForm.get('lastName'); }
    get userName() { return this.createUserForm.get('userName'); }
    get phoneNumber() { return this.createUserForm.get('phoneNumber'); }
    get password() { return this.createUserForm.get('password'); }

    get email() { return this.createUserForm.get('email'); }

    newUser(){
      this.authService.createUser(this.createUserForm.value).subscribe(
        res=>{
          this.toastr.success("Congrats! Your account has been created. An email has been sent to your account for confirmation.", "Success");
          this.createUserForm.reset;
          this.showSuccess=true;
          this.successMessage="Congrats! Your account has been created. An email has been sent to your account for confirmation.";
        }
      )
    }

    onCheckboxChecked(event:any) {
   
     

    }

    getData(){
    
      this.roles= [
        
          {
            "name": "Admin",
            "isActive": false
          },
          {
            "name": "Editor",
            "isActive": false
          },
          {
            "name": "Subscriber",
            "isActive": true
          }
        
    ]
    
    }
  

}
