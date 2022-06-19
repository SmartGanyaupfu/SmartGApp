import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/_interfaces/category';
import { ContentBlockForCreationDto } from 'src/app/_interfaces/content-block-for-creation-dto';
import { Image } from 'src/app/_interfaces/image';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { PortfolioForCreationDto } from 'src/app/_interfaces/portfolio-for-creation-dto';
import { SlugifyPipe } from 'src/app/_pipes/slugify.pipe';
import { CategoryService } from 'src/app/_services/category.service';
import { PortfolioService } from 'src/app/_services/portfolio.service';

@Component({
  selector: 'app-new-portfolio',
  templateUrl: './new-portfolio.component.html',
  styleUrls: ['./new-portfolio.component.css']
})
export class NewPortfolioComponent implements OnInit {

  slugEdit:boolean;
  show:boolean=true;
  slug:string='';
  name:string='';
  content:string='';
  title:string='';
  excerpt: string='';
  categoryId:number=1
  metaDescription: string='';
  metaKeyWords: string='';
  image: Image;
  categories:Category[]=[];
  contentBlock: ContentBlockForCreationDto={content:'',title:''};
  contentBlocks: ContentBlockForCreationDto[]=[];
  pageNumber:number=1;
  pageSize:number=20;
  
  page:Portfolio;
  modalRef?: BsModalRef | null;

  @ViewChild('staticTabs', { static: false }) staticTabs?: TabsetComponent;
 

    constructor(private portfolioService:PortfolioService,private slugifyPipe:SlugifyPipe,private toaster:ToastrService, 
      private modalService: BsModalService, private router:Router, private categoryService:CategoryService) { 
    
    }

    slugify(input: string){
      return this.slugifyPipe.transform(input);
  }
  
    ngOnInit(): void {
    this.getCategories();
     
    }

    editSlug(){
      this.slugEdit= true;
      this.slug=this.slugify(this.title);
      this.show=false;
    }

    addPage(){
      this.contentBlocks?.push(this.contentBlock);
      
      let newPortfolio:PortfolioForCreationDto= {title:this.title,slug:this.slug===''?this.slugify(this.title):this.slugify(this.slug),
       excerpt:this.excerpt,imageId:this.image?.imageId,metaDescription:this.metaDescription,contentBlocks:this.contentBlocks,metaKeyWords:this.metaKeyWords,
      content:this.content,categoryId:this.categoryId}
   console.log(newPortfolio);
      this.portfolioService.createPortfolio(newPortfolio).subscribe(res=>{
        this.toaster.success('Page Created.', 'Success')
       this.router.navigateByUrl('/admin/portfolios')
     })
    }

    getCategories(){
      this.categoryService.getCategories(this.pageNumber,this.pageSize).subscribe(res=>{
        this.categories=res.result;
        console.log(this.categories);
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
