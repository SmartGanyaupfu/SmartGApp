import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
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

  userRegisterForm:FormGroup;
  toppings: FormGroup;

  roles : Role[]=[];
  arr2:any=[];

  constructor(private formBuilder:FormBuilder,private authenticationService:AuthService,private fb: FormBuilder,
    private toastService:ToastrService,private route:Router) {
    this.initialiseUserRegistrationForm();
    //this.addRolesCheckboxes();
    this.toppings = formBuilder.group({
      pepperoni: false,
      extracheese: false,
      mushroom: false
    });
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
  
    this.userRegisterForm= new FormGroup({
      firstName:new FormControl(),
      lastName: new FormControl(),
      userName: new FormControl(),
      password: new FormControl(),
      confirmPassword: new FormControl(),
      email: new FormControl(),
      phoneNumber: new FormControl(),
      roles:  this.fb.array(rolesFGs),
      clientUri:new FormControl(environment.clientUrl)
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
