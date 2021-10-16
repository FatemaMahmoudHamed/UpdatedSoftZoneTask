import { Component, OnInit, ViewChild, TemplateRef, NgModule } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { FormGroup, FormBuilder } from '@angular/forms';
import { LoaderComponent } from '../../../shared/components/loader/loader.component';
import { LoaderService } from '../../../app/core/services/loader.service';
import { AlertService } from '../../../app/core/services/alert.service';
import { QueryObject } from '../../../app/core/models/query-objects';
import { RestaurantService } from '../../core/services/restaurant.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common'


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  displayedColumns: string[] = ['position', 'name', 'description', 'city'];
   imageURL="../../../assets/images/gallery/";
  queryResult: any = {
    totalItems: 0,
    items: [],
  };
  PAGE_SIZE: number = 5;
  queryObject: QueryObject = {
    sortBy: 'name',
    isSortAscending: true,
    page: 1,
    pageSize: this.PAGE_SIZE,
  };
  rests: any[] = [];
  allRests: any[] = [];
  showFilter: boolean = false;
  searchText: string = '';
  form: FormGroup = Object.create(null);
  @ViewChild('template', { static: true }) template:
    | TemplateRef<any>
    | undefined;
  private subs = new Subscription();
  constructor(
    public restService: RestaurantService,
    private dialog: MatDialog,
    private alert: AlertService,
    public location: Location,
    public route: Router,
    private loaderService: LoaderService,
    private fb: FormBuilder,
  ) { }

  ngOnInit() {
    this.form = this.fb.group({
      name: [''],
    });
    this.populateRestuarant();
  }
  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  populateRestuarant() {
    this.loaderService.startLoading(LoaderComponent);
    this.subs.add(
      this.restService.getWithQuery(this.queryObject).subscribe(
        (result: any) => {
          this.queryResult.totalItems = result.data.totalItems;
          this.queryResult.items = result.data.items;
          this.allRests = result.data.items;
          this.rests = this.allRests;
          this.loaderService.stopLoading()
        },
        (error) => {
          console.error(error);
          this.alert.error('Data has not been saved  ');
          this.loaderService.stopLoading()
        }
      )
    );
  }

  getMenuById(Id:number) {
    this.subs.add(
      this.restService.get(Id).subscribe(
        (result: any) => {
          this.route.navigate(['/menu',Id]);
        },
        (error) => {
          console.error(error);
          this.alert.error('فشلت عملية جلب البيانات !');
          this.loaderService.stopLoading()
        }
      )
    );
  }

  sortBy(column: string) {
    this.queryObject.sortBy = column;
    this.queryObject.isSortAscending = !this.queryObject.isSortAscending;
    this.populateRestuarant();
  }

  onPageChange(page: number) {
    this.queryObject.page = page + 1;
    this.populateRestuarant();
  }
 

  onSearch() {
    console.log(this.searchText.toLowerCase());

    if (this.searchText.length > 0)
      this.rests = this.allRests.filter(
        (u) => u.city.includes(this.searchText)||
        u.city.toLowerCase().includes(this.searchText.toLowerCase())
      );
    else this.rests = this.allRests;
  }
  
}

