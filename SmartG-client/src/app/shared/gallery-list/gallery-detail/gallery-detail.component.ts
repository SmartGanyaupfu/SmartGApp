import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormArray, FormControl, UntypedFormBuilder, UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import { ToastrService } from 'ngx-toastr';
import { Gallery } from 'src/app/_interfaces/gallery';
import { GalleryImage } from 'src/app/_interfaces/gallery-image';
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
  
  selectecdImage:GalleryImage;

  modalRef?: BsModalRef | null;
  modalRef2?: BsModalRef;

  public pagination:Pagination;

  constructor(private fb: UntypedFormBuilder,private mediaService: MediaService,private modalService: BsModalService,
    private toastService:ToastrService, private galleryService:GalleryService, private router:Router,) {
    this.initialiseGalleryForm();
    //this.addRolesCheckboxes();
   
  }

  ngOnInit(): void {
    this.galleryId= this.router.url.split('?')[0].split('/').pop();

    if(history.state.galleryData){
      localStorage.setItem('galleryData',JSON.stringify(history.state.galleryData));
    this.gallery=JSON.parse(localStorage.getItem('galleryData'));
    //this.arr2.push(this.gallery.images);
    }else {
      localStorage.removeItem('galleryData');
      this.galleryService.getGalleryById(this.galleryId).subscribe(res=>{
        this.gallery=res;
       // this.initialiseForm();
       //this.arr2.push(this.gallery.images);
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
    
    //let mySelectedImages=  JSON.parse(localStorage.getItem("selectedImages" ));
   
  
    this.galleryForm= new UntypedFormGroup({
     title:new UntypedFormControl(),
    images: this.arr2,
    })
  }


  updateGallery() {
  
  this.galleryService.updateGallery(this.galleryId,this.gallery).subscribe(res=>{
    this.toastService.success("U have successfully updated a gallery", "Success");
    this.galleryForm.reset();
    this.arr2.clear();
    
  })

  
  }
 

  removeImageFromGallery(image){
    this.gallery.images.splice(this.gallery.images.indexOf(image),1);
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
      this.gallery.images.push(JSON.parse(event.target.value));
      console.log(this.gallery);

    } else {
      const index = this.arr2.controls.findIndex(x => x.value === JSON.parse(event.target.value));
      this.arr2.removeAt(index);
      
    }
     
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { id: 1, class: 'modal-xl' });
    //this.selectecdImage=image;
    
  }
 
  
 
  closeModal(modalId?: number){
    this.modalService.hide(modalId);
  }

}
