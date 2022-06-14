import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/_interfaces/post';
import { PostService } from 'src/app/_services/post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
posts:Post[];
webPost:Post[];
mobilePost:Post[];
pageNumber:number=1;
  pageSize:number=6;
  constructor(private postService:PostService) { }

  ngOnInit(): void {
    this.getBlogs();
  }
  getBlogs(){
    this.postService.getPosts(this.pageNumber,this.pageSize).subscribe(response=>{
    this.posts=response.result;
    this.webPost=this.posts.filter(x=>x.category.categoryId===1);
    this.mobilePost=this.posts.filter(x=>x.category.categoryId===2);
    console.log(this.posts);
    })
    }
}
