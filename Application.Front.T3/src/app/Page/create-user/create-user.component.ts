import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/Model/User';
import { ServicesUser } from 'src/app/Services/services.user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  mostrar = false;
  formData:Usuario = {
    id: '',
    name: '',
    birthDate: new Date,
    gender: ''
};
  constructor(
    private serirceUser:ServicesUser,
    private router: Router
  ) { }

  ngOnInit(): void {
  }
  onSubmit(){
    this.serirceUser._postUsers(this.formData).subscribe();
    this.router.navigate(['/usuarioConsulta']);
  } 
  navigation(){    
    this.router.navigate(['/usuarioConsulta']);
  }
}
