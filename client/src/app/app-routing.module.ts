import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { PlayVsCpuComponent } from './play-vs-cpu/play-vs-cpu.component';
import { PlayVsPlayerComponent } from './play-vs-player/play-vs-player.component';
import { PlayComponent } from './play/play.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'members', component: MemberListComponent, canActivate: [AuthGuard] },
  { path: 'members/:id', component: MemberDetailComponent, canActivate: [AuthGuard] },
  { path: 'vsplayer/:username', component: PlayVsPlayerComponent, canActivate: [AuthGuard] },
  { path: 'play', component: PlayComponent },
  { path: 'vscpu', component: PlayVsCpuComponent },
  { path: 'not-found', component: NotFoundComponent, },
  { path: '**', component: HomeComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
