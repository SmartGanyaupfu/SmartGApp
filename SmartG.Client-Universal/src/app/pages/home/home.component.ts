import { Component, OnInit } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor( private metaTagService:Meta, private metaTitle:Title) {
  }
ngOnInit(): void {
  
  //  this.GetHomePage();
  this.addMetaTags();
  
  
  
}
addMetaTags(){

this.metaTagService.updateTag(   {
  name:'keywords',
content:'test home page ius'
});
  this.metaTitle.setTitle('Home Page');
  
  
}

}
