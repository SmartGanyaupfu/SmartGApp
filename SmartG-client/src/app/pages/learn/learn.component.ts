import { Component, OnInit } from '@angular/core';
import { Page } from 'src/app/_interfaces/page';
import { PageService } from 'src/app/_services/page.service';

@Component({
  selector: 'app-learn',
  templateUrl: './learn.component.html',
  styleUrls: ['./learn.component.css']
})
export class LearnComponent implements OnInit {
page:Page;
  constructor(private pageService:PageService) { }

  ngOnInit(): void {
    this.getLearnPage();
  }

  getLearnPage(){
    this.pageService.getPageById(2).subscribe(response=>{
      this.page=response;
    })
  }
}
