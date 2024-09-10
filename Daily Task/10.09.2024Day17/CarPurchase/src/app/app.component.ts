import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SampbindComponent } from './sampbind/sampbind.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [SampbindComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'This is my angular';
}
 