import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';
import { Observable } from 'rxjs';
@Injectable({ providedIn: 'root' })

export class CustomerService extends DataService {
  
  static readonly BASE_URL: string = 'https://localhost:44390/';
  static readonly API_URL: string = Constants.BASE_URL + 'api/';

  constructor(http: HttpClient) {
    super(Constants.CUSTOMERS_API_URL, http);
  }

  get(){
    return this.http.get(Constants.RESTAURANT_API_URL);
  }

  create(customer: any){
    return this.http.post(
      Constants.CUSTOMERS_API_URL + '/create',
      customer
    );
  }

}
