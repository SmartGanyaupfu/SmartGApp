import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/_interfaces/category';
import { Pagination } from 'src/app/_interfaces/pagination';
import { User } from 'src/app/_interfaces/user';
import { AuthService } from 'src/app/_services/auth.service';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  public pagination:Pagination;
  pageNumber:number=1;
pageSize:number=30;
pages:Category[];
users:User[];
  constructor(private catService:CategoryService, private toastr:ToastrService, private authService: AuthService) { }

  ngOnInit(): void {
   this.getCategories();
    this.loadUsers();

  }

getCategories(){
  this.catService.getCategories(this.pageNumber,this.pageSize).subscribe(res=>{
    this.pages=res.result;
    this.pagination=res.pagination;
      
  })
}
loadUsers(){
  this.authService.getAllUsers().subscribe(res=>{
this.users=res;
  })
}
deleteCategory(page:Category){
  if(confirm("Are you sure to delete, this is a permanent action ")) {
this.catService.deleteCategory(page.categoryId).subscribe(res=>{
  this.pages.splice(this.pages.indexOf(page),1);
  this.toastr.success("Category has been permanently deleted", "Deleted")
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
this.getCategories();
}

}
