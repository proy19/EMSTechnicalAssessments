export interface Employee {
    employeeID: number;
    firstName: string;
    lastName: string;
    managerID: number;
    roles: string[];
  }

export interface CreatedEmployee {
    employeeID: number;
    firstName: string;
    lastName: string;
    managerID: number;
}