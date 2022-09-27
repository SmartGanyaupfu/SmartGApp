import { Inject, NgModule, PLATFORM_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatIconModule} from '@angular/material/icon';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ModalModule } from 'ngx-bootstrap/modal'; //volar-software
import {MatSidenavModule} from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { ShareButtonsModule } from 'ngx-sharebuttons/buttons';
import { ShareIconsModule } from 'ngx-sharebuttons/icons';



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
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { ResetPasswordComponent } from './auth/reset-password/reset-password.component';
import { ForgotPasswordComponent } from './auth/forgot-password/forgot-password.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmailConfirmationComponent } from './auth/email-confirmation/email-confirmation.component';
import { EditorModule, TINYMCE_SCRIPT_SRC } from '@tinymce/tinymce-angular';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SlugifyPipe } from './_pipes/slugify.pipe';
import { MediaComponent } from './shared/media/media.component';
import { UploadMediaComponent } from './shared/media/upload-media/upload-media.component';
import { PageListComponent } from './pages/page-list/page-list.component';
import { PageDetailComponent } from './pages/page-list/page-detail/page-detail.component';
import { EditPageComponent } from './pages/page-list/edit-page/edit-page.component';
import { NewPostComponent } from './pages/post-list/new-post/new-post.component';
import { PortfolioListComponent } from './pages/portfolio-list/portfolio-list.component';
import { NewPortfolioComponent } from './pages/portfolio-list/new-portfolio/new-portfolio.component';
import { EditPortfolioComponent } from './pages/portfolio-list/edit-portfolio/edit-portfolio.component';
import { PortfolioDetailComponent } from './pages/portfolio-list/portfolio-detail/portfolio-detail.component';
import { ServiceListComponent } from './pages/service-list/service-list.component';
import { NewServiceComponent } from './pages/service-list/new-service/new-service.component';
import { EditServiceComponent } from './pages/service-list/edit-service/edit-service.component';
import { ServiceDetailComponent } from './pages/service-list/service-detail/service-detail.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import {MatMenuModule} from '@angular/material/menu';
import { ContentBlockListComponent } from './pages/content-block-list/content-block-list.component';
import { NewContentBlockComponent } from './pages/content-block-list/new-content-block/new-content-block.component';
import { EditContentBlockComponent } from './pages/content-block-list/edit-content-block/edit-content-block.component';
import { CategoryListComponent } from './pages/category-list/category-list.component';
import { NewCategoryComponent } from './pages/category-list/new-category/new-category.component';
import { EditCategoryComponent } from './pages/category-list/edit-category/edit-category.component';
import { CategoryDetailComponent } from './pages/category-list/category-detail/category-detail.component';
import { CommentListComponent } from './pages/comment-list/comment-list.component';
import { NewCommentComponent } from './pages/comment-list/new-comment/new-comment.component';
import { EditCommentComponent } from './pages/comment-list/edit-comment/edit-comment.component';
import { PostListComponent } from './pages/post-list/post-list.component';
import { PostDetailComponent } from './pages/post-list/post-detail/post-detail.component';
import { EditPostComponent } from './pages/post-list/edit-post/edit-post.component';
import { TrustedUrlPipe } from './_pipes/trusted-url.pipe';
import { WidgetListComponent } from './pages/widget-list/widget-list.component';
import { NewWidgetComponent } from './pages/widget-list/new-widget/new-widget.component';
import { EditWidgetComponent } from './pages/widget-list/edit-widget/edit-widget.component';
import { SearchResultsComponent } from './pages/search-results/search-results.component';
import { SearchComponent } from './pages/search/search.component';
import { UserListComponent } from './pages/user-list/user-list.component';
import { NewUserComponent } from './pages/user-list/new-user/new-user.component';
import { JwtInterceptor, JwtModule } from '@auth0/angular-jwt';
import { TokenInterceptor } from './_interceptors/token.interceptor';
import { ShareButtonsComponent } from './shared/share-buttons/share-buttons.component';
import { GoogleAnalytics4Component } from './shared/google-analytics4/google-analytics4.component';


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
    SlugifyPipe,
    MediaComponent,
    UploadMediaComponent,
    PageListComponent,
    PageDetailComponent,
    EditPageComponent,
    PostListComponent,
    PostDetailComponent,
    EditPostComponent,
    NewPostComponent,
    PortfolioListComponent,
    NewPortfolioComponent,
    EditPortfolioComponent,
    PortfolioDetailComponent,
    ServiceListComponent,
    NewServiceComponent,
    EditServiceComponent,
    ServiceDetailComponent,
    DashboardComponent,
    ContentBlockListComponent,
    NewContentBlockComponent,
    EditContentBlockComponent,
    CategoryListComponent,
    NewCategoryComponent,
    EditCategoryComponent,
    CategoryDetailComponent,
    CommentListComponent,
    NewCommentComponent,
    EditCommentComponent,
    TrustedUrlPipe,
    WidgetListComponent,
    NewWidgetComponent,
    EditWidgetComponent,
    SearchResultsComponent,
    SearchComponent,
    UserListComponent,
    NewUserComponent,
    ShareButtonsComponent,
    GoogleAnalytics4Component,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatButtonModule,
    NgxSpinnerModule,
    ModalModule.forRoot(),
    EditorModule,
    MatSidenavModule,
    MatMenuModule,
    MatProgressBarModule,
    MatToolbarModule,
    MatDividerModule,
    CarouselModule.forRoot(),
    TabsModule.forRoot(),
    ToastrModule.forRoot({
      positionClass:'toast-bottom-right'
    }),
    ShareButtonsModule,
    ShareIconsModule,
  
    PaginationModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5000","localhost:5001"],
        disallowedRoutes: []
      }
    })
    
 
  ],
  providers: [SlugifyPipe,TrustedUrlPipe,{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
   ,{provide: HTTP_INTERCEPTORS,useClass:JwtInterceptor,multi:true},{ provide: HTTP_INTERCEPTORS,useClass:TokenInterceptor,multi: true},
    {provide:HTTP_INTERCEPTORS,useClass:LoadingInterceptor,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
