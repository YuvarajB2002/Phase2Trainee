import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DirectiveCompComponent } from './directive-comp.component';

describe('DirectiveCompComponent', () => {
  let component: DirectiveCompComponent;
  let fixture: ComponentFixture<DirectiveCompComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DirectiveCompComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DirectiveCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
