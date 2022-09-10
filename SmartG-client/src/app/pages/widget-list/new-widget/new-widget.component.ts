import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-new-widget',
  templateUrl: './new-widget.component.html',
  styleUrls: ['./new-widget.component.css']
})
export class NewWidgetComponent implements OnInit {

  

  createPageForm:UntypedFormGroup=new UntypedFormGroup({});

  constructor(private widgetService:WidgetService
    ,private toaster:ToastrService, 
      private router:Router, private route:ActivatedRoute) { 
    
    }

  initialiseForm(){
    this.createPageForm=new UntypedFormGroup({
     
    widgetId: new UntypedFormControl(),
    skillBlock: new UntypedFormControl(),
    educationBlock: new UntypedFormControl(),
    workBlock: new UntypedFormControl(),
    interestBlock:new UntypedFormControl(),
    logoUrl: new UntypedFormControl(),
    cvUrl: new UntypedFormControl(),
    hireMeBlock: new UntypedFormControl(),
    fbUrl: new UntypedFormControl(),
    gitHubUrl: new UntypedFormControl(),
    twitterUrl: new UntypedFormControl(),
    youTubeUrl: new UntypedFormControl(),
    instagramUrl:new UntypedFormControl(),
    linkedInUrl:new UntypedFormControl(),
    email: new UntypedFormControl(),
    phone: new UntypedFormControl(),
    footerOne: new UntypedFormControl(),
    footerTwo: new UntypedFormControl(),
    footerThree: new UntypedFormControl(),
    profilePicture: new UntypedFormControl(),
        homePage: new UntypedFormControl(),
        learnToCode: new UntypedFormControl(),
        contactPage: new UntypedFormControl(),
        intro: new UntypedFormControl(),
        title: new UntypedFormControl(),
        footerCopyrightBlock: new UntypedFormControl(),
        homePageSize: new UntypedFormControl(),
        postPageSize: new UntypedFormControl(),
    });
  }
  
  
  
    ngOnInit(): void {
      
 
        this.initialiseForm();
   
    } 


    AddWidget(){
     console.log(this.createPageForm.value)
      this.widgetService.createWidget(this.createPageForm.value).subscribe(res=>{
        this.toaster.success('Widget Added.','Success')
       this.router.navigateByUrl('/admin/widgets')
     })
    }
}
