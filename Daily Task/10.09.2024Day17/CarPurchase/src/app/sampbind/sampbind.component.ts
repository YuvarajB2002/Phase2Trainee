import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CustComp } from '../Customcomp/custom.componet';
@Component({
  selector: 'app-sampbind',
  standalone: true,
  imports: [FormsModule,CommonModule,CustComp],
  templateUrl: './sampbind.component.html',
  styleUrl: './sampbind.component.css'
})
export class SampbindComponent {
    fname:string="Payoda";
    lname :string ="Organization";
    butval:Boolean=false;
    value:string="";
    imageurl:string="/public/signup.jpg"
    text:string="SampleText"

    count:number=0;

    counter(){
      this.count++;
    }

    display(){
      this.butval=true;
      this.fname="Yuva";
      this.lname="Raj";
    }

    show(event: any){
      this.text =(event.target.value);
    }
    
}
