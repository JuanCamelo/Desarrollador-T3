import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../Model/User';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ServicesUser extends BaseService {
  
  _getUsers(filters?: any): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.settings.get.userAPI + "/User", {
      params: filters as any,
    });
  };

  _postUsers(user: Usuario): Observable<any>{
    return this.http.post(this.settings.get.userAPI + "/User", user ,{
      responseType: 'text',
    });
  };

  _putUsers(user: Usuario, id: string): Observable<any>{
    return this.http.put(this.settings.get.userAPI + "/User/"+id, user,{
      responseType: 'text',
    });
  }; 
  _deleteUsers(id: string): Observable<any>{
    return this.http.delete(this.settings.get.userAPI + "/User/"+id,{
      responseType:'text'
    });
  };  
}
