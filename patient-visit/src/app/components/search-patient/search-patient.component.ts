import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search-patient',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-patient.component.html',
  styleUrls: ['./search-patient.component.scss']
})
export class SearchPatientComponent {
  name = '';
  visits: any[] = [];
  error = '';

  constructor(private http: HttpClient) {}

  search() {
    if (!this.name.trim()) {
      this.error = "Please enter a patient name.";
      this.visits = [];
      return;
    }

    this.http.get<any[]>(`/api/visits/by-patient?name=${this.name}`).subscribe({
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
