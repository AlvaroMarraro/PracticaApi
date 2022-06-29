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



}