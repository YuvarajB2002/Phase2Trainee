import { CommonModule, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-car-list',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './car-list.component.html',
  styleUrl: './car-list.component.css'
})
export class CarListComponent {

 
   listcar:Car[]=[
    {carId:1,companyName:"BMW",carPrice:600000,carRating:5,carStock:3,carImage:"/public/bmw.jpg"},
    {carId:2,companyName:"Audi",carPrice:400000,carRating:3,carStock:1,carImage:"/public/audi.jpg"},
    {carId:3,companyName:"Rolls Royce",carPrice:2000000,carRating:10,carStock:5,carImage:"/public/rolls.jpg"},
    {carId:4,companyName:"Rolls Royce",carPrice:1000000,carRating:9,carStock:2,carImage:"/public/rolls2.jpg"},
    {carId:5,companyName:"BMW",carPrice:700000,carRating:4,carStock:4,carImage:"/public/bmw2.jpg"}
    
   ]
   onSubmit(addCarForm :NgForm) {
    if (addCarForm.valid) {
      const newCar = {
        carId: addCarForm.value.carId,
        companyName: addCarForm.value.companyName,
        carPrice: addCarForm.value.carPrice,
        carRating: addCarForm.value.carRating,
        carStock: addCarForm.value.stock,
        carImage: addCarForm.value.carImage
      };
      
      // Add the new car to the list
      this.listcar.push(newCar);
      alert('Car added successfully!');
      addCarForm.reset();
    }
  }

   addcard:Car[]=[]
   count?:number=0
   display(car: Car){
      this.count=0
      this.addcard.forEach(c => {
          if(c.carId==car.carId){
            this.count=1;
          }
      });
      if(this.count==0){
         this.addcard.push(car);
      }
   }
   cancel(car: Car){
    this.addcard=this.addcard.filter(c => c.carId != car.carId);
   }

   getColor(rating?:number): string {
    if(rating === undefined) {
      return 'gray';
    }
    else if (rating < 5) {
      return 'red';   
    } else if (rating == 5) {
      return 'orange'; 
    } else {
      return 'green';  
    }
  }
  buyingitem:Car[]=[]
  totalamount:number=0;
  buyCar(car: Car){
    if(car.carStock>0){
      this.buyingitem.push(car);
      this.totalamount+=car.carPrice;
      car.carStock-=1;
    }
    else{
         alert("Out of Stock");
    }
    
  }
  checkStock(car: Car):string{
    if(car.carStock==0){
        return "Out of Stock"
    }
    else if(car.carStock===undefined){
       return "Out of Stock"
    }
    else{
      return car.carStock+"";
    }
  }

  selectedCompany = 'All';

  // Filtered list
  filteredCars = this.listcar;

  filterCarsByCompany() {
    if (this.selectedCompany === 'All') {
      this.filteredCars = this.listcar;
    } else {
      this.filteredCars = this.listcar.filter(car => car.companyName === this.selectedCompany);
    }
  }
}
class Car{
  carId? :number
  companyName?:string
  carRating?:number
  carStock:number=0
  carPrice:number=0
  carImage?:string
}
