import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
baseUrl=environment.baseUrl
  constructor(private http:HttpClient) { }

  submitForm(form:any){
    return this.http.post(this.baseUrl+ 'contact-forms',form);
  }
}
