import { Component, OnInit, ViewChild } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { Image } from 'src/app/_interfaces/image';
import { Service } from 'src/app/_interfaces/service';
import { SlugifyPipe } from 'src/app/_pipes/slugify.pipe';
import { ServiceService } from 'src/app/_services/service.service';

@Component({
  selector: 'app-edit-service',
  templateUrl: './edit-service.component.html',
  styleUrls: ['./edit-service.component.css']
})
export class EditServiceComponent implements OnInit {

  slugEdit:boolean;
  show:boolean=true;
  slug:string='';
  image: Image;
  serviceId:any='';
  title:string='';
  pageNumber:number=1;
  pageSize:number=20;

  page:Service;
  modalRef?: BsModalRef | null;

  updatePageForm:UntypedFormGroup=new UntypedFormGroup({});

  @ViewChild('staticTabs', { static: false }) staticTabs?: TabsetComponent;

  constructor(private serviceService:ServiceService,private slugifyPipe:SlugifyPipe
    ,private toaster:ToastrService, 
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
      
     this.serviceId= this.router.url.split('?')[0].split('/').pop();
  
     if(history.state.serviceData){
      localStorage.setItem('serviceData',JSON.stringify(history.state.serviceData));
    this.page=JSON.parse(localStorage.getItem('serviceData'));
    this.initialiseForm();
    this.setUpdatePageFromValue();
    }else {
      localStorage.removeItem('serviceData');
      this.serviceService.getServiceById(this.serviceId).subscribe(res=>{
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
   
      this.serviceService.updateService(this.page.offeredServiceId,this.updatePageForm.value).subscribe(res=>{
        this.toaster.success('Service updated.','Success')
       this.router.navigateByUrl('/admin/services')
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
