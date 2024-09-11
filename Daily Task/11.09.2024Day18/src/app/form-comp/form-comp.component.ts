import { Component } from '@angular/core';
import { Country } from '../../Country';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-form-comp',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './form-comp.component.html',
  styleUrl: './form-comp.component.css'
})
export class FormCompComponent {
  lstcountry:Country[]=[
    new Country(111,"India"),
    new Country(112,"US"),
    new Country(113,"UK")
   ]

   onSubmit(contactForm:any) {
    console.log(contactForm.value);
  }
}
