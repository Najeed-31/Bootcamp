import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private tokenKey = 'token';
  userRole = signal<string | null>(null);

  constructor(private http: HttpClient) {
    this.loadToken();
  }

  private loadToken() {
    const token = localStorage.getItem(this.tokenKey);
    if (token) {
      this.setRoleFromToken(token);
    }
  }

  // private setRoleFromToken(token: string) {
  //   const payload = JSON.parse(atob(token.split('.')[1]));
  //   this.userRole.set(payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
  // }

  private setRoleFromToken(token: string) {
  try {
    const payload = JSON.parse(atob(token.split('.')[1]));

    // Some JWTs use full schema, some just "role"
    const role = payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] 
              || payload['role'] 
              || null;

    this.userRole.set(role);
  } catch (e) {
    console.error('Error parsing token', e);
    this.userRole.set(null);
  }
}


  login(username: string, password: string) {
    return this.http.post<{ token: string }>('/api/auth/login', { username, password })
      .pipe(
        tap(res => {
          localStorage.setItem(this.tokenKey, res.token);
          this.setRoleFromToken(res.token);
        })
      );
  }

  register(username: string, password: string) {
    return this.http.post<{ token: string }>('/api/auth/register', { username, password })
      .pipe(
        tap(res => {
          localStorage.setItem(this.tokenKey, res.token);
          this.setRoleFromToken(res.token);
        })
      );
  }

  getToken() {
    return localStorage.getItem(this.tokenKey);
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
    this.userRole.set(null);
  }
  
}
