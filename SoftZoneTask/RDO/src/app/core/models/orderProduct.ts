import {product} from "../models/product";

export class orderProduct  {
   id?:number;
   productId?:number;
   product? :product;
   quantity? :number;
   totalPrice? :number;
}
