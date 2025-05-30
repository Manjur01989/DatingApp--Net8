import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { Member } from '../_models/member';
import { AccountService } from './account.service';
import { of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MembesService {
  private http = inject(HttpClient);
  private accountService = inject(AccountService);
  members = signal<Member[]>([]);
  baseUrl = environment.apiUrl;

  getMembers() {
    return this.http.get<Member[]>(this.baseUrl + 'users').subscribe({
      next: members => this.members.set(members)
    })
  };

  getMember(username: string) {
    const member = this.members().find(m => m.username === username);
    if (member !== undefined) return of(member);

    if (member !== undefined) return member;
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

  getHeaderOptions() {
    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.accountService.currentUser()?.token}`
      })
    }
  }

  updateMember(member: Member) {
    return this.http.put(this.baseUrl + 'users', member).pipe(
      tap(() => {
        this.members.update(members => members.map(m => m.username === member.username ? member : m));
      })
    )
  }
};
