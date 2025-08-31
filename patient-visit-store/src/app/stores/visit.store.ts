import { Injectable, signal, computed } from '@angular/core';
import { VisitApiService, VisitDto } from '../services/visit-api.service';

type Entities = Record<number, VisitDto>;

@Injectable({ providedIn: 'root' })
export class VisitStore {
  // --- Writable signals (internal state) ---
  private entities = signal<Entities>({});
  private ids = signal<number[]>([]);
  private loading = signal(false);
  private _error = signal<string | null>(null);

  // --- Exposed signals (readonly / derived) ---
  all = computed(() => this.ids().map(id => this.entities()[id]));
  total = computed(() => this.ids().length);
  isLoading = computed(() => this.loading());
  lastError = computed(() => this._error());

  constructor(private api: VisitApiService) {}

  // --- Helpers ---
  private setList(list: VisitDto[]) {
    const map: Entities = {};
    const ids: number[] = [];
    for (const v of list) {
      map[v.visitId] = v;
      ids.push(v.visitId);
    }
    this.entities.set(map);
    this.ids.set(ids);
  }

  setError(message: string) {
    this._error.set(message);
  }

  clearError() {
    this._error.set(null);
  }

  // --- API actions ---
  searchByPatient(name: string) {
    this.loading.set(true);
    this.clearError();
    this.api.searchByPatient(name).subscribe({
      next: list => { this.setList(list); this.loading.set(false); },
      error: err => { this.setError(err?.error?.message || 'Search by patient failed'); this.loading.set(false); }
    });
  }

  searchByDoctor(name: string) {
    this.loading.set(true);
    this.clearError();
    this.api.searchByDoctor(name).subscribe({
      next: list => { this.setList(list); this.loading.set(false); },
      error: err => { this.setError(err?.error?.message || 'Search by doctor failed'); this.loading.set(false); }
    });
  }

  searchByType(type: string) {
    this.loading.set(true);
    this.clearError();
    this.api.searchByType(type).subscribe({
      next: list => { this.setList(list); this.loading.set(false); },
      error: err => { this.setError(err?.error?.message || 'Search by type failed'); this.loading.set(false); }
    });
  }

  addVisit(payload: any) {
    this.loading.set(true);
    this.clearError();
    this.api.addVisit(payload).subscribe({
      next: () => { this.loading.set(false); },
      error: err => { this.setError(err?.error?.message || 'Add visit failed'); this.loading.set(false); }
    });
  }

  updateVisit(payload: any) {
    this.loading.set(true);
    this.clearError();
    this.api.updateVisit(payload).subscribe({
      next: () => { this.loading.set(false); },
      error: err => { this.setError(err?.error?.message || 'Update visit failed'); this.loading.set(false); }
    });
  }

  deleteVisit(payload: any) {
    this.loading.set(true);
    this.clearError();
    this.api.deleteVisit(payload).subscribe({
      next: () => { this.loading.set(false); },
      error: err => { this.setError(err?.error?.message || 'Delete visit failed'); this.loading.set(false); }
    });
  }

  getById(id: number) {
    return computed(() => this.entities()[id]);
  }
}
