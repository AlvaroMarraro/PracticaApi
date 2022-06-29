import { Component, OnInit } from '@angular/core';
import { Usuario } from '../Interfaces/Usuario';
import {Router} from '@angular/router'
import{UsuarioProvider}from '../../Providers/UsuarioProvider'

@Component({
  selector: 'app-registrar-usuario',
  templateUrl: './registrar-usuario.component.html',
  styleUrls: ['./registrar-usuario.component.css']
})
export class RegistrarUsuarioComponent implements OnInit {

  usuario = {} as Usuario;

  constructor(private router:Router, private usuarioApi:UsuarioProvider) { }

  ngOnInit(): void {
  }

  async Registrar()
  {
    this.usuarioApi.createUsuario(this.usuario.nombreUsu, this.usuario.password).subscribe((data)=>
    {
      if(data.ok)
      {
        alert("Usuario Creado Correctamente");
        this.router.navigateByUrl('/login');
        
      }
      else
      {
        alert(data.error);
      }
    
    });

  }
  Atras()
  {
    this.router.navigateByUrl("/login")
  }

}
