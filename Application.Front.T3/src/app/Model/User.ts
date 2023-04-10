export class Usuario {
    id: string;
    name: string;
    birthDate: Date;
    gender:string;
    constructor(){
      this.id = '';
      this.name= "";
      this.birthDate = new Date;
      this.gender = ''
    }
  }

  export interface UsuarioEdit {
    id: string;
    name: string;
    birthDate?: string;
    gender:string;
  }