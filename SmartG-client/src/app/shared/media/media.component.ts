import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { finalize, Subscription } from 'rxjs';
import { Image } from 'src/app/_interfaces/image';
import { Pagination } from 'src/app/_interfaces/pagination';
import { MediaService } from 'src/app/_services/media.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-media',
  templateUrl: './media.component.html',
  styleUrls: ['./media.component.css']
})
export class MediaComponent implements OnInit {
  @Output() newImageSelectedEvent = new EventEmitter<Image>();

    fileName = '';
    uploadProgress:number;
    uploadSub: Subscription;
    baseUrl=environment.baseUrl;
    fileToUpload:File|null=null;
    public images:Image[];
    public pagination:Pagination;
    pageNumber:number=1;
  pageSize:number=10;
  modalRef?: BsModalRef | null;
  modalRef2?: BsModalRef;
  selectecdImage:Image;
    constructor(private mediaService: MediaService, private toastr:ToastrService,private modalService: BsModalService) {}
    ngOnInit(): void {
      this.getImages();
    }

    onFileSelected(event) {
        this.fileToUpload = event.target.files[0];
        this.fileName=this.fileToUpload.name;

    }
    uploadFile() {
      this.mediaService.uploadFile(this.fileToUpload).subscribe(data => {
       this.images.push(data);
        });
    }
    getImages(){
      this.mediaService.getImages(this.pageNumber,this.pageSize).subscribe(res=>{
        this.images=res.result;
        
        this.pagination=res.pagination;
      })
    }
    deleteImage(image:Image){
      let imageId=image.imageId
      this.mediaService.deleteImage(imageId).subscribe(res=>{
        this.toastr.success('Image deleted.', 'Deleted');
        //let imageDeleted= this.images.find(i=>i.imageId===imageId);
        this.images.splice(this.images.indexOf(image));
      
      })
    }
    pageChanged(event){
      this.pageNumber=event.page;
      this.getImages();
    }

    openModal(template: TemplateRef<any>, image:Image) {
      this.modalRef = this.modalService.show(template, { id: 1, class: 'modal-lg' });
      this.selectecdImage=image;
      
    }
    selectImage(image:Image){
      this.newImageSelectedEvent.emit(image);
    }
    openModal2(template: TemplateRef<any>) {
      this.modalRef2 = this.modalService.show(template, {id: 2, class: 'second' });
    }
    closeFirstModal() {
      if (!this.modalRef) {
        return;
      }
   
      this.modalRef.hide();
      this.modalRef = null;
    }
    closeModal(modalId?: number){
      this.modalService.hide(modalId);
    }

}
