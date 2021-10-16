import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';

import { FeatureModulesRoutingModule } from './feature-modules-routing.module';
import { FeatureModulesComponent } from './feature-modules.component';
import { DemoMaterialModule } from '../demo-material-module';
import { HomeComponent } from './home/home.component';
import { CheckOutReviewComponent } from './check-out-review/check-out-review.component';
import { RestaurantMenuComponent } from './restaurant-menu/restaurant-menu.component';
import { ReserveOrderComponent } from './reserve-order/reserve-order.component';

@NgModule({
  declarations: [FeatureModulesComponent,HomeComponent,CheckOutReviewComponent,RestaurantMenuComponent, 
    ReserveOrderComponent],
  imports: [
    SharedModule,
    DemoMaterialModule,
    FeatureModulesRoutingModule
  ],
})
export class FeatureModulesModule { }
