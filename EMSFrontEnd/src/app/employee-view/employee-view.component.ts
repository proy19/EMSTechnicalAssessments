import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { EmployeeService } from '../shared-service/employee.service';
import { Employee } from '../shared-service/employee.model';
import { CommonModule } from '@angular/common';  
import { FormsModule } from '@angular/forms';
import { EmployeeRequest } from '../shared-service/employee-request.model';
import { Role } from '../shared-service/role.model';

@Component({
  selector: 'app-employee-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './employee-view.component.html',
  styleUrl: './employee-view.component.css'
})
export class EmployeeViewComponent implements OnInit {
  employees: Employee[] = []; 
  managers: Employee[] = [];
  currentManagerId?:  number | null = null;

  newEmployee: EmployeeRequest = {
      firstName: '',
      lastName: '',
      managerID: 0,
      roleIDList: []
    }
  
  allRoles: Role[] = [];

  constructor(public apiService: EmployeeService,
    private cdr: ChangeDetectorRef
  ){
  }

  ngOnInit(): void {
    this.getEmployees();
    this.getManagers();
    this.getAllRoles();
  }

  getAllRoles() {
    this.apiService.getAllRoles().subscribe({
      next: (data) => {
        this.allRoles = data;
      },
      error: (error) => {
        console.error('Error occurred:', error);
      }
    });
 }

 addNewEmployee() {
  this.apiService.addNewEmployee(this.newEmployee).subscribe({
    next: (response) => {
      this.getEmployees()
      this.cdr.detectChanges();
      this.closeModal();
      this.newEmployee = { firstName: '', lastName: '', managerID: 0, roleIDList: [] };
    },
    error: (error) => {
      console.error('Error occurred:', error);
    }
  });
}

closeModal() {
  const modal = document.getElementById('addEmployeeModal');
  if (modal) {
    modal.classList.remove('show');
    modal.style.display = 'none';
    document.body.classList.remove('modal-open');
    const backdrop = document.querySelector('.modal-backdrop');
    if (backdrop) backdrop.remove();
  }
}

toggleRole(roleId: number) {
  const index = this.newEmployee.roleIDList.indexOf(roleId);
  if (index > -1) {
    this.newEmployee.roleIDList.splice(index, 1);
  } else {
    this.newEmployee.roleIDList.push(roleId);
}
}

 getManagers() {
    this.apiService.getAllManagers().subscribe({
      next: (data) => {
        this.managers = data;
      },
      error: (error) => {
        console.error('Error occurred:', error);
      }
    });
 }

  getEmployees() {
    this.apiService.getEmployeesWithRoles().subscribe({
      next: (data) => {
        this.employees = data;
      },
      error: (error) => {
        console.error('Error occurred:', error);
      }
    });
 }

 getEmployeesByManager(managerId: number) {
  this.apiService.getEmployeesByManager(managerId).subscribe({
    next: (data) => {
      this.employees = data;
    },
    error: (error) => {
      console.error('Error occurred:', error);
    }
  });
}

onManagerSelection() {
  if (this.currentManagerId) {
    this.getEmployeesByManager(this.currentManagerId);
  } else {
    this.getEmployees();
  }
}
}
