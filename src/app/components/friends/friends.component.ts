import { Component } from '@angular/core';
import { Friend } from '../../models/friend.model';
import { NgFor, NgIf } from '@angular/common';
import { Router } from '@angular/router';
import { FriendsService } from '../../services/friends.service';

@Component({
  selector: 'app-friends',
  standalone: true,
  imports: [NgFor, NgIf],
  templateUrl: './friends.component.html',
  styleUrl: './friends.component.css'
})

export class FriendsComponent {

  friends : Friend[] ;

  constructor (private friendsService : FriendsService, private router : Router)
  {
    this.friends = [];
  }

  ngOnInit() : void
  {
    this.friendsService.getAllFriends()
    .subscribe(
      {
        next: (fetchedFriends : Friend[]) => { this.friends = fetchedFriends }
      }
     ),
     {
     error: (response: any) => {
      console.log (response);
     }
    }
  }
}
