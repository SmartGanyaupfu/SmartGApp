import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, UntypedFormBuilder, UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { json, Router } from 'express';
import { ToastrService } from 'ngx-toastr';
import { Image } from 'src/app/_interfaces/image';
import { Pagination } from 'src/app/_interfaces/pagination';
import { AuthService } from 'src/app/_services/auth.service';
import { MediaService } from 'src/app/_services/media.service';

@Component({
  selector: 'app-new-gallery',
  templateUrl: './new-gallery.component.html',
  styleUrls: ['./new-gallery.component.css']
})
export class NewGalleryComponent implements OnInit {
  galleryForm:UntypedFormGroup;

  images : Image[]=[];
  arr2=new FormArray([]);
  selectedImages:any=[];
  pageNumber:number=1;
  pageSize:number=10;

  public pagination:Pagination;

  constructor(private authenticationService:AuthService,private fb: UntypedFormBuilder,private mediaService: MediaService,
    private toastService:ToastrService) {
    this.initialiseGalleryForm();
    //this.addRolesCheckboxes();
   
  }

  ngOnInit(): void {
  this.getImages();
    //this.initialiseUserUpdateForm();
    //this.arr2=JSON.parse(localStorage.getItem("selectedImages" ));
    
  }
  isChecked(image){
    const index = this.arr2.controls.findIndex(x => x.value.imageUrl === image);
    console.log(index)
    if (index!==-1){
      return true;
    }
    return false;
  }

  initialiseGalleryForm(){
    
    let mySelectedImages=  JSON.parse(localStorage.getItem("selectedImages" ));
    /*let imagesFGs = this.arr2.map(x => {
      return this.fb.group({
        
        imageUrl: x?.imageUrl,
        caption: x?.caption,
        altText:x?.altText
      });
    });*/
  
    this.galleryForm= new UntypedFormGroup({
     title:new UntypedFormControl(),
    images: this.arr2,
    })
  }


  addGallery() {
   /*this.authenticationService.createUser(this.galleryForm.value).subscribe(response=>{
     
     this.toastService.success("Success","Gallery Successfully registered");
   });*/
   console.log(this.galleryForm.value);
  this.arr2=null;
   console.log(this.arr2)
  }

 
  getImages(){
    this.mediaService.getImages(this.pageNumber,this.pageSize).subscribe(res=>{
      this.images=res.result;
      
      this.pagination=res.pagination;
      this.initialiseGalleryForm();
    })
  }
  pageChanged(event){
    this.pageNumber=event.page;
    this.getImages();
  }

  

  onCheckboxChange(event: any) {
    
   

    if (event.target.checked) {
      //this.arr2.push(images);
      this.arr2.push(new FormControl(JSON.parse(event.target.value)));

    } else {
      const index = this.arr2.controls.findIndex(x => x.value === JSON.parse(event.target.value));
      this.arr2.removeAt(index);

    }
     
  }
}
