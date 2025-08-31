import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-update-visit',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './update-visit.component.html',
  styleUrls: ['./update-visit.component.scss']
})
export class UpdateVisitComponent {
  patientName = '';
  doctorName = '';
  visitTypeName = '';
  description = '';
  durationMinutes: number | null = null;
  message = '';
  error = '';

  constructor(private http: HttpClient) {}

  updateVisit() {
    const payload = {
      patientName: this.patientName,
      doctorName: this.doctorName,
      visitTypeName: this.visitTypeName,
      description: this.description,
      durationMinutes: this.durationMinutes
    };

    this.http.put('/api/visits/update', payload).subscribe({
      next: () => {
        this.message = 'Visit updated successfully!';
        this.error = '';
      },
      error: err => {
        this.error = err.error?.message || 'Error updating visit.';
        this.message = '';
      }
    });
  }
}
