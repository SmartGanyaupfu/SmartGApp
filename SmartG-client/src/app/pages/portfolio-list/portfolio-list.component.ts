import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from 'src/app/_interfaces/pagination';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { User } from 'src/app/_interfaces/user';
import { Widget } from 'src/app/_interfaces/widget';
import { AuthService } from 'src/app/_services/auth.service';
import { PortfolioService } from 'src/app/_services/portfolio.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-portfolio-list',
  templateUrl: './portfolio-list.component.html',
  styleUrls: ['./portfolio-list.component.css']
})
export class PortfolioListComponent implements OnInit {
  public pagination:Pagination;
  pageNumber:number=1;
  widget:Widget;
pages:Portfolio[];
users:User[];
  constructor(private portfolioService:PortfolioService, private toastr:ToastrService, private authService: AuthService, private widgetService: WidgetService) { }

  ngOnInit(): void {
   this.getWidgets();
    this.loadUsers();

  }
  getWidgets(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget= res;
     
      this.getPortfolios();
    
     
    })
  }

getPortfolios(){
  this.portfolioService.getPortfolios(this.pageNumber,this.widget.postPageSize).subscribe(res=>{
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
