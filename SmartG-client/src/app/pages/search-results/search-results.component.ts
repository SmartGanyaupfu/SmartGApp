import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SearchDto } from 'src/app/_interfaces/search-dto';
import { SearchService } from 'src/app/_services/search.service';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css']
})
export class SearchResultsComponent implements OnInit {
searchResult:SearchDto;
gotResults=false;
  constructor(private searchService:SearchService, private route:Router) {
    

   }

  ngOnInit(): void {

 
    /*if(localStorage.getItem('searchResult')){
      this.searchResult= JSON.parse(localStorage.getItem('searchResult'));
      this.gotResults=true;*/
    }


}
