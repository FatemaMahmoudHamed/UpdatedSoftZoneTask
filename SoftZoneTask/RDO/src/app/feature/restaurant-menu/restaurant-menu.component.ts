
import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { product } from '../../../app/core/models/product';
import { Subscription } from 'rxjs';
import { LoaderComponent } from '../../../shared/components/loader/loader.component';
import { LoaderService } from '../../../app/core/services/loader.service';
import { AlertService } from '../../../app/core/services/alert.service';
import { RestaurantService } from '../../core/services/restaurant.service';
import { ProductService } from '../../core/services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxNavigationWithDataComponent } from 'ngx-navigation-with-data';
import { QueryObject } from 'src/app/core/models/query-objects';

@Component({
  selector: 'app-restaurant-menu',
  templateUrl: './restaurant-menu.component.html',
  styleUrls: ['./restaurant-menu.component.css']
})

export class RestaurantMenuComponent implements OnInit {
  imageURL="../../../assets/images/gallery/";
  rests: any[];
  id:any;
  products: product[]=[];

//pagination
  queryResult: any = {
    totalItems: 0,
    items: [],
  };
  PAGE_SIZE: number =3;
  queryObject: QueryObject = {
    sortBy: 'name',
    isSortAscending: true,
    page: 1,
    pageSize: this.PAGE_SIZE,
  };

  //
  private subs = new Subscription();
  constructor(
    private activatedRouter: ActivatedRoute,
    public restService: RestaurantService,
    public productService: ProductService,
    private alert: AlertService,
    public location: Location,
    public route: Router,
    private loaderService: LoaderService,
    public navCtrl: NgxNavigationWithDataComponent
  ) {
    this.activatedRouter.paramMap.subscribe((params) => {
      var id = params.get('id');
      if (id != null) {
        this.id = +id;
      }
    });
   }

  ngOnInit() {
    this.populateRestuarant();
  }
  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  onPageChange(page: number) {
    this.queryObject.page = page + 1;
    this.populateRestuarant();
  }

  populateRestuarant() {
    this.loaderService.startLoading(LoaderComponent);
    this.subs.add(
      this.productService.getWithQuery(this.queryObject).subscribe(
        (result: any) => {
          this.queryResult.totalItems = result.data.totalItems;
          this.queryResult.items = result.data.items;
          this.rests  = result.data.items as product[];
          this.rests.forEach(element => {
            element.restId=this.id;
          });
          console.log(this.rests);
          this.loaderService.stopLoading()
        },
        (error) => {
          console.error(error);
          this.alert.error('error has been happened');
          this.loaderService.stopLoading()
        }
      )
    );
  }

  AddToCart(e,rest:any)
  {
    if(e.target.checked)
    {
      this.products.push(rest)
    }
    else
    {
      this.products=this.products.filter(x=>x.id != rest.id);
    }
  }
  
  NextStep()
  {
    // this.route.navigate(['/reserve',]);
    // this.route.navigate([`/reserve`, { queryParams:this.products}]);
    console.log(this.products);
    this.navCtrl.navigate('/reserve-order',this.products);
  }
}


