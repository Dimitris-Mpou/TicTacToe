import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  apiUrl = environment.apiUrl

  constructor(private http: HttpClient) {

  }

  getUsers() {
    return this.http.get<User[]>(this.apiUrl + "users")
  }

  getUser(username: string) {
    return this.http.get<User>(this.apiUrl + "users/" + username)
  }
}
