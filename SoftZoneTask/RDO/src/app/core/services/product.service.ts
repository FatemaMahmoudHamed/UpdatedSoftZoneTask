import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';
@Injectable({ providedIn: 'root' })

export class ProductService extends DataService {
  
  static readonly BASE_URL: string = 'https://localhost:44390/';
  static readonly API_URL: string = Constants.BASE_URL + 'api/';

  constructor(http: HttpClient) {
    super(Constants.PRODUCT_API_URL, http);
  }

  getAllCases() {
    return this.http.get(Constants.ORDER_API_URL);
  }

}
