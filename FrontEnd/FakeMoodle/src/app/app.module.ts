import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { appRoutes } from './routes';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AdminGuardService as AdminGuard } from './services/admin-guard.service';
import { AuthGuardService as AuthGuard } from './services/auth-guard.service';
import { AuthService } from './services/auth.service';
import { AssignmentsComponent } from './user-stuff/assignments/assignments.component';
import { LaboratoriesComponent } from './user-stuff/laboratories/laboratories.component';
import { HeaderHelperService } from './services/header-helper.service';
import { StudentManagementComponent } from './admin-stuff/student-management/student-management.component';
import { GradingComponent } from './admin-stuff/grading/grading.component';
import { LabManagementComponent } from './admin-stuff/lab-management/lab-management.component';
import { AssignmentManagementComponent } from './admin-stuff/assignment-management/assignment-management.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    LaboratoriesComponent,
    AssignmentsComponent,
    StudentManagementComponent,
    GradingComponent,
    LabManagementComponent,
    AssignmentManagementComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(
      appRoutes
    ),
    HttpModule
  ],
  providers: [
    AuthGuard,
    AuthService,
    AdminGuard,
    HeaderHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
