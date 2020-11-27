import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { MembersService } from '../../_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  members: User[]

  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
    this.loadMembers()
  }

  loadMembers() {
    this.memberService.getUsers().subscribe(users => {
      this.members = users
    }, error => {
      console.log(error)
    })
  }

}
