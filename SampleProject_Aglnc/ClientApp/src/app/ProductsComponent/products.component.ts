import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Agilence } from '../serviceLayer/Objects'
import { AgilenceService } from '../serviceLayer/ServiceApi'

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})
export class ProductsComponent
{
  public products: Agilence.ProductInventory[];

  constructor(
    private serviceApi: AgilenceService
  )
  {
   
  }

  ngOnInit()
  {
    this.getAllProducts();
  }

  getAllProducts()
  {
    this.serviceApi.getAllProducts().subscribe(result =>
    {
      this.products = result as Agilence.ProductInventory[] ;
    }, error => console.error(error));
  }
}





interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
