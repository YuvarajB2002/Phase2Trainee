import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { SampbindComponent } from './app/sampbind/sampbind.component';
import { CarListComponent } from './app/car-list/car-list.component';
import { DirectiveCompComponent } from './app/directive-comp/directive-comp.component';
import { FormCompComponent } from './app/form-comp/form-comp.component';
bootstrapApplication(CarListComponent, appConfig)
  .catch((err) => console.error(err));
