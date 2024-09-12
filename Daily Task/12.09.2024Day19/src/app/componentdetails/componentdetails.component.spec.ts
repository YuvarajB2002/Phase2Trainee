import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentdetailsComponent } from './componentdetails.component';

describe('ComponentdetailsComponent', () => {
  let component: ComponentdetailsComponent;
  let fixture: ComponentFixture<ComponentdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentdetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComponentdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
