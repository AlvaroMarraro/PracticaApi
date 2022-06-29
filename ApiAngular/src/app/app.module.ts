import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import{HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogInComponent } from './log-in/log-in.component';
import { RegistrarUsuarioComponent } from './registrar-usuario/registrar-usuario.component';
import { ListaPersonasComponent } from './lista-personas/lista-personas.component';
import { DeportesComponent } from './deportes/deportes.component';
import { UsuarioProvider } from 'src/Providers/UsuarioProvider';
import { PersonaProvider } from 'src/Providers/PersonaProvider';
import { EditarPersonaComponent } from './editar-persona/editar-persona.component';
import { CrearPersonaComponent } from './crear-persona/crear-persona.component';
import { DeporteProvider } from 'src/Providers/DeporteProvider';

@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    RegistrarUsuarioComponent,
    ListaPersonasComponent,
    DeportesComponent,
    EditarPersonaComponent,
    CrearPersonaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
   
  ],
  providers: [UsuarioProvider, PersonaProvider, DeporteProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
