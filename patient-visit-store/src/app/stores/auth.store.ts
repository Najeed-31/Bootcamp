import { Injectable, signal, computed, effect } from '@angular/core';
import { AuthApiService } from '../services/auth-api.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

interface UserInfo { username: string; userId?: string; role?: string; }

@Injectable({ providedIn: 'root' })
export class AuthStore {
  private token = signal<string | null>(localStorage.getItem('token'));
  private loading = signal(false);
  private error = signal<string | null>(null);
  private user = signal<UserInfo | null>(this.parseToken(localStorage.getItem('token')));

  isAuthenticated = computed(() => !!this.token());
  userRole = computed(() => this.user()?.role ?? null);
  authError = computed(() => this.error());
  authLoading = computed(() => this.loading());

  constructor(private api: AuthApiService, private router: Router) {
    effect(() => {
      const t = this.token();
      if (t) {
        localStorage.setItem('token', t);
        this.user.set(this.parseToken(t));
      } else {
        localStorage.removeItem('token');
        this.user.set(null);
      }
    });
  }

  private parseToken(token: string | null): UserInfo | null {
    if (!token) return null;
    try {
      const payload: any = jwtDecode(token);
      return {
        username: payload['unique_name'] ?? payload['name'],
        userId: payload['userId'],
        role: payload['role']   // always use the clean "role" claim
      };
    } catch {
      return null;
    }
  }

  login(username: string, password: string) {
    this.loading.set(true);
    this.error.set(null);
    return this.api.login(username, password).subscribe({
      next: res => {
        this.token.set(res.token);
        this.loading.set(false);
        this.router.navigate(['/dashboard']);
      },
      error: err => {
        this.error.set(err?.error?.message || 'Login failed');
        this.loading.set(false);
      }
    });
  }

  register(username: string, password: string) {
    this.loading.set(true);
    this.error.set(null);
    return this.api.register(username, password).subscribe({
      next: res => {
        this.token.set((res as any).token ?? null);
        this.loading.set(false);
        this.router.navigate(['/dashboard']);
      },
      error: err => {
        this.error.set(err?.error?.message || 'Registration failed');
        this.loading.set(false);
      }
    });
  }

  logout() {
    this.token.set(null);
    this.router.navigate(['/']);
  }

  refresh() {
    this.loading.set(true);
    this.api.refreshToken().subscribe({
      next: r => { this.token.set(r.token); this.loading.set(false); },
      error: () => { this.error.set('Refresh failed'); this.loading.set(false); }
    });
  }

  getToken() { return this.token(); }
  getUser() { return this.user(); }
}
