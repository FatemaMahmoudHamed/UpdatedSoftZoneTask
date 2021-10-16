import { Component, OnDestroy, OnInit } from '@angular/core';
import { LoaderService } from '../../../../app/core/services/loader.service';
import { LoaderComponent } from '../../../../shared/components/loader/loader.component';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { Subscription } from 'rxjs';
import { AlertService } from '../../../core/services/alert.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: []
})
export class AppHeaderComponent implements OnInit, OnDestroy {
  public config: PerfectScrollbarConfigInterface = {};
 

  private subs = new Subscription();

  constructor(
    public alert: AlertService,
    private loaderService: LoaderService,
    private router: Router,
  ) { }

  ngOnInit() {
  }
 

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

}