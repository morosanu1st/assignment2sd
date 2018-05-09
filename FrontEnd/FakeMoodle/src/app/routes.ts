import { Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { HomeComponent } from "./home/home.component";
import { AuthGuardService as AuthGuard } from "./services/auth-guard.service";
import { LaboratoriesComponent } from "./user-stuff/laboratories/laboratories.component";
import { AssignmentsComponent } from "./user-stuff/assignments/assignments.component";

export const appRoutes: Routes = [
  { path: 'Login', redirectTo: 'login' },
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'labs', component: LaboratoriesComponent, canActivate: [AuthGuard] },
  { path: 'assignments/[labId]', component: AssignmentsComponent, canActivate: [AuthGuard] },
  { path: 'laboratories', component: LaboratoriesComponent, canActivate: [AuthGuard] },  
  { path: '**', redirectTo: '' }
];