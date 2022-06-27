import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { ContentBlock } from 'src/app/_interfaces/content-block';
import { Image } from 'src/app/_interfaces/image';
import { ContentBlockService } from 'src/app/_services/content-block.service';

@Component({
  selector: 'app-edit-content-block',
  templateUrl: './edit-content-block.component.html',
  styleUrls: ['./edit-content-block.component.css']
})
export class EditContentBlockComponent implements OnInit {

  slugEdit:boolean;
  show:boolean=true;
  image: Image;
  blockId:any='';
  title:string='';
  pageNumber:number=1;
  pageSize:number=20;

  page:ContentBlock;
  modalRef?: BsModalRef | null;

  updatePageForm:FormGroup=new FormGroup({});


  @ViewChild('staticTabs', { static: false }) staticTabs?: TabsetComponent;
  constructor(private blockService:ContentBlockService
    ,private toaster:ToastrService, 
      private router:Router, private route:ActivatedRoute) { 
    
    }

  initialiseForm(){
    this.updatePageForm=new FormGroup({
      title: new FormControl(),
      content: new FormControl(),
     
    });
  }
  setUpdatePageFromValue(){
    this.updatePageForm.patchValue({
      title: this.page?.title,
      content: this.page?.content,
      

    })
  }
  
    ngOnInit(): void {
      
     this.blockId= this.router.url.split('?')[0].split('/').pop();
     if(history.state.blockData){
      localStorage.setItem('blockData',JSON.stringify(history.state.blockData));
    this.page=JSON.parse(localStorage.getItem('blockData'));
    this.initialiseForm();
    this.setUpdatePageFromValue();
    }else {
      localStorage.removeItem('blockData');
      this.blockService.getBlockById(this.blockId).subscribe(res=>{
        this.page=res;
        this.initialiseForm();
    this.setUpdatePageFromValue();
      })
    }
   }


    updatePage(){
   

   
     console.log(this.updatePageForm.value)
      this.blockService.updateBlock(this.page.contentBlockId,this.updatePageForm.value).subscribe(res=>{
        this.toaster.success('Content block updated.','Success')
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
