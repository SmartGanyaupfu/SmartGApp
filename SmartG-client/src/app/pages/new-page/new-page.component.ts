import { Component, OnInit } from '@angular/core';
import { Page } from 'src/app/_interfaces/page';
import { PageService } from 'src/app/_services/page.service';

@Component({
  selector: 'app-new-page',
  templateUrl: './new-page.component.html',
  styleUrls: ['./new-page.component.css']
})
export class NewPageComponent implements OnInit {
page:Page;
  constructor(private pageService:PageService) { }

  ngOnInit(): void {
  }
createPage(){
  this.pageService.createPage("").subscribe(res=>{
this.page=res;
  }
  )
}
}
