import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from '../../environments/environment';
import { User } from '../_models/user';
import { MembersService } from '../_services/members.service';
import { PlayVsPlayerService } from '../_services/play-vs-player.service';

@Component({
  selector: 'app-play-vs-player',
  templateUrl: './play-vs-player.component.html',
  styleUrls: ['./play-vs-player.component.css']
})
export class PlayVsPlayerComponent implements OnInit {
  enemy: User
  

  constructor(public playVsPlayerService: PlayVsPlayerService, public memberService: MembersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadEnemy()
    this.playVsPlayerService
  }

  loadEnemy() {
    this.memberService.getUser(this.route.snapshot.paramMap.get('username')).subscribe(enemy => {
      this.enemy = enemy
      console.log(enemy)
    })
  }


  move(place) {
    this.playVsPlayerService.cell[place] = 2
    this.playVsPlayerService.playerAction()
  }

  playAgain() {
    this.playVsPlayerService.playAgain()
  }

}
