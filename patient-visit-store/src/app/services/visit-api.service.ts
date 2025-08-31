import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface VisitDto {
  visitId: number;
  patientName: string;
  doctorName: string;
  visitTypeName: string;
  visitDate: string; // ISO string
  description: string;
  durationMinutes: number;
  fee: number;
}

@Injectable({ providedIn: 'root' })
export class VisitApiService {
  constructor(private http: HttpClient) {}

  searchByPatient(name: string): Observable<VisitDto[]> {
    return this.http.get<VisitDto[]>(`/api/visits/by-patient?name=${encodeURIComponent(name)}`);
  }

  searchByDoctor(name: string): Observable<VisitDto[]> {
    return this.http.get<VisitDto[]>(`/api/visits/by-doctor?name=${encodeURIComponent(name)}`);
  }

  searchByType(type: string): Observable<VisitDto[]> {
    return this.http.get<VisitDto[]>(`/api/visits/by-type?type=${encodeURIComponent(type)}`);
  }

  addVisit(payload: any): Observable<any> {
    return this.http.post('/api/visits/add', payload);
  }

  updateVisit(payload: any): Observable<any> {
    return this.http.put('/api/visits/update', payload);
  }

  deleteVisit(payload: any): Observable<any> {
    return this.http.request('delete', '/api/visits/delete', { body: payload });
  }
}
