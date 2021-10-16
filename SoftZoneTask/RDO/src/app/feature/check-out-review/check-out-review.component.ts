import { ConfigurableFocusTrap } from '@angular/cdk/a11y';
import { Component, OnInit } from '@angular/core';
import { NgxNavigationWithDataComponent } from 'ngx-navigation-with-data';
import { OrderService } from 'src/app/core/services/order.service';
import { confirmData } from 'src/app/core/models/confirmData';
import { orderProduct } from 'src/app/core/models/orderProduct';
import { order } from 'src/app/core/models/order';
import { Subscription } from 'rxjs';
import { AlertService } from 'src/app/core/services/alert.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { LoaderComponent } from 'src/shared/components/loader/loader.component';
import { Router } from '@angular/router';
import { Location } from '@angular/common'
import Swal from 'sweetalert2';

@Component({
  selector: 'app-check-out-review',
  templateUrl: './check-out-review.component.html',
  styleUrls: ['./check-out-review.component.css']
})
export class CheckOutReviewComponent implements OnInit {

  confirmData: confirmData;
  order: order={id:0,customer:{},orderProducts:[],totalPrice:0,customerId:0};
  private subs = new Subscription();


  imageURL = "../../../assets/images/gallery/";

  constructor(public navCtrl: NgxNavigationWithDataComponent,
    public route: Router,
    public orderService: OrderService,
    private alert: AlertService,
    private loaderService: LoaderService,
    private location: Location
  ) {
    this.confirmData = this.navCtrl.data as confirmData
    console.log(this.confirmData);
    if(this.confirmData?.products?.length>0){
      this.confirmData?.products.forEach(element => {
        this.order.orderProducts.push({ id: 0, quantity: 1, product: element, totalPrice: element.price,productId:element.id })
        this.order.totalPrice = this.order.totalPrice+element.price;
      });
    }
    this.order.customer= this.confirmData.customer;
    this.order.customerId= this.confirmData.customer?.id;
  }

  ngOnInit(): void {
  }

  increaseProductQuantity(orderProduct: orderProduct) {
    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).quantity=
    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).quantity +1;

    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).totalPrice=
    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).quantity*
    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).product.price;

    this.order.totalPrice=this.order.totalPrice + this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).product.price;
  }

  decreaseProductQuantity(orderProduct: orderProduct) {
    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).quantity=
    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).quantity -1;

    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).totalPrice=
    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).quantity*
    this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).product.price;

    this.order.totalPrice=this.order.totalPrice - this.order.orderProducts.find(x => x.product.id == orderProduct.product.id).product.price;
  }

  removeProduct(orderProduct: orderProduct) {
    this.order.orderProducts.splice(this.order.orderProducts.findIndex(x => x.product.id == orderProduct.product.id),1);
    this.order.totalPrice = this.order.totalPrice - (orderProduct.quantity * orderProduct.product.price);
  }

  checkout() {
    this.loaderService.startLoading(LoaderComponent);
    let result$ = this.orderService.create(this.order);
    this.subs.add(
      result$.subscribe(
        (result: any) => {
          this.loaderService.stopLoading();
          Swal.fire('order will arrive as soon as possible').then(function() {
            this.route.navigate(['/home']);

        });
        
        },
        (error) => {
          console.error(error);
          this.alert.error('فشلت عملية الاضافة !');
          this.loaderService.stopLoading()
        }
      )
    );
  }
  back(){
    // this.location.back()
    this.navCtrl.navigate('/reserve-order',this.confirmData.products);
  }
}
