import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PlayVsCpuService {
  baseUrl = environment.apiUrl
  cell: number[] = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0] /** 0-> empty, 1->X, 2->O, 3 4 5->telos paixnidiou*/

  constructor(private http: HttpClient) { }

  playerAction() {
    return this.http.post(this.baseUrl + "playVsCpu", this.cell).subscribe((cellsArr: number[]) => {
      for (let i = 0; i < 10; i++) {
        this.cell[i] = cellsArr[i]
      }
    }, error => {
      console.log(error)
    })
  }

  playAgain() {
    for (let i = 0; i < 10; i++) {
      this.cell[i] = 0
    }
  }
}
