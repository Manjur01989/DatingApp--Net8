import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule,BsDropdownModule,RouterLink,RouterLinkActive,TitleCasePipe],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  model: any = {};
  accountService = inject(AccountService);
  private toastr = inject(ToastrService);
  private route = inject(Router);

  login() {
    this.accountService.login(this.model).subscribe({
      next : _ => {
        this.route.navigateByUrl('/members');
      },
      error : err=> {
        this.toastr.error(err.error);
        console.log(err);
      }      
    })
  }

  logout(){
    this.accountService.logOut();
    this.route.navigateByUrl('/');
  }

}
