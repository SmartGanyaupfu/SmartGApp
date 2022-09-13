import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { SearchDto } from 'src/app/_interfaces/search-dto';
import { SearchService } from 'src/app/_services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
searchTerm:string='';
  constructor(private searchService:SearchService,private route:Router) { }

  ngOnInit(): void {
  }
  getSearchResults(){
    this.searchService.getSearchResults(1,15,this.searchTerm).subscribe(res=>{
      localStorage.setItem('searchResult', JSON.stringify(res));
      this.route.navigate(['/search']);
      
    })
  }
}
