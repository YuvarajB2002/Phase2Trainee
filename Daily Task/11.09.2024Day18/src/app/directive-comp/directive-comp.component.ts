import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-directive-comp',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './directive-comp.component.html',
  styleUrl: './directive-comp.component.css'
})
export class DirectiveCompComponent {
 num:number=0;
 result:boolean=false;
 logged:boolean=false;
 notificationType = '';
  checkpostive(num :number){
    if(num>0){
      this.result= true;
    }
    else{
      this.result= false;
    }
  }
  islogged(){
    this.logged=!this.logged;
  }
  setNotificationType(color:string) {
    if (color=='danger') {
      this.notificationType = 'danger'; 
    } 
    else if (color=='success') {
      this.notificationType = 'success'; 
    }
     else if (color=='warning') {
      this.notificationType = 'warning'; 
    } 
    else {
      this.notificationType = 'error'; 
    }
  }
}
