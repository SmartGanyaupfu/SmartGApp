import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SlugifyPipe } from 'src/app/_pipes/slugify.pipe';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'app-new-category',
  templateUrl: './new-category.component.html',
  styleUrls: ['./new-category.component.css']
})
export class NewCategoryComponent implements OnInit {
  slugEdit:boolean;
  show:boolean=true;
  slug:string='';
  name:string='';
  blockId:any='';
  pageNumber:number=1;
  pageSize:number=20;


  createPageForm:UntypedFormGroup=new UntypedFormGroup({});

  constructor(private catService:CategoryService
    ,private toaster:ToastrService, private slugifyPipe:SlugifyPipe,
      private router:Router, private route:ActivatedRoute) { 
    
    }

  initialiseForm(){
    this.createPageForm=new UntypedFormGroup({
      name: new UntypedFormControl(),
      slug: new UntypedFormControl(),
     
    });
  }
  
  slugify(input: string){
    return this.slugifyPipe.transform(input);
}

editSlug(){
  this.slugEdit= true;
  this.slug=this.slugify(this.name);
  this.show=false;
}
  
    ngOnInit(): void {
      
 
        this.initialiseForm();
   
    } 


    AddCategory(){
      this.createPageForm.patchValue({
        slug:this.slugify(this.slug)===''?this.slugify(this.name):this.slugify(this.slug),
        name:this.name
      })
      this.catService.createCategory(this.createPageForm.value).subscribe(res=>{
        this.toaster.success('Category block Added.','Success')
       this.router.navigateByUrl('/admin/categories')
     })
    }
 
}
