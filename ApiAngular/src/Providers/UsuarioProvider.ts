import { Injectable } from "@angular/core";
import {HttpClient} from '@angular/common/http';
import { environment} from '../environments/environment';
import { Observable } from "rxjs/internal/Observable";
import { Usuario } from "src/app/Interfaces/Usuario";

@Injectable()
export class UsuarioProvider
{
    apiUrlBase: string = environment.urlBaseApi;

    constructor(private http: HttpClient)
    {

    }

    postLogin(nombreUsu:string, password:string): Observable<any>
    {
        const comando = {
            "nombreUsuario": nombreUsu,
            "password": password
          };
        
        const url = this.apiUrlBase + 'api/usuarios/Login';
        const headers = {'content-type': 'application/json'};
        const body = JSON.stringify(comando);
        return this.http.post(url,body,{'headers':headers});

    } 

    createUsuario(nombreUsu:string, password:string): Observable<any>
    {
        const comando =
        {
            "nombreUsuario": nombreUsu,
            "password": password
        };
        const url = this.apiUrlBase + 'api/usuarios/Create';
        const headers = {'content-type': 'application/json'};
        const body = JSON.stringify(comando);
        return this.http.post(url,body,{'headers':headers});

    }
} 