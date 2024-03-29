import { Component, HostListener, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { ContentBlock } from 'src/app/_interfaces/content-block';
import { ContentBlockForCreationDto } from 'src/app/_interfaces/content-block-for-creation-dto';
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

  @HostListener('window:beforeunload', ['$event'])
  handleBeforeUnload(event: Event) {
      event.returnValue = false;
  }
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
  contentBlock: ContentBlockForCreationDto={content:'',title:''};
  contentBlocks: ContentBlockForCreationDto[]=[];
  authorId?: any;
  galleryId:number;
  createPageForm:UntypedFormGroup=new UntypedFormGroup({});
  page:Page;
  modalRef?: BsModalRef | null;

  @ViewChild('staticTabs', { static: false }) staticTabs?: TabsetComponent;
 

    constructor(private pageService:PageService,private tokenService:TokenStorageService,private slugifyPipe:SlugifyPipe,
      private route:Router,private toaster:ToastrService,
      private modalService: BsModalService, private router:Router) { 
    
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
    
     

      this.createPageForm=new UntypedFormGroup({
 
        title: new UntypedFormControl(),
        content: new UntypedFormControl(),
        author: new UntypedFormControl(),
        slug: new UntypedFormControl(this.slug),
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
      if(this.contentBlocks.length>0){
        this.contentBlocks?.push(this.contentBlock);
      }
      
      let newPage:PageForCreationDto= {title:this.title,slug:this.slug===''?this.slugify(this.title):this.slugify(this.slug),
       excerpt:this.excerpt,sgImageId:this.image?.imageId,metaDescription:this.metaDescription,contentBlocks:this.contentBlocks,metaKeyWords:this.metaKeyWords,
      content:this.content,sgGalleryId:this.galleryId}
      this.pageService.createPage(newPage).subscribe(res=>{

  this.toaster.success("Your page has been created", "Success");
       this.route.navigateByUrl('/admin/pages')
     })
    }
    addFeatureImage(image:Image){
      this.image=image;
      this.selectTab(0);
    }

    getLoggedInUser(){
      let user= this.tokenService.getUser();
       return user.userName;
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
