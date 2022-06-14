import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { ContentBlock } from 'src/app/_interfaces/content-block';
import { Image } from 'src/app/_interfaces/image';
import { Page } from 'src/app/_interfaces/page';
import { PageForCreationDto } from 'src/app/_interfaces/page-for-creation-dto';
import { SlugifyPipe } from 'src/app/_pipes/slugify.pipe';
import { PageService } from 'src/app/_services/page.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-new-page',
  templateUrl: './new-page.component.html',
  styleUrls: ['./new-page.component.css']
})
export class NewPageComponent implements OnInit {
  html = 'placeholder';
  slugEdit:boolean;
  show:boolean=true;
  slug:string='';
  name:string='';
  content:string='';
  title:string='';
  excerpt: string='';
  metaDescription: string='';
  metaKeyWords: string='';
  image: Image;
  contentBlocks: ContentBlock[];
  authorId?: any;
  createPageForm:FormGroup=new FormGroup({});
  page:Page;
    constructor(private pageService:PageService,private tokenService:TokenStorageService,private slugifyPipe:SlugifyPipe,
      private route:Router,private toaster:ToastrService, private jwtHelper:JwtHelperService) { 
    
      this.initialiseForm();
    }

    slugify(input: string){
      return this.slugifyPipe.transform(input);
  }
  
    ngOnInit(): void {
     //this.user= history.state.data;
     if(history.state.pageData){
      localStorage.setItem('pageData',JSON.stringify(history.state.pageData));
    }
    
    this.page=JSON.parse(localStorage.getItem('pageData'));
     
     
      this.initialiseForm();
      this.patchForm();
    }
    initialiseForm(){

     

      this.createPageForm=new FormGroup({
 
        title: new FormControl(),
        content: new FormControl(),
        author: new FormControl(),
        slug: new FormControl(this.slug),
      }
        
      );
    }
    editSlug(){
      this.slugEdit= true;
      this.slug=this.slugify(this.title);
      this.show=false;
    }
  patchForm(){
    this.createPageForm.patchValue({
     
        slug: this.slug
      
      
    })
  }
    addPage(){
      
      let newPage:PageForCreationDto= {title:this.title,slug:this.slug===''?this.slugify(this.title):this.slugify(this.slug),
       excerpt:this.excerpt,image:this.image,metaDescription:this.metaDescription,contentBlocks:this.contentBlocks,metaKeyWords:this.metaKeyWords,
      content:this.content,authorId:this.getLoggedInUser()}
   
      this.pageService.createPage(newPage).subscribe(res=>{
       
      })
    }

    getLoggedInUser(){
      let user= this.tokenService.getUser();
       return user.userName;
     }

}
