import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search-type',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-type.component.html',
  styleUrls: ['./search-type.component.scss']
})
export class SearchTypeComponent {
  visitType = '';
  visits: any[] = [];
  error = '';

  constructor(private http: HttpClient) {}

  search() {
    if (!this.visitType.trim()) {
      this.error = "Please enter a visit type.";
      this.visits = [];
      return;
    }

    this.http.get<any[]>(`/api/visits/by-type?type=${this.visitType}`).subscribe({
      next: (data) => {
        this.error = '';
        this.visits = data;
      },
      error: (err) => {
        this.error = err.error?.message || 'Error fetching visits.';
        this.visits = [];
      }
    });
  }
}
