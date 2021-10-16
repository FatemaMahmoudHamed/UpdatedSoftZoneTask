import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxNavigationWithDataComponent } from 'ngx-navigation-with-data';
import { Subscription } from 'rxjs';
import { confirmData } from 'src/app/core/models/confirmData';
import { product } from 'src/app/core/models/product';
import { AlertService } from 'src/app/core/services/alert.service';
import { CustomerService } from 'src/app/core/services/customer.service';
import { LoaderService } from 'src/app/core/services/loader.service';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reserve-order',
  templateUrl: './reserve-order.component.html',
  styleUrls: ['./reserve-order.component.css',]
})
export class ReserveOrderComponent implements OnInit {

  form: FormGroup = Object.create(null);
  products:product[];
  customer:confirmData;
  pattern="^01[0-2,5]{1}[0-9]{8}$";
  _confirmData:confirmData;
  // @ViewChild('template', { static: true }) template:
  // | TemplateRef<any>
  // | undefined;
private subs = new Subscription();

  constructor(public navCtrl: NgxNavigationWithDataComponent,
    public customerService: CustomerService,
    public route: Router,
    private location:Location,
    private alert:AlertService,
    private loaderService: LoaderService,
    private fb: FormBuilder) 
   {
    this.products=this.navCtrl.data as product[];
   }

  ngOnInit(): void {
    this.form = this.fb.group({
      id: [0],
      name: [''],
      email: [''],
      phone: [''],
      address: [''],
    });
  }
  
  onSubmit() {
    let result$ = this.customerService.create(this.form.value);
    this.subs.add(
      result$.subscribe(
        (result:any) => {
          console.log(result.data);
          this._confirmData={products:this.products,customer:result.data};
          console.log(this._confirmData);
          this.navCtrl.navigate('/checkout',this._confirmData);
        },
        (error) => {
          console.error(error);
          this.alert.error('فشلت عملية الاضافة !');
        }
      )
    );
  }
  back(){
    this.route.navigate(['/menu',this.products[0]?.restId]);
  }
}
