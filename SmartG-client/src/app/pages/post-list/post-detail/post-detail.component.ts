import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from 'src/app/_interfaces/post';
import { PostService } from 'src/app/_services/post.service';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css']
})
export class PostDetailComponent implements OnInit {

  page:Post;
  pageSlug:string;

  constructor(private postService:PostService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {

    this.route.data.subscribe(data=>{
      this.page=data.post;
    })
    //console.log(this.route.parent.url)
  /*
    if(history.state.postData){
      localStorage.setItem('postData',JSON.stringify(history.state.postData));
      this.page=JSON.parse(localStorage.getItem('postData'));
    }else {
      localStorage.removeItem('postData');
      this.postService.getPostBySlug(this.pageSlug).subscribe(res=>{
        this.page=res;
      })
    }
  */

  }
}
