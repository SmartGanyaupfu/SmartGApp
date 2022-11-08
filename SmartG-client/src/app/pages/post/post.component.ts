import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/_interfaces/post';
import { Widget } from 'src/app/_interfaces/widget';
import { PostService } from 'src/app/_services/post.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
posts:Post[];
webPost:Post[];
//mobilePost:Post[];
pageNumber:number=1;
  pageSize:number=6;
  author:string="";
  category:string="";

  widget:Widget;
  constructor(private postService:PostService,private widgetService:WidgetService) { }

  ngOnInit(): void {
this.getWidgets();
  }
  getBlogs(){
    this.postService.getPosts(this.pageNumber,this.widget.postPageSize, this.author,this.category).subscribe(response=>{
    this.posts=response.result;
    //this.webPost=this.posts.filter(x=>x.category.categoryId===1);
    //this.mobilePost=this.posts.filter(x=>x.category.categoryId===2);
    })
    }

    getWidgets(){
      this.widgetService.getWidget().subscribe(res=>{
        this.widget= res;
       
        this.getBlogs();
      
       
      })
    }
    getPostsByAuthor(author:string){
      this.author=author;
      this.getBlogs();
    }

    getPostsByCategory(catName){
      this.category=catName;
      this.getBlogs();
    }
}
