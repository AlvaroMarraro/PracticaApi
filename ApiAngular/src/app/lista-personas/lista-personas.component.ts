import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import { Persona } from '../Interfaces/Persona';
import {PersonaProvider} from '../../Providers/PersonaProvider'

@Component({
  selector: 'app-lista-personas',
  templateUrl: './lista-personas.component.html',
  styleUrls: ['./lista-personas.component.css']
})
export class ListaPersonasComponent implements OnInit {

  listaPersonas: any = [];

  persona = {} as Persona;

  constructor(private router: Router, private personaApi:PersonaProvider)
  { }

  ngOnInit(): void {
    this.CargarLista();
  }

  EditarPersona(id:string)
  {

  }

  CargarLista()
  {
    this.personaApi.ObtenerPersonas().subscribe((data)=>{
      if(data.ok){
        this.listaPersonas = data.listaPersonas;
      }
      else
      {
        data.error;
      }

    });
  }

}
