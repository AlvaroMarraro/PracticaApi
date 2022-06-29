import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Persona } from '../Interfaces/Persona';
import {PersonaProvider} from '../../Providers/PersonaProvider'

@Component({
  selector: 'app-crear-persona',
  templateUrl: './crear-persona.component.html',
  styleUrls: ['./crear-persona.component.css']
})
export class CrearPersonaComponent implements OnInit {

  persona = {} as Persona;

  //listaSexos = ["Masculino", "Femenino", "Otro"];
    
    listaSexos: any = [];
  constructor(private router:Router, private personaApi:PersonaProvider)
   {
      
   }

  ngOnInit(): void {
    //this.listaSexos;
    this.ObtenerListaSexos();
  }

  async CrearPersona()
  {
    this.personaApi.CrearPersonas(this.persona).subscribe((data)=>{
      if(data.ok)
      {
        alert("Persona creada Exitosamente")

      }else
      {
        alert(data.error);
        
      }

    });
  }

  async ObtenerListaSexos()
  {
    this.personaApi.ObtenerListaSexos().subscribe((data)=>{
      if(data.ok)
      {
        this.listaSexos = data.listaSexos;
      }
      else
      {
        data.error;
      }
    });
  }

  Volver()
  {
    this.router.navigateByUrl("/listaPersonas");
  }

}
