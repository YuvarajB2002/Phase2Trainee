import { Routes } from '@angular/router';
import { CompanylistComponent } from './companylist/companylist.component';
import { ComponentdetailsComponent } from './componentdetails/componentdetails.component';
import { CompanyAddComponent } from './company-add/company-add.component';
import { CompanyDeleteComponent } from './company-delete/company-delete.component';
import { CompanyUpdateComponent } from './company-update/company-update.component';

export const routes: Routes = [
    {path:'',component: CompanylistComponent},
    {path:'company-details/:id',component: ComponentdetailsComponent},
    {path:'add-company',component:CompanyAddComponent},
    {path:'delete-company/:id',component:CompanyDeleteComponent},
    {path:'update/:id',component:CompanyUpdateComponent}
];
