import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ContentBlock } from 'src/app/_interfaces/content-block';
import { Pagination } from 'src/app/_interfaces/pagination';
import { User } from 'src/app/_interfaces/user';
import { AuthService } from 'src/app/_services/auth.service';
import { ContentBlockService } from 'src/app/_services/content-block.service';

@Component({
  selector: 'app-content-block-list',
  templateUrl: './content-block-list.component.html',
  styleUrls: ['./content-block-list.component.css']
})
export class ContentBlockListComponent implements OnInit {

  public pagination:Pagination;
  pageNumber:number=1;
pageSize:number=20;
pages:ContentBlock[];
users:User[];
  constructor(private blockService:ContentBlockService, private toastr:ToastrService, private authService: AuthService) { }

  ngOnInit(): void {
   this.getBlocks();
    this.loadUsers();

  }

getBlocks(){
  this.blockService.getContentBlocks(this.pageNumber,this.pageSize).subscribe(res=>{
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
deleteBlock(page:ContentBlock){
  if(confirm("Are you sure to delete, this is a permanent action ")) {
this.blockService.deleteBlock(page.contentBlockId).subscribe(res=>{
  this.pages.splice(this.pages.indexOf(page),1);
  this.toastr.success("Content Block has been permanently deleted", "Deleted")
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
this.getBlocks();
}

}
