import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorModuleComponent } from './error-module/error-module.component';
import { NotFoundComponent } from './error-module/not-found/not-found.component';
import { FriendsListComponent } from './friends/friends-list/friends-list.component';
import { FriendsProfileComponent } from './friends/friends-profile/friends-profile.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { TestErrorsComponent } from './test-errors/test-errors.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'friends',
        component: FriendsListComponent,
        canActivate: [AuthGuard],
      },
      { path: 'friends/:id', component: FriendsProfileComponent },
      { path: 'lists', component: ListsComponent },
      { path: 'messages', component: MessagesComponent },
    ],
  },
  { path: 'errors', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'error', component: ErrorModuleComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
