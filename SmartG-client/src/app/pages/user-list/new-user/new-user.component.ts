import { Component, OnInit } from '@angular/core';
import { FormArray, UntypedFormBuilder, UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Role } from 'src/app/_interfaces/role';
import { AuthService } from 'src/app/_services/auth.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.css']
})
export class NewUserComponent implements OnInit {

  userRegisterForm:UntypedFormGroup;
  toppings: UntypedFormGroup;

  roles : Role[]=[];
  arr2:any=[];

  constructor(private formBuilder:UntypedFormBuilder,private authenticationService:AuthService,private fb: UntypedFormBuilder,
    private toastService:ToastrService,private route:Router) {
    this.initialiseUserRegistrationForm();
   
  }

  ngOnInit(): void {
    this.getData();
    //this.initialiseUserUpdateForm();
    this.initialiseUserRegistrationForm();
    
  }

  initialiseUserRegistrationForm(){
    let rolesFGs = this.roles.map(x => {
      return this.fb.group({
        
        name: x.name,
        isActive: x.isActive
      });
    });
  
    this.userRegisterForm= new UntypedFormGroup({
      firstName:new UntypedFormControl(),
      lastName: new UntypedFormControl(),
      userName: new UntypedFormControl(),
      password: new UntypedFormControl(),
      confirmPassword: new UntypedFormControl(),
      email: new UntypedFormControl(),
      phoneNumber: new UntypedFormControl(),
      roles:  this.fb.array(rolesFGs),
      clientUri:new UntypedFormControl(environment.clientUrl)
    })
  }

submit(){
  
}
  addNewUser() {
   this.authenticationService.createUser(this.userRegisterForm.value).subscribe(response=>{
     
     this.toastService.success("Success","User Successfully registered");
     this.route.navigateByUrl('/admin/users')
   });
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
        "isActive": false
      }
  ]
  
  }
}
