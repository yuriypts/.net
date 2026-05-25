import { Routes } from '@angular/router';
import { Hello } from './hello/hello';
import { About } from './about/about';
import { User } from './user/user';

export const routes: Routes = [
  {
    path: '',
    component: About
  },
  {
    path: 'hello',
    component: Hello
  },
  {
    path: 'user',
    component: User
  },
];
