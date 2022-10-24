import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Gallery } from 'src/app/_interfaces/gallery';
import { GalleryService } from 'src/app/_services/gallery.service';

@Component({
  selector: 'app-gallery-list',
  templateUrl: './gallery-list.component.html',
  styleUrls: ['./gallery-list.component.css']
})
export class GalleryListComponent implements OnInit {
  galleries:Gallery[];

  constructor(private galleryService:GalleryService, private toastr:ToastrService) { }

  ngOnInit(): void {
   this.getGalleries();

  }

getGalleries(){
  this.galleryService.getGalleryList().subscribe(res=>{
    this.galleries=res;
    
  })

}

deleteGallery(gallery:Gallery){
  if(confirm("Are you sure to delete, this is a permanent action ")) {
  this.galleryService.deleteGallery(gallery.galleryId).subscribe(res=>{
    this.galleries.splice(this.galleries.indexOf(gallery),1);
    this.toastr.success("Gallery deleted!","Deleted");
  })}
}

}
