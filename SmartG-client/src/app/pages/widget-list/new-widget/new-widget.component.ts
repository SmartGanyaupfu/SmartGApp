import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-new-widget',
  templateUrl: './new-widget.component.html',
  styleUrls: ['./new-widget.component.css']
})
export class NewWidgetComponent implements OnInit {

  

  createPageForm:FormGroup=new FormGroup({});

  constructor(private widgetService:WidgetService
    ,private toaster:ToastrService, 
      private router:Router, private route:ActivatedRoute) { 
    
    }

  initialiseForm(){
    this.createPageForm=new FormGroup({
     
    widgetId: new FormControl(),
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
        postPageSize: new FormControl(),
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
