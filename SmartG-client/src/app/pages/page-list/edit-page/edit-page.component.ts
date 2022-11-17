import { isPlatformBrowser } from '@angular/common';
import { Component, Inject, OnInit, PLATFORM_ID, TemplateRef, ViewChild } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { ContentBlockForCreationDto } from 'src/app/_interfaces/content-block-for-creation-dto';
import { Image } from 'src/app/_interfaces/image';
import { Page } from 'src/app/_interfaces/page';
import { PageForCreationDto } from 'src/app/_interfaces/page-for-creation-dto';
import { SlugifyPipe } from 'src/app/_pipes/slugify.pipe';
import { PageService } from 'src/app/_services/page.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-edit-page',
  templateUrl: './edit-page.component.html',
  styleUrls: ['./edit-page.component.css']
})
export class EditPageComponent implements OnInit {
  html = 'placeholder';
  slugEdit:boolean;
  show:boolean=true;
  pageId:any='';
  slug:string='';
  name:string='';
  content:string='';
  title:string='';
  excerpt: string='';
  metaDescription: string='';
  metaKeyWords: string='';
  image: Image;
  contentBlock: ContentBlockForCreationDto={content:'',title:''};
  contentBlocks: ContentBlockForCreationDto[]=[];
  authorId?: any;
  page:Page;
  modalRef?: BsModalRef | null;

  updatePageForm:UntypedFormGroup=new UntypedFormGroup({});

  @ViewChild('staticTabs', { static: false }) staticTabs?: TabsetComponent;

  constructor(private pageService:PageService,private slugifyPipe:SlugifyPipe
    ,private toaster:ToastrService, 
      private modalService: BsModalService, private router:Router, @Inject (PLATFORM_ID) private platformId) { 
    
    }

    slugify(input: string){
      return this.slugifyPipe.transform(input);
  }

  initialiseForm(){
    this.updatePageForm=new UntypedFormGroup({
      title: new UntypedFormControl(),
      content: new UntypedFormControl(),
      slug: new UntypedFormControl(this.slug),
  excerpt: new UntypedFormControl(),
  metaDescription: new UntypedFormControl(),
  metaKeyWords: new UntypedFormControl(),
  sgImageId:new UntypedFormControl()
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
  sgImageId:this.page?.sgImageId
    })
  }
  
    ngOnInit(): void {
     this.pageId= this.router.url.split('?')[0].split('/').pop();
     if(isPlatformBrowser(this.platformId)){
      if(history.state.pageData){
        localStorage.setItem('pageData',JSON.stringify(history.state.pageData));
      this.page=JSON.parse(localStorage.getItem('pageData'));
      this.initialiseForm();
      this.setUpdatePageFromValue();
      this.slug=this.page.slug;
      }else {
        localStorage.removeItem('pageData');
        this.pageService.getPageById(this.pageId).subscribe(res=>{
          this.page=res;
          this.slug=this.page.slug;
          this.initialiseForm();
      this.setUpdatePageFromValue();
      
        })
      }
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
      this.pageService.updatePage(this.page.pageId,this.updatePageForm.value).subscribe(res=>{
        this.toaster.success('Page updated.','Success');
        this.router.navigateByUrl('/admin/pages');
     })
    }
    addFeatureImage(image:Image){
      this.image=image;
      this.selectTab(0);
    }

    

     openModal(template: TemplateRef<any>) {
      this.modalRef = this.modalService.show(template, { id: 1, class: 'modal-lg' });
      
    }
    closeModal(modalId?: number){
      this.modalService.hide(modalId);
    }

    selectTab(tabId: number) {
      if (this.staticTabs?.tabs[tabId]) {
        this.staticTabs.tabs[tabId].active = true;
      }
    }


}
