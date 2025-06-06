import { Component, inject, OnInit } from '@angular/core';
import { MembesService } from '../../_services/membes.service';
import { ActivatedRoute } from '@angular/router';
import { Member } from '../../_models/member';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { GalleryItem, GalleryModule, ImageItem } from 'ng-gallery';

@Component({
  selector: 'app-member-detail',
  standalone: true,
  imports: [TabsModule, GalleryModule],
  templateUrl: './member-detail.component.html',
  styleUrl: './member-detail.component.css'
})
export class MemberDetailComponent implements OnInit {
  private memberService = inject(MembesService);
  private route = inject(ActivatedRoute);
  member?: Member;
  images : GalleryItem[] = [];

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember() {
    const username = this.route.snapshot.paramMap.get('username');

    if (!username) return;

    this.memberService.getMember(username).subscribe({
      next: member => {
        this.member = member, 
        member.photos.map(p => this.images.push(new ImageItem({src: p.url, thumb: p.url}))
      )},
      error: err => console.log(err),
      complete: () => console.log('completed')
    })
  }

}
