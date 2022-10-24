import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from 'src/app/_interfaces/pagination';
import { Post } from 'src/app/_interfaces/post';
import { Service } from 'src/app/_interfaces/service';
import { User } from 'src/app/_interfaces/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ServiceService } from 'src/app/_services/service.service';

@Component({
  selector: 'app-service-list',
  templateUrl: './service-list.component.html',
  styleUrls: ['./service-list.component.css']
})
export class ServiceListComponent implements OnInit {

  public pagination:Pagination;
  pageNumber:number=1;
pageSize:number=10;
pages:Service[];
users:User[];
  constructor(private serviceService:ServiceService, private toastr:ToastrService, private authService: AuthService) { }

  ngOnInit(): void {
   this.getServices();
    this.loadUsers();

  }

getServices(){
  this.serviceService.getServices(this.pageNumber,this.pageSize).subscribe(res=>{
    this.pages=res.result;
    this.pagination=res.pagination;
    console.log(res);
    
  })
}
loadUsers(){
  this.authService.getAllUsers().subscribe(res=>{
this.users=res;
  })
}
deleteService(page:Service){
  if(confirm("Are you sure to delete, this is a permanent action ")) {
this.serviceService.deleteService(page.offeredServiceId).subscribe(res=>{
  this.pages.splice(this.pages.indexOf(page),1);
  this.toastr.success("Service has been permanently deleted", "Deleted")
})}
}

getAuthor(userId:string){
  if(userId!==''){
    let user=this.users?.find(u=>u.id===userId)
if(user){
  return user.userName;
}else {
  return 'Smart'
}
  }
return 'Smart';
}

pageChanged(event){
  this.pageNumber=event.page;
this.getServices();
}

}
