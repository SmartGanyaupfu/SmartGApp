import { isPlatformBrowser } from '@angular/common';
import { Component, EventEmitter, Inject, OnInit, Output, PLATFORM_ID, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { SearchDto } from 'src/app/_interfaces/search-dto';
import { Widget } from 'src/app/_interfaces/widget';
import { AuthService } from 'src/app/_services/auth.service';
import { SearchService } from 'src/app/_services/search.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
 @Inject(PLATFORM_ID) private platformId;
widget:Widget;
show:boolean=false;
  constructor(private widgetService:WidgetService, private searchService:SearchService, public authService:AuthService,
    private modalService:BsModalService) { }
searchTerm:string='';
modalRef?: BsModalRef | null;
searchResult:SearchDto;
gotResults=false;
  ngOnInit(): void {
  
    this.getWidget();
   
  }
  
  getWidget(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget=res;
    })
  }
  signedIn(){
    if(isPlatformBrowser(this.platformId)){
      this.show=this.authService.loggedIn();
    }
    
    }

  getSearchResults(template: TemplateRef<any>){
    this.searchService.getSearchResults(1,15,this.searchTerm).subscribe(res=>{
      //localStorage.setItem('searchResult', JSON.stringify(res));
     this.searchResult=res;
     if(res.pages.length>0||res.portfolios.length>0||res.posts.length>0||res.services.length>0){
      this.gotResults=true;
     }
     
     this.modalRef = this.modalService.show(template, { id: 1, class: 'modal-lg' });
    
      
    })
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { id: 1, class: 'modal-lg' });
    
    
  }
  closeModal(modalId?: number){
    this.modalService.hide(modalId);
  }

}
