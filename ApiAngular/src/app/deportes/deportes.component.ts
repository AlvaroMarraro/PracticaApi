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
  urlImagenRugby:string ="";
  urlImagenFutbol:string="";
  urlImagenTenis:string = "";
  urlImagenNatacion:string = "";
  urlImagenBasket:string="";
  constructor(private router: Router, private deporteApi:DeporteProvider) { 
    
  }

  ngOnInit(): void {
    this.ObtenerDeportes();
    this.urlImagenRugby ="https://dle22gvyr6oyt.cloudfront.net/images/fecha-1_-pen%CC%83arol-vs-cobrasxv_-025.jpg";
    this.urlImagenFutbol="https://imagenes.elpais.com/resizer/_TbMK6TwGNfD-0xVj_fZdC4JUkE=/1960x1103/cloudfront-eu-central-1.images.arcpublishing.com/prisa/SU7EFDELFA7VVUEMTQNS26S4HQ.jpg";
    this.urlImagenTenis = "https://static3.abc.es/media/bienestar/2019/08/02/tenis-abecedario-kgNF--620x349@abc.jpg";
    this.urlImagenNatacion = "https://media.revistagq.com/photos/5d15d8da274222b14be3327b/16:9/w_2560%2Cc_limit/gentrit-sylejmani-JjUyjE-oEbM-unsplash.jpg";
    this.urlImagenBasket="https://estaticos-cdn.sport.es/clip/e896e1d1-b03c-4b59-8e24-e4ce59480f2e_alta-libre-aspect-ratio_default_0.jpg";
  }

  

  async ObtenerDeportes()
  {
     this.deporteApi.ObtenerDeportes().subscribe((data)=>{
      if(data.ok)
      {
        this.listaDeportes = data.listaDeportes;
        //let cantidadDeportes = this.listaDeportes.length;
        for (let i = 0; i < this.listaDeportes.length; i++)
        {
          let dep  = this.listaDeportes[i];
          if(dep.nombre == "Tenis")
          {
            dep.urlImagen = this.urlImagenTenis;
          }
          else if(dep.nombre == "Futbol")
          {
            dep.urlImagen = this.urlImagenFutbol;
          }
          else if(dep.nombre == "Rugby")
          {
            dep.urlImagen = this.urlImagenRugby;
          }
          else if(dep.nombre == "Natacion")
          {
            dep.urlImagen = this.urlImagenNatacion;
          }
          else if(dep.nombre == "Basket")
          {
            dep.urlImagen = this.urlImagenBasket;
          }
        }
        console.log(this.listaDeportes);
      }
      else
      {
        data.error;
      }

     });

    
  }

}
