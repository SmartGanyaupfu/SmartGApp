import { Component, OnInit, ViewChild } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/_interfaces/category';
import { Image } from 'src/app/_interfaces/image';
import { Post } from 'src/app/_interfaces/post';
import { SlugifyPipe } from 'src/app/_pipes/slugify.pipe';
import { CategoryService } from 'src/app/_services/category.service';
import { PostService } from 'src/app/_services/post.service';

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent implements OnInit {

  slugEdit:boolean;
  show:boolean=true;
  slug:string='';
  image: Image;
  postId:any='';
  title:string='';
  categories:Category[]=[];
  pageNumber:number=1;
  pageSize:number=20;

  page:Post;
  modalRef?: BsModalRef | null;

  updatePageForm:UntypedFormGroup=new UntypedFormGroup({});

  @ViewChild('staticTabs', { static: false }) staticTabs?: TabsetComponent;

  constructor(private postService:PostService,private slugifyPipe:SlugifyPipe
    ,private toaster:ToastrService, private categoryService:CategoryService,
      private router:Router, private route:ActivatedRoute) { 
    
    }

    slugify(input: string){
      return this.slugifyPipe.transform(input);
  }

  initialiseForm(){
    this.updatePageForm=new UntypedFormGroup({
      title: new UntypedFormControl(),
      content: new UntypedFormControl(),
      slug: new UntypedFormControl(),
  excerpt: new UntypedFormControl(),
  metaDescription: new UntypedFormControl(),
  metaKeyWords: new UntypedFormControl(),
  sgImageId:new UntypedFormControl(),
  sgCategoryId:new UntypedFormControl()
    });
  }
  setUpdatePageFromValue(){
    this.updatePageForm.patchValue({
      title: this.page?.title,
      content: this.page?.content,
      slug: this.page?.slug,
  excerpt: this.page?.excerpt,
  metaDescription:this.page?.metaDescription,
  metaKeyWords: this.page?.metaKeyWords,
  sgImageId:this.page?.sgImageId,
  sgCategoryId:this.page?.category?.categoryId
    })
  }
  
    ngOnInit(): void {
      
     this.getCategories();
     this.postId= this.router.url.split('?')[0].split('/').pop();

     if(history.state.postData){
      localStorage.setItem('postData',JSON.stringify(history.state.postData));
    this.page=JSON.parse(localStorage.getItem('postData'));
    this.initialiseForm();
    this.setUpdatePageFromValue();
    }else {
      localStorage.removeItem('postData');
      this.postService.getPostById(this.postId).subscribe(res=>{
        this.page=res;
        this.slug=this.page.slug;
        this.initialiseForm();
    this.setUpdatePageFromValue();
      })
    }

    }

    editSlug(){
      this.slugEdit= true;
      this.slug=this.slugify(this.page.slug);
      this.show=false;
    }

    updatePage(){
     if(this.image){
      this.updatePageForm.patchValue({
        sgImageId:this.image.imageId,
          slug:this.slug===''?this.slugify(this.page.slug):this.slugify(this.slug)
        })
     }else{
      this.updatePageForm.patchValue({
        slug:this.slug===''?this.slugify(this.page.slug):this.slugify(this.slug)
      })
     }
   
      this.postService.updatePost(this.page.postId,this.updatePageForm.value).subscribe(res=>{
        this.toaster.success('Post updated.','Success')
       this.router.navigateByUrl('/admin/posts')
     })
    }
    getCategories(){
      this.categoryService.getCategories(this.pageNumber,this.pageSize).subscribe(res=>{
        this.categories=res.result;
      })
    }
    addFeatureImage(image:Image){
      this.image=image;
      this.selectTab(0);
    }

    selectTab(tabId: number) {
      if (this.staticTabs?.tabs[tabId]) {
        this.staticTabs.tabs[tabId].active = true;
      }
    }

}
