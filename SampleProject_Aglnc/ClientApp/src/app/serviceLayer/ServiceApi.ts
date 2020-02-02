import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Injectable, Inject } from '@angular/core';
import { Agilence } from './Objects';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class AgilenceService
{
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private titleService: Title,
  ) { }

  getAllProducts()
  {
    var ret = this.http.get(this.baseUrl + 'api/ProductInventory/GetAllProducts');
    return ret;
  }


  getProductsSorted(sortType: Agilence.SortType)
  {
    var ret = this.http.get(this.baseUrl + 'api/ProductInventory/GetProductsSorted?sortedBy=' + sortType);
    return ret;
  }


}
