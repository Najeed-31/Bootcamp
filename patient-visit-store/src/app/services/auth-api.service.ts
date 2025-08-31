import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface LoginResponse { token: string; }
export interface RegisterResponse { token: string; userId?: number; }

@Injectable({ providedIn: 'root' })
export class AuthApiService {
  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<LoginResponse> {
    return this.http.post<LoginResponse>('/api/auth/login', { username, password });
  }

  register(username: string, password: string): Observable<RegisterResponse> {
    return this.http.post<RegisterResponse>('/api/auth/register', { username, password });
  }

  refreshToken(): Observable<LoginResponse> {
    return this.http.post<LoginResponse>('/api/auth/refresh', {});
  }
}
