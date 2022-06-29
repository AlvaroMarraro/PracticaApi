import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
@Component({
  selector: 'app-deportes',
  templateUrl: './deportes.component.html',
  styleUrls: ['./deportes.component.css']
})
export class DeportesComponent implements OnInit {

  listaDeportes:any = [];

  constructor(private router: Router) { }

  ngOnInit(): void {
    //this.ObtenerDeportes();
  }

  async ObtenerDeportes()
  {
   /*  this.deporteApi.GetDeporte().subscribe((data) => {
    
        this.listaDeportes = data;

    }); */
  }

}
