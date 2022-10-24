import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormArray, UntypedFormBuilder, UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from 'src/app/_interfaces/pagination';
import { Role } from 'src/app/_interfaces/role';
import { User } from 'src/app/_interfaces/user';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  public users: User[];
  pagination:Pagination;
  pageNumber?:number=1;
  pageSize?:number=5;
  searchTerm?:string=null;
  user:User;
  selectedUser?:User;
  userUpdateForm:UntypedFormGroup;
  
  
  arr2:any=[];
  
  roles : Role[]=[];
  //exampleForm: FormGroup;
  

  constructor(private  authenticationService: AuthService,private modalService:BsModalService,
    private toastService:ToastrService,private fb: UntypedFormBuilder,private router:Router) { 
    
  }

  ngOnInit(): void {
    this.getUsers();
   

    this.getData();
    this.initialiseUserUpdateForm();
  
  }
  modalRef: BsModalRef;


 hideModal(){
  this.modalRef.hide();
  //this.createAppointmentForm.reset();
 
 }

  openModalUpdateUser(updateUserTemplate: TemplateRef<any>,user:User) {


    this.selectedUser=user;
    this.roles=this.selectedUser.roles;
     this.userUpdateForm.patchValue(
       {'firstName': this.selectedUser.firstName,
     'lastName':this.selectedUser.lastName,
     'userName':this.selectedUser.userName,
     'email':this.selectedUser.email,
     'phoneNumber':this.selectedUser.phoneNumber,
     'roles':this.roles
     
    })
     

     
    this.modalRef = this.modalService.show(updateUserTemplate,{class: 'modal-lg'});
    console.log(this.selectedUser);
  
  }
  initialiseUserUpdateForm(){

    let rolesFGs = this.roles.map(x => {
      return this.fb.group({
        
        name: x.name,
        isActive: x.isActive
      });
    });
  
    this.userUpdateForm= new UntypedFormGroup({
      firstName:new UntypedFormControl(),
      lastName: new UntypedFormControl(),
      userName: new UntypedFormControl(),
      password: new UntypedFormControl(),
      confirmPassword: new UntypedFormControl(),
      email: new UntypedFormControl(),
      phoneNumber: new UntypedFormControl(),
      roles:  this.fb.array(rolesFGs)
    })
  }

submit(){
  
}
  updateUser() {
   this.authenticationService.updateUser(this.userUpdateForm.value,this.selectedUser.id).subscribe(response=>{
    
     this.toastService.success("Success","User Successfully updated");
this.router.navigateByUrl('admin/users');
   
  })
}

  deleteUser(user:User){
    if(confirm("Are you sure to delete, this is a permanent action ")) {
    this.authenticationService.delete(user.id).subscribe(response=>{
      this.toastService.success("Success","User Successfully deleted");
      this.users.splice(this.users.indexOf(user),1);
    });}
  }

  getUsers(){
    this.authenticationService.getAllUsers()
    .subscribe(response=>{
      this.users=response;
    
    })
  }

  pageChanged(event){
    this.pageNumber=event.page;
    //this.loadStaff();
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
