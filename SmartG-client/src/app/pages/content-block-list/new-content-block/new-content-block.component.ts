import { Component, OnInit, ViewChild } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { Image } from 'src/app/_interfaces/image';
import { ContentBlockService } from 'src/app/_services/content-block.service';

@Component({
  selector: 'app-new-content-block',
  templateUrl: './new-content-block.component.html',
  styleUrls: ['./new-content-block.component.css']
})
export class NewContentBlockComponent implements OnInit {

  slugEdit:boolean;
  show:boolean=true;
  image: Image;
  blockId:any='';
  title:string='';
  pageNumber:number=1;
  pageSize:number=20;

  modalRef?: BsModalRef | null;

  createPageForm:UntypedFormGroup=new UntypedFormGroup({});


  @ViewChild('staticTabs', { static: false }) staticTabs?: TabsetComponent;
  constructor(private blockService:ContentBlockService
    ,private toaster:ToastrService, 
      private router:Router, private route:ActivatedRoute) { 
    
    }

  initialiseForm(){
    this.createPageForm=new UntypedFormGroup({
      title: new UntypedFormControl(),
      content: new UntypedFormControl(),
     
    });
  }
  
  
  
    ngOnInit(): void {
      
 
        this.initialiseForm();
   
    } 


    AddBlock(){
   
      this.blockService.createBlock(this.createPageForm.value).subscribe(res=>{
        this.toaster.success('Content block Added.','Success')
       this.router.navigateByUrl('/admin/content-blocks')
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
