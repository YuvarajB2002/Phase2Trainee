import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SampbindComponent } from './sampbind.component';

describe('SampbindComponent', () => {
  let component: SampbindComponent;
  let fixture: ComponentFixture<SampbindComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SampbindComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SampbindComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
