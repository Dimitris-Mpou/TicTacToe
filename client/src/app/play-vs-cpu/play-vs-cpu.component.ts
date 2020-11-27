import { Component, OnInit } from '@angular/core';
import { PlayVsCpuService } from '../_services/play-vs-cpu.service';

@Component({
  selector: 'app-play-vs-cpu',
  templateUrl: './play-vs-cpu.component.html',
  styleUrls: ['./play-vs-cpu.component.css']
})
export class PlayVsCpuComponent implements OnInit {

  constructor(public playVsCpuService: PlayVsCpuService) { }

  ngOnInit(): void {
  }

  move(place) {
    this.playVsCpuService.cell[place] = 2
    this.playVsCpuService.playerAction()
  }

  playAgain() {
    this.playVsCpuService.playAgain()
  }

}
