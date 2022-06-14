import { Component, OnInit } from '@angular/core';
import { Page } from 'src/app/_interfaces/page';
import { PageService } from 'src/app/_services/page.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  page:Page;
  constructor(private pageService:PageService) { }

  ngOnInit(): void {
    this.getLearnPage();
  }

  getLearnPage(){
    this.pageService.getPageById(3).subscribe(response=>{
      this.page=response;
    })
  }

}
