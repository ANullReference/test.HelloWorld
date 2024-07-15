import { Component } from '@angular/core';
import { Friend } from '../../models/friend.model';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-friends',
  standalone: true,
  imports: [NgFor, NgIf],
  templateUrl: './friends.component.html',
  styleUrl: './friends.component.css'
})

export class FriendsComponent {

  friends : Friend[] =
  [
    { id : "a", firstName : "john", lastName: "doe", imageUrl : ""  },
    { id : "b", firstName : "jane", lastName: "doe", imageUrl : ""  },
    { id : "c", firstName : "mark", lastName: "tux", imageUrl : ""  },
    { id : "d", firstName : "tyson", lastName: "fury", imageUrl : "" },
    { id : "e", firstName : "Hinata", lastName: "Shouyu", imageUrl : "" }
  ]
}
