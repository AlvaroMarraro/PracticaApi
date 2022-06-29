import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { Persona } from '../Interfaces/Persona';
import {PersonaProvider} from '../../Providers/PersonaProvider'

@Component({
  selector: 'app-editar-persona',
  templateUrl: './editar-persona.component.html',
  styleUrls: ['./editar-persona.component.css']
})
export class EditarPersonaComponent implements OnInit {

  persona = {} as Persona;
  idPersona:string = "";

  constructor(private router:Router, private personaApi: PersonaProvider, private route: ActivatedRoute)
  {
    this.idPersona = this.route.snapshot.params["id"];
    alert(this.idPersona);
  }

  ngOnInit(): void {
    this.ObtenerPersonas();
  }

  ObtenerPersonas()
  {
    this.personaApi.ObtenerPersonaId(this.idPersona).subscribe(data=>{
      if (data.ok)
      {
        this.persona.id = this.idPersona;
        this.persona.apellido = data.apellido;
        this.persona.nombre = data.nombre;
        this.persona.dni = data.dni;
        this.persona.sexo = data.sexo;
      }
    });
  }



  async Actualizar()
  {
    if(this.persona.nombre != null && this.persona.apellido != null && this.persona.dni != null)
    {
      this.personaApi.ActualizarPersona(this.persona).subscribe((data)=>
      {
        if(data.ok)
        {
          alert("Persona Actualizada");
          this.router.navigateByUrl("/listaPersonas");
        }

      });
      
    }
    else
    {
      alert("Por favor cargar todos los campos");
    }
  }

}
