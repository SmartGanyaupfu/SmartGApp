import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from 'src/app/_interfaces/pagination';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { User } from 'src/app/_interfaces/user';
import { AuthService } from 'src/app/_services/auth.service';
import { PortfolioService } from 'src/app/_services/portfolio.service';

@Component({
  selector: 'app-portfolio-list',
  templateUrl: './portfolio-list.component.html',
  styleUrls: ['./portfolio-list.component.css']
})
export class PortfolioListComponent implements OnInit {
  public pagination:Pagination;
  pageNumber:number=1;
pageSize:number=3;
pages:Portfolio[];
users:User[];
  constructor(private portfolioService:PortfolioService, private toastr:ToastrService, private authService: AuthService) { }

  ngOnInit(): void {
   this.getPortfolios();
    this.loadUsers();

  }

getPortfolios(){
  this.portfolioService.getPortfolios(this.pageNumber,this.pageSize).subscribe(res=>{
    this.pages=res.result;
    this.pagination=res.pagination;
    
  })
}
loadUsers(){
  this.authService.getAllUsers().subscribe(res=>{
this.users=res;
  })
}
deletePortfolio(page:Portfolio){
  if(confirm("Are you sure to delete, this is a permanent action ")) {
this.portfolioService.deletePortfolio(page.portfolioId).subscribe(res=>{
  this.pages.splice(this.pages.indexOf(page),1);
  this.toastr.success("Portfolio has been permanently deleted", "Deleted")
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
this.getPortfolios();
}
}
