import {customer} from "./customer";
import { orderProduct } from "./orderProduct";

export class order  {
   id?:number=0;
   customer:customer;
   customerId?:number;
   orderProducts :orderProduct[];
   totalPrice :number;
}
