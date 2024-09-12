import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../Company';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-componentdetails',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './componentdetails.component.html',
  styleUrl: './componentdetails.component.css'
})
export class ComponentdetailsComponent {
  company :Company | undefined
   constructor(private apiser:ApiService,private route:ActivatedRoute,private router:Router){

   }
   ngOnInit():void{
    const id=+this.route.snapshot.params['id'];
    this.apiser.getbyid(id).subscribe(
      (response)=>{
        this.company=response
      }
    )
   }
   goBack(){
    this.router.navigate(['/']);
   }
}
