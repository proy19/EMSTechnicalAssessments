import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeViewComponent } from './employee-view/employee-view.component';
import { CommonModule } from '@angular/common';  

@Component({
  selector: 'app-root',
  imports: [EmployeeViewComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'EMSFrontEnd';
}
