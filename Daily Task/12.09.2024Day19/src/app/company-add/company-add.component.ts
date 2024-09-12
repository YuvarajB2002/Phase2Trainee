import { Component } from '@angular/core';
import { Company } from '../Company';
import { appConfig } from '../app.config';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-company-add',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './company-add.component.html',
  styleUrl: './company-add.component.css'
})
export class CompanyAddComponent {
  company :Company ={ companyId:0, companyName:''};
  constructor(private apiser:ApiService,private router:Router){
    
  }
  onSubmit():void{
    this.apiser.postcomp(this.company).subscribe(
      (response) =>
      {
        console.log('Company added successfully',response);
        this.router.navigate(['/']);
      }
    );
  }
  goBack(){
    this.router.navigate(['/']);
   }
}
