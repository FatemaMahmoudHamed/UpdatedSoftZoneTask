export abstract class Constants {
  static readonly BASE_URL: string = 'https://localhost:44390/'; 
  static readonly API_URL: string = Constants.BASE_URL + 'api/';
  
  // Endpoints
  static readonly RESTAURANT_API_URL: string = Constants.API_URL + 'restaurants';
  static readonly ORDER_API_URL: string = Constants.API_URL + 'orders';
  static readonly CUSTOMERS_API_URL: string = Constants.API_URL + 'customers';
  static readonly PRODUCT_API_URL: string = Constants.API_URL + 'products';

}
