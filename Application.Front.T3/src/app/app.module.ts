import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DatePipe } from '@angular/common';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CreateUserComponent } from './Page/create-user/create-user.component';
import { GridUserComponent } from './Page/grid-user/grid-user.component';
import { FormsModule } from '@angular/forms';
import { EditUserComponent } from './Page/grid-user/component/edit-user/edit-user.component';

import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ServicesInjection } from './Services/dependencyInjection';

import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CreateUserComponent,
    GridUserComponent,
    EditUserComponent
  ],
  imports: [
    FormsModule,
    ComponentsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    DatePipe,
    ServicesInjection
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
