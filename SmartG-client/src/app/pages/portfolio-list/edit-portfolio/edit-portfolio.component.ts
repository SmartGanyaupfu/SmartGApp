import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/_interfaces/category';
import { Gallery } from 'src/app/_interfaces/gallery';
import { Image } from 'src/app/_interfaces/image';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { SlugifyPipe } from 'src/app/_pipes/slugify.pipe';
import { CategoryService } from 'src/app/_services/category.service';
import { GalleryService } from 'src/app/_services/gallery.service';
import { PortfolioService } from 'src/app/_services/portfolio.service';

@Component({
  selector: 'app-edit-portfolio',
  templateUrl: './edit-portfolio.component.html',
  styleUrls: ['./edit-portfolio.component.css']
})
export class EditPortfolioComponent implements OnInit {

  slugEdit:boolean;
  show:boolean=true;
  slug:string='';
  image: Image;
  portfolioId:any='';
  title:string='';
  categories:Category[]=[];
  pageNumber:number=1;
  pageSize:number=20;
  galleries:Gallery[]=[];

  page:Portfolio;
  modalRef?: BsModalRef | null;

  updatePageForm:UntypedFormGroup=new UntypedFormGroup({});

  @ViewChild('staticTabs', { static: false }) staticTabs?: TabsetComponent;

  constructor(private portService:PortfolioService,private slugifyPipe:SlugifyPipe
    ,private toaster:ToastrService, private categoryService:CategoryService,
      private router:Router, private route:ActivatedRoute,private galleryService:GalleryService) { 
    
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
  imageId:new UntypedFormControl(),
  galleryId: new FormControl(),
  categoryId:new UntypedFormControl()
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
  imageId:this.page?.imageId,
  galleryId:this.page?.galleryId,
  categoryId:this.page.category.categoryId
    })
  }
  
    ngOnInit(): void {
      
     this.getCategories();
     this.getGalleries();
     this.portfolioId= this.router.url.split('?')[0].split('/').pop();
 
    if(history.state.portfolioData){
      localStorage.setItem('portfolioData',JSON.stringify(history.state.portfolioData));
    this.page=JSON.parse(localStorage.getItem('portfolioData'));
    this.initialiseForm();
    this.setUpdatePageFromValue();
    }else {
      localStorage.removeItem('portfolioData');
      this.portService.getPortfolioById(this.portfolioId).subscribe(res=>{
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
     console.log(this.page);
     if(this.image){
      this.updatePageForm.patchValue({
        imageId:this.image.imageId,
          slug:this.slug===''?this.slugify(this.page.slug):this.slugify(this.slug)
        })
     }else{
      this.updatePageForm.patchValue({
        slug:this.slug===''?this.slugify(this.page.slug):this.slugify(this.slug)
      })
     }
   
     console.log(this.updatePageForm.value)
      this.portService.updatePortfolio(this.page.portfolioId,this.updatePageForm.value).subscribe(res=>{
        this.toaster.success('Portfolio updated.','Success')
        this.router.navigateByUrl('/admin/portfolios')
     })
    }
    getCategories(){
      this.categoryService.getCategories(this.pageNumber,this.pageSize).subscribe(res=>{
        this.categories=res.result;
        console.log(this.categories);
      })
    }
    getGalleries(){
      this.galleryService.getGalleryList().subscribe(res=>{
        this.galleries=res;
        
      })
    
    }
    addFeatureImage(image:Image){
      this.image=image;
      console.log('fired');
      console.log(this.image);
      this.selectTab(0);
    }

    selectTab(tabId: number) {
      if (this.staticTabs?.tabs[tabId]) {
        this.staticTabs.tabs[tabId].active = true;
      }
    }



}
