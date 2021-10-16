import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {  RxReactiveFormsModule } from "@rxweb/reactive-form-validators"

import { MenuItems } from './menu-items/menu-items';
import {
  AccordionAnchorDirective,
  AccordionLinkDirective,
  AccordionDirective,
} from './accordion';
import { NumbersOnlyValidatorDirective } from './validators/numbers-only-validator.directive';
import { MatchValidatorDirective } from './validators/match-validator.directive';
import { MobileValidatorDirective } from './validators/mobile-validator.directive';
import { ValidNameValidator } from './validators/valid-name-validator.directive';
import { MobileValidator2Directive } from './validators/mobile-validator2.directive';
import { LoaderComponent } from './components/loader/loader.component';
import { AngularMaterialComponentsModule } from './modules/angular-material-components.module';
import { ErrorDialogComponent } from './components/error-dialog/error-dialog.component';
import { NgxNavigationWithDataComponent } from "ngx-navigation-with-data";


const MODULES = [
  CommonModule,
  FormsModule,
  ReactiveFormsModule,
  RxReactiveFormsModule,
  HttpClientModule,
  AngularMaterialComponentsModule,
  FlexLayoutModule,
];
const COMPONENTS = [
  LoaderComponent,
  ErrorDialogComponent,
];

const DIRECTIVES = [
  //DragDropDirective,
  NumbersOnlyValidatorDirective,
  MatchValidatorDirective,
  MobileValidatorDirective,
  MobileValidator2Directive,
  ValidNameValidator,
  AccordionAnchorDirective,
  AccordionLinkDirective,
  AccordionDirective,
];

const PIPES = [
];

@NgModule({
  imports: [...MODULES],
  declarations: [...COMPONENTS, ...DIRECTIVES, ...PIPES],
  exports: [...COMPONENTS, ...DIRECTIVES, ...PIPES, ...MODULES],

  providers: [MenuItems,NgxNavigationWithDataComponent],
})
export class SharedModule {}
