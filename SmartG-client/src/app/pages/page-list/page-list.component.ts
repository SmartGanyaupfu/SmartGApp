import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Page } from 'src/app/_interfaces/page';
import { Pagination } from 'src/app/_interfaces/pagination';
import { User } from 'src/app/_interfaces/user';
import { AuthService } from 'src/app/_services/auth.service';
import { PageService } from 'src/app/_services/page.service';

@Component({
  selector: 'app-page-list',
  templateUrl: './page-list.component.html',
  styleUrls: ['./page-list.component.css']
})
export class PageListComponent implements OnInit {
  public pagination:Pagination;
  pageNumber:number=1;
pageSize:number=5;
pages:Page[];
users:User[];
  constructor(private pageService:PageService, private toastr:ToastrService, private authService: AuthService) { }

  ngOnInit(): void {
    this.getPages();
    this.loadUsers();

  }

getPages(){
  this.pageService.getPages(this.pageNumber,this.pageSize).subscribe(res=>{
    this.pages=res.result;
    this.pagination=res.pagination;
  })
}
loadUsers(){
  this.authService.getAllUsers().subscribe(res=>{
this.users=res;
  })
}
deletePage(page:Page){
this.pageService.deletePage(page.pageId).subscribe(res=>{
  this.pages.splice(this.pages.indexOf(page));
  this.toastr.success("Page has been permanently deleted", "Deleted")
})
}
updatePage(pageId:number){
  
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
  this.getPages();
}

}
