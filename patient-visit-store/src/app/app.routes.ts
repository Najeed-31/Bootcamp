import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SearchPatientComponent } from './components/search-patient/search-patient.component';
import { SearchDoctorComponent } from './components/search-doctor/search-doctor.component';
import { SearchTypeComponent } from './components/search-type/search-type.component';
import { AddVisitComponent } from './components/add-visit/add-visit.component';
import { UpdateVisitComponent } from './components/update-visit/update-visit.component';
import { DeleteVisitComponent } from './components/delete-visit/delete-visit.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'search-patient', component: SearchPatientComponent },
  {path: 'search-doctor', component: SearchDoctorComponent},
  {path: 'search-type', component: SearchTypeComponent},
  {path: 'add-visit',component: AddVisitComponent},
  {path: 'update-visit',component:UpdateVisitComponent},
  {path:'delete-visit',component:DeleteVisitComponent}
];
