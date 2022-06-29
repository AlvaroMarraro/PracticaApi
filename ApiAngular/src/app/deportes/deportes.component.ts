import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {DeporteProvider} from '../../Providers/DeporteProvider'


@Component({
  selector: 'app-deportes',
  templateUrl: './deportes.component.html',
  styleUrls: ['./deportes.component.css']
})
export class DeportesComponent implements OnInit {

  listaDeportes:any = [];

  constructor(private router: Router, private deporteApi:DeporteProvider) { }

  ngOnInit(): void {
    this.ObtenerDeportes();
  }

  async ObtenerDeportes()
  {
     this.deporteApi.ObtenerDeportes().subscribe((data)=>{
      if(data.ok)
      {
        this.listaDeportes = data.listaDeportes;
      }
      else
      {
        data.error;
      }

     });

    
  }

}
