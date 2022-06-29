import { Injectable } from "@angular/core";
import {HttpClient} from '@angular/common/http';
import { environment} from '../environments/environment';
import { Observable } from "rxjs/internal/Observable";
import { Persona } from "src/app/Interfaces/Persona";

@Injectable()
export class PersonaProvider{

    apiUrlBase: string = environment.urlBaseApi;

    constructor(private http: HttpClient)
    {

    }

    
    ObtenerPersonas():Observable<any>
    {
        const url = this.apiUrlBase + 'api/listaPersonas';
        const headers = {'content-type': 'application/json'};
        return this.http.get(url,{'headers':headers});
    }

    ObtenerPersonaId(id:string):Observable<any>
    {
        const url = this.apiUrlBase + 'api/persona/GetPersona/' + id;
        const headers = {'content-type': 'application/json'};
        return this.http.get(url,{'headers': headers});

    }

    ActualizarPersona(persona: Persona) : Observable<any>
    {
       
        const url = this.apiUrlBase + 'api/persona/UpdatePersona';
        const headers = {'content-type': 'application/json'};
        const body = JSON.stringify(persona);
        return this.http.put(url,body,{'headers':headers});
    }

    CrearPersonas(persona: Persona):Observable<any>
    {
        /* const comando = {
            "nombre": persona.nombre,
            "apellido": persona.apellido,
            "dni": persona.dni,
            "sexo": persona.sexo,
            "calle": persona.calle,
            "numbre": persona.numero
        } */
        const url = this.apiUrlBase + 'api/crearPersona';
        const headers = {'content-type': 'application/json'};
        const body = JSON.stringify(persona);
        return this.http.post(url,body,{'headers':headers})
    }



}