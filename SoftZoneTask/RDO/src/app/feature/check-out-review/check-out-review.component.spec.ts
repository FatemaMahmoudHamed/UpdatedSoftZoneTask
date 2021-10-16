import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckOutReviewComponent } from './check-out-review.component';

describe('CheckOutReviewComponent', () => {
  let component: CheckOutReviewComponent;
  let fixture: ComponentFixture<CheckOutReviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckOutReviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckOutReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
