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
    //this.getAllProducts();
    this.getProductsSortedByName();
  }

  getAllProducts()
  {
    this.serviceApi.getAllProducts().subscribe(result =>
    {
      this.products = result as Agilence.ProductInventory[] ;
    }, error => console.error(error));
  }


  WriteIt(whatToWrite: string)
  {
    console.log(whatToWrite);
  }

  getProductsSortedByPrice()
  {
    this.getProductsSorted(Agilence.SortType.Price);

  }

  getProductsSortedByName()
  {
    this.getProductsSorted(Agilence.SortType.Name);

  }

  getProductsSortedByQuantity()
  {
    this.getProductsSorted(Agilence.SortType.Quantity);
  }


  getProductsSorted(sortedBy : Agilence.SortType)
  {
    this.products = undefined;
    this.serviceApi.getProductsSorted(sortedBy).subscribe(result =>
    {
      this.products = result as Agilence.ProductInventory[];
    }, error => console.error(error));
  }
}





interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
