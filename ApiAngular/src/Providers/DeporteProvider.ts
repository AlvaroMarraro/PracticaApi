import { Injectable } from "@angular/core";
import {HttpClient} from '@angular/common/http';
import { environment} from '../environments/environment';
import { Observable } from "rxjs/internal/Observable";

@Injectable()
export class DeporteProvider
{
    apiUrlBase: string = environment.urlBaseApi;

    constructor(private http: HttpClient)
    {

    }

    ObtenerDeportes():Observable<any>
    {
        const url = this.apiUrlBase + 'api/listaDeportes';
        const headers = {'content-type': 'application/json'};
        return this.http.get(url,{'headers':headers});
    }



}