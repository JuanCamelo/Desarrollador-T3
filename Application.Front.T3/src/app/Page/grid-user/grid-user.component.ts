import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesUser } from 'src/app/Services/services.user';
import { Usuario, UsuarioEdit } from "../../Model/User"

@Component({
  selector: 'app-grid-user',
  templateUrl: './grid-user.component.html',
  styleUrls: ['./grid-user.component.css']
})
export class GridUserComponent implements OnInit {

  usuarios: Usuario[] = []; // Define una lista de usuarios
  mostrarModal: boolean = false; // Define una propiedad para controlar la visibilidad del modal
  usuarioEdit: UsuarioEdit; // Define una propiedad para el usuario que se está editando
  modoEdicion: boolean = false; // Define una propiedad para controlar el modo de edición o agregación de usuario
  opciones = [
    { id: 1, nombre: 'M' },
    { id: 2, nombre: 'F' }
  ];
  constructor(private userService: ServicesUser,
    private router: Router,
    private datePipe: DatePipe) {
    this.usuarioEdit = {} as UsuarioEdit;
  }

  ngOnInit() {
    this.userService._getUsers().subscribe(res => {
      this.usuarios = res
    });
  }

  // Abre el modal para editar un usuario existente
  editarUsuario(usuario: Usuario) {
    this.usuarioEdit.id = usuario.id;
    this.usuarioEdit.name = usuario.name;
    this.usuarioEdit.gender = usuario.gender;
    const formattedDate = this.datePipe.transform(usuario.birthDate, 'yyyy-MM-dd');
    if (formattedDate !== null) {
      this.usuarioEdit.birthDate = formattedDate;
    }
    this.modoEdicion = true;
    this.mostrarModal = true;
  }

  closeModal(e: any) {
    this.modoEdicion = false;
    this.mostrarModal = false;
  }

  // Cierra el modal
  cerrarModal() {
    this.mostrarModal = false;
  }
  // Guarda los cambios de un usuario (edición o agregación)
  stateOfTheEdition(status:boolean) {
    if(status){
      this.userService._getUsers().subscribe(res => {
        this.usuarios = res
      });
    }
  }

  // Elimina un usuario de la lista
  eliminarUsuario(usuario: Usuario) {
    this.usuarios = this.usuarios.filter(u => u.id !== usuario.id);
    this.userService._deleteUsers(usuario.id).subscribe();
  }
  navigation() {
    this.router.navigate(['/usuario']);
  }
}

