import { Component, Input, OnInit,Output , EventEmitter} from '@angular/core';
import { FormGroup} from '@angular/forms';
import {  Usuario, UsuarioEdit } from 'src/app/Model/User';
import { ServicesUser } from 'src/app/Services/services.user';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  user: Usuario;
  @Input() modoEdicion: boolean = false;
  @Input() mostrarModal: boolean = false;
  @Input() usuarioEdit: UsuarioEdit;
  @Output() closeModal = new EventEmitter<boolean>();
  @Output() statusEdit = new EventEmitter<boolean>();

  personForm: FormGroup = new FormGroup({});
  opciones = [
    { id: 1, nombre: 'M' },
    { id: 2, nombre: 'F' }
  ];
  constructor(private serviceUser : ServicesUser) { 
    this.usuarioEdit = {} as UsuarioEdit;
    this.user = {} as Usuario;
    }

  ngOnInit(): void {
    
  }

  // Cierra el modal
 closedModal() {
    this.mostrarModal = false;
    this.closeModal.emit(false);
  }

  onFormSubmit() {
    this.user.id = this.usuarioEdit.id;
    this.user.name = this.usuarioEdit.name;
    if (this.usuarioEdit.birthDate) {this.user.birthDate = new Date(this.usuarioEdit.birthDate);}    
    this.user.gender = this.usuarioEdit.gender;
    this.serviceUser._putUsers(this.user, this.usuarioEdit.id).subscribe(res =>{
      if(res === "Successful upgrade!"){
        this.statusEdit.emit(true);
      }
      this.statusEdit.emit(false);
      this.closedModal();
    })
  }

}
