import { Injectable } from '@angular/core';
import { Friend } from '../models/friend.model';
import { Observable } from 'rxjs';
import {HttpClient} from "@angular/common/http";
import { resourceLimits } from 'worker_threads';


@Injectable({
  providedIn: 'root'
})
export class FriendsService {

  //http://localhost:5251/api/Friends/GetFriends

  baseUrl : string = "http://localhost:5251";
  httpClient : HttpClient;

  constructor (private http: HttpClient)
  {
    this.httpClient = http;
  }

  ///using observable makes allows it to periodically fetch.....need to look into this one.
  getAllFriends  () : Observable<Friend[]>
  {
    return this.httpClient.get<Friend[]>(this.baseUrl + "/api/Friends/GetFriends");
  }

    ///using observable makes allows it to periodically fetch.....need to look into this one.
    AddFriend  (friend : Friend ): Observable<Friend>
    {
      return this.httpClient.put<Friend>(this.baseUrl + "/api/Friends/InsertFriend", friend);
    }
}
