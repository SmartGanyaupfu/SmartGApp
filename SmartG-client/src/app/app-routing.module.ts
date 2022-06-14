import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmailConfirmationComponent } from './auth/email-confirmation/email-confirmation.component';
import { ForgotPasswordComponent } from './auth/forgot-password/forgot-password.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ResetPasswordComponent } from './auth/reset-password/reset-password.component';
import { ContactComponent } from './pages/contact/contact.component';
import { HomeComponent } from './pages/home/home.component';
import { LearnComponent } from './pages/learn/learn.component';
import { NewPageComponent } from './pages/new-page/new-page.component';
import { PortfolioComponent } from './pages/portfolio/portfolio.component';
import { PostComponent } from './pages/post/post.component';
import { ServiceComponent } from './pages/service/service.component';

const routes: Routes = [

  { path: '', redirectTo: '/home', pathMatch: 'full' },

  { path: 'home', component: HomeComponent},
  { path: 'service', component: ServiceComponent},
  { path: 'portfolio', component: PortfolioComponent},
  { path: 'blog', component: PostComponent},
  { path: 'contact', component: ContactComponent},
  { path: 'learn-to-code', component: LearnComponent},
  { path: 'admin/page/new-page', component: NewPageComponent},
  { path: 'admin/new-page', component: NewPageComponent},
  { path:  'auth/login',component:LoginComponent},
  { path:'auth/email-confirmation', component:EmailConfirmationComponent },
  { path: 'auth/forgot-password', component: ForgotPasswordComponent },
  { path: 'auth/reset-password', component: ResetPasswordComponent },
  { path: 'auth/register', component: RegisterComponent },

  {
    path: '**',
    redirectTo: '/home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
