import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-car-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './car-list.component.html',
  styleUrl: './car-list.component.css'
})
export class CarListComponent {

 
   listcar:Car[]=[
    {carId:1,carName:"BMW",carPrice:600000,carRating:5,carStock:3,carImage:"/public/bmw.jpg"},
    {carId:2,carName:"Audi",carPrice:400000,carRating:3,carStock:1,carImage:"/public/audi.jpg"},
    {carId:3,carName:"Rolls Royce",carPrice:2000000,carRating:10,carStock:5,carImage:"/public/rolls.jpg"}
    
   ]

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
}
class Car{
  carId? :number
  carName?:string
  carRating?:number
  carStock:number=0
  carPrice:number=0
  carImage?:string
}
