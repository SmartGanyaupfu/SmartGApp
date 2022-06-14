import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-email-confirmation',
  templateUrl: './email-confirmation.component.html',
  styleUrls: ['./email-confirmation.component.css']
})
export class EmailConfirmationComponent implements OnInit {

  public showSuccess: boolean=false;
  public showError: boolean=false;
  public errorMessage: string='';
  constructor(private _authService: AuthService, private _route: ActivatedRoute) { }
  ngOnInit(): void {
   this.confirmEmail();
  }
  private confirmEmail = () => {
    this.showError = this.showSuccess = false;
    const token = this._route.snapshot.queryParams['token'];
    const email = this._route.snapshot.queryParams['email'];
    this._authService.getEmailConfirmation(token, email)
    .subscribe( res=> {
      this.showSuccess = true;
    },
    error => {
      this.showError = true;
      this.errorMessage = error;
    })
  }

}
