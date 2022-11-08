import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from 'src/app/_interfaces/pagination';
import { Post } from 'src/app/_interfaces/post';
import { User } from 'src/app/_interfaces/user';
import { Widget } from 'src/app/_interfaces/widget';
import { AuthService } from 'src/app/_services/auth.service';
import { PostService } from 'src/app/_services/post.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {

  public pagination:Pagination;
  pageNumber:number=1;
  widget:Widget;
pages:Post[];
users:User[];
author:string="";
  category:string="";
  constructor(private postService:PostService, private toastr:ToastrService, private authService: AuthService,
    private widgetService:WidgetService) { }

  ngOnInit(): void {
   this.getWidgets();
    this.loadUsers();

  }
  getWidgets(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget= res;
     
      this.getPosts();
    
     
    })
  }
getPosts(){
  this.postService.getPosts(this.pageNumber,this.widget.postPageSize, this.author,this.category).subscribe(res=>{
    this.pages=res.result;
    this.pagination=res.pagination;
    
  })
}
loadUsers(){
  this.authService.getAllUsers().subscribe(res=>{
this.users=res;
  })
}
deletePost(page:Post){
  if(confirm("Are you sure to delete, this is a permanent action ")) {
this.postService.deletePost(page.postId).subscribe(res=>{
  this.pages.splice(this.pages.indexOf(page),1);
  this.toastr.success("Post has been permanently deleted", "Deleted")
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
this.getPosts();
}

}
