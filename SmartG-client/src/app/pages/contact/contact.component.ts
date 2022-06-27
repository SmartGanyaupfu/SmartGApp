import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Page } from 'src/app/_interfaces/page';
import { Widget } from 'src/app/_interfaces/widget';
import { ContactService } from 'src/app/_services/contact.service';
import { PageService } from 'src/app/_services/page.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  page:Page;
  widget:Widget;
  name:string='';
  message:string='';
  email:string='';
  submitted=false;
  notification="Thanks for contacting me. Your message has been submited";
  constructor(private pageService:PageService, private widgetService:WidgetService,private toastr:ToastrService,
    private contactService:ContactService) { }

  ngOnInit(): void {
    this.getWidget();
  }

  getWidget(){
    this.widgetService.getWidget().subscribe(response=>{
      this.widget=response;
    })
  }
sendMessage(){
  let form={name:this.name,email:this.email,message:this.message};
  /*this.contactService.submitForm(form).subscribe(res=>{
    this.toastr.success('Thanks for contacting me. Your message has been submited','Success')
    form=null;
  })*/
  console.log(form);
  this.submitted=true;
  
}
}
