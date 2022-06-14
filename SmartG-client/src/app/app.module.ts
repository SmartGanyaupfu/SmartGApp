import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatIconModule} from '@angular/material/icon';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor, JwtModule, JWT_OPTIONS } from "@auth0/angular-jwt";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ServiceComponent } from './pages/service/service.component';
import { PortfolioComponent } from './pages/portfolio/portfolio.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SideBarComponent } from './shared/side-bar/side-bar.component';
import { PostComponent } from './pages/post/post.component';
import { LearnComponent } from './pages/learn/learn.component';
import { NewPageComponent } from './pages/new-page/new-page.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { TokenInterceptor } from './_interceptors/token.interceptor';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { ResetPasswordComponent } from './auth/reset-password/reset-password.component';
import { ForgotPasswordComponent } from './auth/forgot-password/forgot-password.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmailConfirmationComponent } from './auth/email-confirmation/email-confirmation.component';
import { EditorModule, TINYMCE_SCRIPT_SRC } from '@tinymce/tinymce-angular';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SlugifyPipe } from './_pipes/slugify.pipe';

export function tokenGetter() {
  return localStorage.getItem("mytoken");
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ContactComponent,
    ServiceComponent,
    PortfolioComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    RegisterComponent,
    SideBarComponent,
    PostComponent,
    LearnComponent,
    NewPageComponent,
    ResetPasswordComponent,
    ForgotPasswordComponent,
    EmailConfirmationComponent,
    SlugifyPipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatButtonModule,
    NgxSpinnerModule,
    EditorModule,
    TabsModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7212","localhost:5001"],
        disallowedRoutes: []
      }
    }),
    ToastrModule.forRoot({
      positionClass:'toast-bottom-right'
    }),
 
  ],
  providers: [SlugifyPipe,
    {provide: HTTP_INTERCEPTORS,useClass:JwtInterceptor,multi:true},{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS,useClass:TokenInterceptor,multi: true},
    {provide:HTTP_INTERCEPTORS,useClass:LoadingInterceptor,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
