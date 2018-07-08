import { Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { HomeComponent } from "./home/home.component";
import { AuthGuardService as AuthGuard } from "./services/auth-guard.service";
import { LaboratoriesComponent } from "./user-stuff/laboratories/laboratories.component";
import { AssignmentsComponent } from "./user-stuff/assignments/assignments.component";
import { StudentManagementComponent } from "./admin-stuff/student-management/student-management.component";
import { AdminGuardService } from "./services/admin-guard.service";
import { GradingComponent } from "./admin-stuff/grading/grading.component";
import { LabManagementComponent } from "./admin-stuff/lab-management/lab-management.component";
import { AssignmentManagementComponent } from "./admin-stuff/assignment-management/assignment-management.component";

export const appRoutes: Routes = [
  { path: 'Login', redirectTo: 'login' },
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'labs', component: LaboratoriesComponent, canActivate: [AuthGuard] },
  { path: 'assignments/:id', component: AssignmentsComponent, canActivate: [AuthGuard] },
  { path: 'laboratories', component: LaboratoriesComponent, canActivate: [AuthGuard] },
  { path: 'admin/students', component: StudentManagementComponent, canActivate: [AdminGuardService] },
  { path: 'admin/grading', component: GradingComponent, canActivate: [AdminGuardService] },
  { path: "admin/labs", component: LabManagementComponent, canActivate: [AdminGuardService] },
  { path: "admin/assignments", component: AssignmentManagementComponent, canActivate: [AdminGuardService] },
  { path: '**', redirectTo: '' }
];