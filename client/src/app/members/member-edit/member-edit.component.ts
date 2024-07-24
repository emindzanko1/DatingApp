import { Component, inject } from '@angular/core';
import { Member } from '../../_models/member';
import { AccountService } from '../../_services/account.service';
import { MembersService } from '../../_services/members.service';
import { TabsModule } from 'ngx-bootstrap/tabs';

@Component({
  selector: 'app-member-edit',
  standalone: true,
  imports: [TabsModule],
  templateUrl: './member-edit.component.html',
  styleUrl: './member-edit.component.css'
})
export class MemberEditComponent {
  member?: Member;
  private accountService = inject(AccountService);
  private memberService = inject(MembersService);

  ngOnInit(): void {

  }

  loadMember() {
    const user = this.accountService.currentUser();
    if (!user) return;
    this.memberService.getMember(user.username).subscribe({
      next: member => this.member = member
    });
  }

}
