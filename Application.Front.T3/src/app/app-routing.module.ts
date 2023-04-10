import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateUserComponent } from './Page/create-user/create-user.component';
import { GridUserComponent } from './Page/grid-user/grid-user.component';

const routes: Routes = [
  {
    path: 'usuario',
    component: CreateUserComponent
  },
  {
    path: 'usuarioConsulta',
    component: GridUserComponent
  },
  {
    path:'**',
    redirectTo: 'usuario'
  },
  { path: '', redirectTo: '/usuario', pathMatch: 'full' },
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
