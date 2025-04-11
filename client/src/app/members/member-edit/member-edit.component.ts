import { Component, HostListener, inject, OnInit, ViewChild, viewChild } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { MembesService } from '../../_services/membes.service';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FormsModule, NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-member-edit',
  standalone: true,
  imports: [TabsModule,FormsModule],
  templateUrl: './member-edit.component.html',
  styleUrl: './member-edit.component.css'
})
export class MemberEditComponent implements OnInit {
  member: any = {};
  private memberService = inject(MembesService);
  private accountService = inject(AccountService);
  private toast = inject(ToastrService);
  @ViewChild('editForm') editForm?: NgForm;
  @HostListener('window:beforeunload', ['$event']) notify($event: any) {
    if (this.editForm?.dirty) {
      $event.returnValue = true;
    }
  }

  ngOnInit(): void {
    this.loadMember();
  }
  loadMember() {
    var user = this.accountService.currentUser();
    if (!user) { return; }
    this.memberService.getMember(user.username).subscribe({
      next: member => this.member = member,
      error: err => console.log(err),
      complete: () => console.log('completed')
    })
  }

  updateMember() {
    this.memberService.updateMember(this.member).subscribe({
      next: () => {
        this.toast.success('Profile updated successfully!');
        this.editForm?.reset(this.member);
      },
      error: err => {
        console.log(err);
        this.toast.error('Error updating profile!');
      },
      complete: () => console.log('completed')
    });
  }
}
