export interface User {
  id: number;
  firstName: string;
  lastName: string;
  middleName: string;
  gender: string;
  birthDate: Date;
  appUserId: string;
  workInfos: WorkInfo[];
}

export interface WorkInfo {
  company: string;
  department: string;
  position: string;
  superVisor: string;
  workPlace: string;
}
