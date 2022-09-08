import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Widget } from 'src/app/_interfaces/widget';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-edit-widget',
  templateUrl: './edit-widget.component.html',
  styleUrls: ['./edit-widget.component.css']
})
export class EditWidgetComponent implements OnInit {

 page:Widget;
  
widgetId:any='';
  createPageForm:FormGroup=new FormGroup({});

  constructor(private widgetService:WidgetService
    ,private toaster:ToastrService, 
      private router:Router, private route:ActivatedRoute) { 
    
    }

  initialiseForm(){
    this.createPageForm=new FormGroup({
     
   
    skillBlock: new FormControl(),
    educationBlock: new FormControl(),
    workBlock: new FormControl(),
    interestBlock:new FormControl(),
    logoUrl: new FormControl(),
    cvUrl: new FormControl(),
    hireMeBlock: new FormControl(),
    fbUrl: new FormControl(),
    gitHubUrl: new FormControl(),
    twitterUrl: new FormControl(),
    youTubeUrl: new FormControl(),
    instagramUrl:new FormControl(),
    linkedInUrl:new FormControl(),
    email: new FormControl(),
    phone: new FormControl(),
    footerOne: new FormControl(),
    footerTwo: new FormControl(),
    footerThree: new FormControl(),
    profilePicture: new FormControl(),
    homePage: new FormControl(),
    learnToCode: new FormControl(),
    contactPage: new FormControl(),
    intro: new FormControl(),
    title: new FormControl(),
    footerCopyrightBlock: new FormControl(),
    homePageSize: new FormControl(),
    postPageSize: new FormControl()
    });
  }
  
  
  setUpdatePageFromValue(){
    this.createPageForm.patchValue({
      skillBlock: this.page?.skillBlock,
      educationBlock: this.page?.educationBlock,
      workBlock: this.page?.workBlock,
      interestBlock:this.page?.interestBlock,
      logoUrl: this.page?.logoUrl,
      cvUrl: this.page?.cvUrl,
      hireMeBlock:this.page?.hireMeBlock,
      fbUrl: this.page?.fbUrl,
      gitHubUrl: this.page?.gitHubUrl,
      twitterUrl: this.page?.twitterUrl,
      youTubeUrl: this.page?.youTubeUrl,
      instagramUrl:this.page?.instagramUrl,
      linkedInUrl:this.page?.linkedInUrl,
      email: this.page?.email,
      phone: this.page?.phone,
      footerOne: this.page?.footerOne,
      footerTwo: this.page?.footerTwo,
      footerThree: this.page?.footerThree,
       profilePicture: this.page?.profilePicture,
      homePage: this.page?.homePage,
      learnToCode: this.page?.learnToCode,
      contactPage: this.page?.contactPage,
      intro: this.page?.intro,
      title: this.page?.title,
      footerCopyrightBlock:this.page?.footerCopyrightBlock,
      homePageSize: this.page?.homePage,
      postPageSize: this.page?.postPageSize,
    })
  }
  
    ngOnInit(): void {
      
     this.widgetId= this.router.url.split('?')[0].split('/').pop();
     /*
     if(history.state.widgetData){
      localStorage.setItem('widgetData',JSON.stringify(history.state.widgetData));
    this.page=JSON.parse(localStorage.getItem('widgetData'));
    this.initialiseForm();
    this.setUpdatePageFromValue();
    }else {
      localStorage.removeItem('widgetData');
      this.widgetService.getWidgetById(this.widgetId).subscribe(res=>{
        this.page=res;
        this.initialiseForm();
    this.setUpdatePageFromValue();
      })
    } 
     */
 
        this.initialiseForm();
        this.setUpdatePageFromValue();
   
    } 


    updateWidget(){
     console.log(this.createPageForm.value)
      this.widgetService.updateWidget( this.widgetId,this.createPageForm.value).subscribe(res=>{
        this.toaster.success('Widget update.','Success')
       this.router.navigateByUrl('/admin/widgets')
     })
    }

}
