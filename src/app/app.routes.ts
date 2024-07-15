import { Routes } from '@angular/router';
import { FriendsComponent } from './components/friends/friends.component'
import { AddFriendComponent } from './components/add-friend/add-friend.component'


export const routes: Routes = [
  {
    path: '',
    component: FriendsComponent
  },
  {
    path: 'friends',
    component: FriendsComponent
  },
  {
    path: 'friends/add',
    component: AddFriendComponent
  }
];
