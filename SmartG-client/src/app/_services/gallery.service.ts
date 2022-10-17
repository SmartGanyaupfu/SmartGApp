import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Gallery } from '../_interfaces/gallery';

@Injectable({
  providedIn: 'root'
})
export class GalleryService {

  baseurl:string= environment.baseUrl;
  constructor(private http:HttpClient) { }
  getGalleryList(){
   
    return this.http.get<Gallery[]>(this.baseurl +'gallery')
      
    
  }

  getGalleryById(galleryId:any){
    return this.http.get<Gallery>(this.baseurl + 'gallery/'+galleryId )
  }

  newGallery(gallery:any){
    return this.http.post<Gallery>(this.baseurl+ 'gallery/new-gallery/',gallery);
  }
  updateGallery(galleryId:number,gallery:any){
    return this.http.put(this.baseurl+ 'gallery/'+galleryId,gallery);
  }
  deleteGallery(galleryId:number){
    return this.http.delete<Gallery>(this.baseurl+'gallery/'+galleryId);
  }
}
