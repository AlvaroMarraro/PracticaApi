import { Component, OnInit } from '@angular/core';
import { Usuario } from '../Interfaces/Usuario';
import{Router} from '@angular/router'
import{UsuarioProvider} from '../../Providers/UsuarioProvider'

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  usuario = {} as Usuario;

  constructor(private router:Router,private usuarioApi:UsuarioProvider ) 
  { }

  ngOnInit(): void {
  }


  LogIn()
  {
    this.usuarioApi.postLogin(this.usuario.nombreUsu, this.usuario.password).subscribe((data)=>
    { 
      if(data.ok)
      {
        alert("Bienvenido " + this.usuario.nombreUsu);
        this.router.navigateByUrl('/listaPersonas');
      }else
      {
        alert(data.ok);
      }

    });
    
  }  
  Registrar()
  {
    this.router.navigateByUrl('/registrarUsuario');
    
  }

}
