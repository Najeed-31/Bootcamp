import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-delete-visit',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './delete-visit.component.html',
  styleUrls: ['./delete-visit.component.scss']
})
export class DeleteVisitComponent {
  patientName = '';
  doctorName = '';
  visitTypeName = '';
  durationMinutes: number | null = null;
  message = '';
  error = '';

  constructor(private http: HttpClient) {}

  deleteVisit() {
    const payload = {
      patientName: this.patientName,
      doctorName: this.doctorName,
      visitTypeName: this.visitTypeName,
      durationMinutes: this.durationMinutes
    };

    this.http.request('delete', '/api/visits/delete', { body: payload }).subscribe({
      next: () => {
        this.message = 'Visit deleted successfully!';
        this.error = '';
      },
      error: err => {
        this.error = err.error?.message || 'Error deleting visit.';
        this.message = '';
      }
    });
  }
}
