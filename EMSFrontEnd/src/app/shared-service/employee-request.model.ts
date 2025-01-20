export interface EmployeeRequest {
    firstName?: string;
    lastName?: string;
    managerID?: number;
    roleIDList: number[];
  }