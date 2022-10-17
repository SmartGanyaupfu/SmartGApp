import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, UntypedFormBuilder, UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';
import { Gallery } from 'src/app/_interfaces/gallery';
import { Image } from 'src/app/_interfaces/image';
import { Pagination } from 'src/app/_interfaces/pagination';
import { GalleryService } from 'src/app/_services/gallery.service';
import { MediaService } from 'src/app/_services/media.service';

@Component({
  selector: 'app-gallery-detail',
  templateUrl: './gallery-detail.component.html',
  styleUrls: ['./gallery-detail.component.css']
})
export class GalleryDetailComponent implements OnInit {

  galleryForm:UntypedFormGroup;
  gallery:Gallery;

  images : Image[]=[];
  arr2=new FormArray([]);
  selectedImages:any=[];
  pageNumber:number=1;
  pageSize:number=10;
  galleryId:any;
  

  public pagination:Pagination;

  constructor(private fb: UntypedFormBuilder,private mediaService: MediaService,
    private toastService:ToastrService, private galleryService:GalleryService, private router:Router,) {
    this.initialiseGalleryForm();
    //this.addRolesCheckboxes();
   
  }

  ngOnInit(): void {
    this.galleryId= this.router.url.split('?')[0].split('/').pop();

    if(history.state.galleryData){
      localStorage.setItem('galleryData',JSON.stringify(history.state.galleryData));
    this.gallery=JSON.parse(localStorage.getItem('galleryData'));
    //this.initialiseForm();
    }else {
      localStorage.removeItem('galleryData');
      this.galleryService.getGalleryById(this.galleryId).subscribe(res=>{
        this.gallery=res;
       // this.initialiseForm();
      })
    }
  this.getImages();
    //this.initialiseUserUpdateForm();
    //this.arr2=JSON.parse(localStorage.getItem("selectedImages" ));
    
  }
  isChecked(image){
    const index = this.arr2.controls.findIndex(x => x.value.imageUrl === image);
    //console.log(index)
    if (index!==-1){
      return true;
    }
    return false;
  }

  initialiseGalleryForm(){
    
    let mySelectedImages=  JSON.parse(localStorage.getItem("selectedImages" ));
   
  
    this.galleryForm= new UntypedFormGroup({
     title:new UntypedFormControl(),
    images: this.arr2,
    })
  }


  addGallery() {
  
  this.galleryService.newGallery(this.galleryForm.value).subscribe(res=>{
    this.toastService.success("U have successfully created a gallery", "Success");
    this.galleryForm.reset();
    this.arr2.clear();
    
  })
  
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
