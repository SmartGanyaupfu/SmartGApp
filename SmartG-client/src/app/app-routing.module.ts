import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmailConfirmationComponent } from './auth/email-confirmation/email-confirmation.component';
import { ForgotPasswordComponent } from './auth/forgot-password/forgot-password.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ResetPasswordComponent } from './auth/reset-password/reset-password.component';
import { CategoryDetailComponent } from './pages/category-list/category-detail/category-detail.component';
import { CategoryListComponent } from './pages/category-list/category-list.component';
import { EditCategoryComponent } from './pages/category-list/edit-category/edit-category.component';
import { NewCategoryComponent } from './pages/category-list/new-category/new-category.component';
import { CommentListComponent } from './pages/comment-list/comment-list.component';
import { EditCommentComponent } from './pages/comment-list/edit-comment/edit-comment.component';
import { NewCommentComponent } from './pages/comment-list/new-comment/new-comment.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ContentBlockListComponent } from './pages/content-block-list/content-block-list.component';
import { EditContentBlockComponent } from './pages/content-block-list/edit-content-block/edit-content-block.component';
import { NewContentBlockComponent } from './pages/content-block-list/new-content-block/new-content-block.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { HomeComponent } from './pages/home/home.component';
import { LearnComponent } from './pages/learn/learn.component';
import { NewPageComponent } from './pages/new-page/new-page.component';
import { EditPageComponent } from './pages/page-list/edit-page/edit-page.component';
import { PageDetailComponent } from './pages/page-list/page-detail/page-detail.component';
import { PageListComponent } from './pages/page-list/page-list.component';
import { EditPortfolioComponent } from './pages/portfolio-list/edit-portfolio/edit-portfolio.component';
import { NewPortfolioComponent } from './pages/portfolio-list/new-portfolio/new-portfolio.component';
import { PortfolioDetailComponent } from './pages/portfolio-list/portfolio-detail/portfolio-detail.component';
import { PortfolioListComponent } from './pages/portfolio-list/portfolio-list.component';
import { PortfolioComponent } from './pages/portfolio/portfolio.component';
import { EditPostComponent } from './pages/post-list/edit-post/edit-post.component';
import { NewPostComponent } from './pages/post-list/new-post/new-post.component';
import { PostDetailComponent } from './pages/post-list/post-detail/post-detail.component';
import { PostListComponent } from './pages/post-list/post-list.component';
import { PostComponent } from './pages/post/post.component';
import { SearchResultsComponent } from './pages/search-results/search-results.component';
import { SearchComponent } from './pages/search/search.component';
import { EditServiceComponent } from './pages/service-list/edit-service/edit-service.component';
import { NewServiceComponent } from './pages/service-list/new-service/new-service.component';
import { ServiceDetailComponent } from './pages/service-list/service-detail/service-detail.component';
import { ServiceListComponent } from './pages/service-list/service-list.component';
import { ServiceComponent } from './pages/service/service.component';
import { NewUserComponent } from './pages/user-list/new-user/new-user.component';
import { UserListComponent } from './pages/user-list/user-list.component';
import { EditWidgetComponent } from './pages/widget-list/edit-widget/edit-widget.component';
import { NewWidgetComponent } from './pages/widget-list/new-widget/new-widget.component';
import { WidgetListComponent } from './pages/widget-list/widget-list.component';
import { MediaComponent } from './shared/media/media.component';
import { UploadMediaComponent } from './shared/media/upload-media/upload-media.component';
import { AuthGuardService } from './_services/auth-guard.service';
import { RoleGuardService } from './_services/role-guard.service';

const routes: Routes = [

  { path: '', redirectTo: '/home', pathMatch: 'full' },

  { path: 'home', component: HomeComponent},
  { path: 'service', component: ServiceComponent},
  { path: 'portfolio', component: PortfolioComponent},
  { path: 'blog', component: PostComponent},
  { path: 'contact', component: ContactComponent},
  { path: 'learn-to-code', component: LearnComponent},
  { path: 'admin/media',component: MediaComponent,canActivate:[AuthGuardService]},
  { path: 'admin/media/upload',component: UploadMediaComponent,canActivate:[AuthGuardService]},
  { path: 'admin/dashboard',component: DashboardComponent,canActivate:[AuthGuardService]},

  { path: 'admin/page/new-page', component: NewPageComponent,canActivate:[AuthGuardService]},
  { path: 'admin/page/edit/:pageId', component: EditPageComponent,canActivate:[AuthGuardService]},
  { path: 'admin/pages', component: PageListComponent,canActivate:[AuthGuardService]},
  { path: 'pages/:slug',component:PageDetailComponent},

  { path: 'admin/post/new-post', component: NewPostComponent,canActivate:[AuthGuardService]},
  { path: 'admin/post/edit/:postId', component: EditPostComponent,canActivate:[AuthGuardService]},
  { path: 'admin/posts', component: PostListComponent,canActivate:[AuthGuardService]},
  { path: 'blog/:slug',component:PostDetailComponent},

  { path: 'admin/portfolio/new-portfolio', component: NewPortfolioComponent,canActivate:[AuthGuardService]},
  { path: 'admin/portfolio/edit/:portfolioId', component: EditPortfolioComponent,canActivate:[AuthGuardService]},
  { path: 'admin/portfolios', component: PortfolioListComponent,canActivate:[AuthGuardService]},
  { path: 'portfolios/:slug',component:PortfolioDetailComponent},

  { path: 'admin/service/new-service', component: NewServiceComponent,canActivate:[AuthGuardService]},
  { path: 'admin/service/edit/:serviceId', component: EditServiceComponent,canActivate:[AuthGuardService]},
  { path: 'admin/services', component: ServiceListComponent,canActivate:[AuthGuardService]},
  { path: 'services/:slug',component:ServiceDetailComponent},

  { path: 'admin/block/new-block', component: NewContentBlockComponent,canActivate:[AuthGuardService]},
  { path: 'admin/block/edit/:blockId', component: EditContentBlockComponent,canActivate:[AuthGuardService]},
  { path: 'admin/content-blocks', component: ContentBlockListComponent,canActivate:[AuthGuardService]},

  { path: 'admin/category/new-category', component: NewCategoryComponent,canActivate:[AuthGuardService]},
  { path: 'admin/category/edit/:categoryId', component: EditCategoryComponent,canActivate:[AuthGuardService]},
  { path: 'admin/categories', component: CategoryListComponent,canActivate:[AuthGuardService]},
  { path: 'category/:slug',component:CategoryDetailComponent},

  { path: 'admin/comment/new-comment', component: NewCommentComponent},
  { path: 'admin/comment/edit/:commentId', component: EditCommentComponent},
  { path: 'admin/comments', component: CommentListComponent},

  { path: 'admin/widget/new-widget', component: NewWidgetComponent,canActivate:[AuthGuardService]},
  { path: 'admin/widget/edit/:widgetId', component: EditWidgetComponent,canActivate:[AuthGuardService]},
  { path: 'admin/widgets', component: WidgetListComponent,canActivate:[AuthGuardService]},


  { path: 'admin/users', component:UserListComponent,canActivate:[AuthGuardService,RoleGuardService]},
  { path: 'admin/new-user',component:NewUserComponent,canActivate:[AuthGuardService,RoleGuardService]},

  { path:  'auth/login',component:LoginComponent},
  { path:'auth/email-confirmation', component:EmailConfirmationComponent },
  { path: 'auth/forgot-password', component: ForgotPasswordComponent },
  { path: 'auth/reset-password', component: ResetPasswordComponent },
  { path: 'auth/register', component: RegisterComponent },
  { path: 'search', component: SearchResultsComponent},
  { path: 'search-form', component: SearchComponent},

  {
    path: '**',
    redirectTo: '/home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabledBlocking'
})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
