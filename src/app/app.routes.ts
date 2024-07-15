import { Routes } from '@angular/router';
import { FriendsComponent } from './components/friends/friends.component'

export const routes: Routes = [
  {
    path: '',
    component: FriendsComponent
  },
  {
    path: 'friends',
    component: FriendsComponent
  }
];
