import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeportesComponent } from './deportes/deportes.component';
import { ListaPersonasComponent } from './lista-personas/lista-personas.component';
import { LogInComponent } from './log-in/log-in.component';
import { RegistrarUsuarioComponent } from './registrar-usuario/registrar-usuario.component';

const routes: Routes = [
  {path: "login", component:LogInComponent},
  {path: "registrarUsuario", component:RegistrarUsuarioComponent},
  {path: "listaPersonas", component:ListaPersonasComponent},
  {path: "deportes", component:DeportesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
