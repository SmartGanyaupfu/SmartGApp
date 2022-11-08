import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Page } from 'src/app/_interfaces/page';
import { Pagination } from 'src/app/_interfaces/pagination';
import { User } from 'src/app/_interfaces/user';
import { Widget } from 'src/app/_interfaces/widget';
import { AuthService } from 'src/app/_services/auth.service';
import { PageService } from 'src/app/_services/page.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-page-list',
  templateUrl: './page-list.component.html',
  styleUrls: ['./page-list.component.css']
})
export class PageListComponent implements OnInit {
  public pagination:Pagination;
  pageNumber:number=1;
  widget:Widget;
pages:Page[];
users:User[];
  constructor(private pageService:PageService, private toastr:ToastrService, private authService: AuthService,
    private widgetService:WidgetService) { }

  ngOnInit(): void {
   this.getWidgets();
    this.loadUsers();

  }
  getWidgets(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget= res;
     
      this.getPages();
    
     
    })
  }

getPages(){
  this.pageService.getPages(this.pageNumber,this.widget.postPageSize).subscribe(res=>{
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
  if(confirm("Are you sure to delete, this is a permanent action ")) {
this.pageService.deletePage(page.pageId).subscribe(res=>{
  this.pages.splice(this.pages.indexOf(page),1);
  this.toastr.success("Page has been permanently deleted", "Deleted")
})}
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
