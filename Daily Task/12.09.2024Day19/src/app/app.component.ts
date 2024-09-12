import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CompanylistComponent } from './companylist/companylist.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,CompanylistComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AngularAPI';
}
