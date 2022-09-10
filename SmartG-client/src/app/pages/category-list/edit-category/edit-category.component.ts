import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/_interfaces/category';
import { SlugifyPipe } from 'src/app/_pipes/slugify.pipe';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit {
  slugEdit:boolean;
  show:boolean=true;
  slug:string='';
  name:string='';
  catId:any='';
  pageNumber:number=1;
  pageSize:number=20;
  page:Category;

url:any;
Murl='https://www.youtube.com/embed/IQjg2Y440l8';
  updatePageForm:UntypedFormGroup=new UntypedFormGroup({});

  constructor(private catService:CategoryService
    ,private toaster:ToastrService, private slugifyPipe:SlugifyPipe,
      private router:Router, private route:ActivatedRoute, private domSanitizer:DomSanitizer) { 
    
    }



  initialiseForm(){
    this.updatePageForm=new UntypedFormGroup({
      name: new UntypedFormControl(),
      slug: new UntypedFormControl(),
     
    });
  }
  
  slugify(input: string){
    return this.slugifyPipe.transform(input);
}

editSlug(){
  this.slugEdit= true;
  this.slug=this.slugify(this.page.slug);
  this.show=false;
}
  
    ngOnInit(): void {
      this.url = this.domSanitizer.bypassSecurityTrustUrl(this.Murl);
      
      this.catId= this.router.url.split('?')[0].split('/').pop();
/*
      if(history.state.categoryData){
       localStorage.setItem('categoryData',JSON.stringify(history.state.categoryData));
     this.page=JSON.parse(localStorage.getItem('categoryData'));
     this.initialiseForm();
     }else {
       localStorage.removeItem('categoryData');
       this.catService.getCategoryById(this.catId).subscribe(res=>{
         this.page=res;
         this.initialiseForm();
       })
     }
*/
        this.initialiseForm();
   
    } 


    updateCategory(){
      this.updatePageForm.patchValue({
        slug:this.slugify(this.slug)===''?this.slugify(this.page.slug):this.slugify(this.slug),
        name:this.page.name
      })
     console.log(this.updatePageForm.value)
     this.catService.updateCategory(this.page.categoryId, this.updatePageForm.value).subscribe(res=>{
        this.toaster.success('Category updated.','Success')
       this.router.navigateByUrl('/admin/categories')
     })
    }

}
