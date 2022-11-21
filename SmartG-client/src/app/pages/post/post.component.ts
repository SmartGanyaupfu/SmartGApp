import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/_interfaces/post';
import { Widget } from 'src/app/_interfaces/widget';
import { PostService } from 'src/app/_services/post.service';
import { SeoService } from 'src/app/_services/seo.service';
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
  category:number;

  widget:Widget;
  constructor(private postService:PostService,private widgetService:WidgetService,private seoService:SeoService) { }

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
        this.seoService.metaTitle.setTitle('SG | Blog- I Share some useful articles- coding blogs and tutorials')
        this.seoService.metaTagService.updateTag({name:'description', content:'SG | Blog - I share some useful coding'+
         'articles and tutorials. If you want to learn how to code, you are at the right place.'})
        this.seoService.metaTagService.updateTag({
          name:'keywords',
        content:' Blog Hosting, Android and IOS mobile app development, Developer, Web design, Graphic Design'
        })
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
