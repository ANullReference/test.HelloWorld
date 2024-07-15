import { Component, NgModule } from '@angular/core';
import { Friend } from '../../models/friend.model';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FriendsService } from '../../services/friends.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-friend',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './add-friend.component.html',
  styleUrl: './add-friend.component.css'
})
export class AddFriendComponent {

  newFriend : Friend =
  {
    firstName : "",
    lastName : "",
    id : "",
    imageUrl : ""
  }

  constructor (private friendsService : FriendsService, private router : Router)
  {
  }

  addAFriend() {
    this.friendsService.AddFriend(this.newFriend)
      .subscribe(
        { next: (friend) => this.router.navigate(['friends']) }
      )
  }
}
