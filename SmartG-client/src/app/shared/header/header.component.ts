import { Component, EventEmitter, OnInit, Output, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { SearchDto } from 'src/app/_interfaces/search-dto';
import { Widget } from 'src/app/_interfaces/widget';
import { SearchService } from 'src/app/_services/search.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
widget:Widget;
  constructor(private widgetService:WidgetService, private searchService:SearchService, private modalService:BsModalService) { }
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

  getSearchResults(template: TemplateRef<any>){
    this.searchService.getSearchResults(1,15,this.searchTerm).subscribe(res=>{
      //localStorage.setItem('searchResult', JSON.stringify(res));
     this.searchResult=res;
     this.gotResults=true
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
