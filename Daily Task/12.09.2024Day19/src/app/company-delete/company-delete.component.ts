import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-company-delete',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './company-delete.component.html',
  styleUrl: './company-delete.component.css'
})
export class CompanyDeleteComponent {
  constructor(private apiser:ApiService,private router:Router,private route:ActivatedRoute)
      {

      }
      ngOnInit():void{
        const id = +this.route.snapshot.params['id'];
        if (confirm("Are you sure to delete")){
           this.apiser.deletecomp(id).subscribe(
          
            (response)=>
            {
              console.log("Company Removed");
              this.router.navigate(['/'])
            }
           )
          }
          else{
            this.router.navigate(['/'])
          }
      }
      
  
}
