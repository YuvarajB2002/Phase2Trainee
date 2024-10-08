import { Component } from '@angular/core';
import { Company } from '../Company';
import { ApiService } from '../api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-company-update',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './company-update.component.html',
  styleUrl: './company-update.component.css'
})
export class CompanyUpdateComponent {
  company: Company = { companyId: 0, companyName: '' };

  constructor(
    private apiService: ApiService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadCompany();
  }

  loadCompany(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.apiService.getbyid(id).subscribe(
      (company) => this.company = company,
      (error) => console.error('Error loading company', error)
    );
  }

  onUpdate(): void {
    const id = this.company.companyId;
    this.apiService.updateComp(id,this.company).subscribe(
      (response) => {
        console.log('Company updated successfully!', response);
        this.router.navigate(['/']); 
      },
      (error) => console.error('Error updating company', error)
    );
  }
  goBack(){
    this.router.navigate(['/']);
   }
}
