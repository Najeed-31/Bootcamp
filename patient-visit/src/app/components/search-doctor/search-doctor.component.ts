import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search-doctor',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-doctor.component.html',
  styleUrls: ['./search-doctor.component.scss']
})
export class SearchDoctorComponent {
  doctorName = '';
  visits: any[] = [];
  error = '';

  constructor(private http: HttpClient) {}

  search() {
    if (!this.doctorName.trim()) {
      this.error = "Please enter a doctor name.";
      this.visits = [];
      return;
    }

    this.http.get<any[]>(`/api/visits/by-doctor?name=${this.doctorName}`).subscribe({
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
