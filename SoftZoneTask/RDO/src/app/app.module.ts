
import { NgModule, ErrorHandler, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { SharedModule } from '../shared/shared.module';
import { AppRoutes } from './app-routing.module';
import { AppComponent } from './app.component';
import { FullComponent } from './layouts/full/full.component';
import { AppBlankComponent } from './layouts/blank/blank.component';
import { AppHeaderComponent } from './layouts/full/header/header.component';
import { AppSidebarComponent } from './layouts/full/sidebar/sidebar.component';
import { AppBreadcrumbComponent } from './layouts/full/breadcrumb/breadcrumb.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from './demo-material-module';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { SpinnerComponent } from '../shared/spinner.component';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { AppErrorHandler } from '../shared/errors/app-error-handler';
import { ErrorService } from './core/services/error.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { FeatureModulesComponent } from './feature/feature-modules.component';
import { FeatureModulesRoutingModule } from './feature/feature-modules-routing.module';


const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
  wheelSpeed: 2,
  wheelPropagation: true,
};
@NgModule({
  declarations: [
    AppComponent,
    FullComponent,
    AppHeaderComponent,
    SpinnerComponent,
    AppBlankComponent,
    AppSidebarComponent,
    AppBreadcrumbComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    DemoMaterialModule,
    PerfectScrollbarModule,
    RouterModule.forRoot(AppRoutes, { relativeLinkResolution: 'legacy' }),
    FeatureModulesRoutingModule
    // SweetAlert2Module.forRoot(),
  ],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG,
    },
    {  // it will not show the errors in the html and the page just will be hung
      provide: ErrorHandler,
      useClass: AppErrorHandler,
    },

    ErrorService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
