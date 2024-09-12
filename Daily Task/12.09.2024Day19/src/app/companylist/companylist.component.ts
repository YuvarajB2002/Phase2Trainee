import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-companylist',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './companylist.component.html',
  styleUrl: './companylist.component.css'
})
export class CompanylistComponent {
    data :any;
    constructor(private apiser:ApiService,private router: Router){

    }
    ngOnInit():void{
      this.apiser.get().subscribe(
        (response) =>{
          this.data=response;
        }
      );
    }
    viewDetails(id: number): void {

      this.router.navigate(['/company-details',id]);
    }
    deleteCompany(id: number): void{
       this.router.navigate(['/delete-company',id]);
    }
    addCompany(): void {
      this.router.navigate(['/add-company']);
    }
    editCompany(id: number):void{
      this.router.navigate(['/update',id]);
    }
    
}
