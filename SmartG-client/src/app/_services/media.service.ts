import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Image } from '../_interfaces/image';
import { PaginatedResult } from '../_interfaces/pagination';

@Injectable({
  providedIn: 'root'
})
export class MediaService {
  baseurl:string= environment.baseUrl;
  //service:Service;
  logoUrl:string="https://res.cloudinary.com/smart-ganyaupfu/image/upload/v1653230434/SG_logo_colour_mplpoc.png";

  paginatedResult:PaginatedResult<Image[]>= new PaginatedResult<Image[]>();
    
    constructor(private http:HttpClient) { }
    getImages(pageNumber?:number,pageSize?:number){
      const parmsObj={
    
        pageNumber:pageNumber||'',
        pageSize:pageSize||''
      };
      const params = new HttpParams({fromObject:parmsObj});
      return this.http.get<Image[]>(this.baseurl +'media',{observe:'response',params}).pipe(
        map(response=>{
          this.paginatedResult.result=response.body;
          if(response.headers.get('x-pagination')!==null){
            this.paginatedResult.pagination=JSON.parse(response.headers.get('x-pagination'));
          }
          
          return this.paginatedResult;
        })
      )
    }
  
    getImageById(imageId:number){
      return this.http.get<Image>(this.baseurl + 'media/'+imageId );
    }
  deleteImage(imageId:number){
    return this.http.delete(this.baseurl+'media/'+imageId);
  }
    uploadFile(filesToUpload: File[]) {
      const endpoint = this.baseurl+'media/add-image';
      const formData: FormData = new FormData();
     // filesToUpload.forEach(x=>formData.append('files', x,x.name))
      for(let i=0;i<filesToUpload.length;i++){
        formData.append('files', filesToUpload[i], filesToUpload[i].name);
      }
      //formData.append('files', filesToUpload, fileToUpload.name);
      return this.http.post<Image[]>(endpoint, formData);
  }
    updateImage(imageId:number,image:any){
      return this.http.put(this.baseurl+ 'media/'+imageId,image);
    }
    getLogo(){

    }
}
