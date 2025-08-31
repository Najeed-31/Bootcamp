import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-visit',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-visit.component.html',
  styleUrls: ['./add-visit.component.scss']
})
export class AddVisitComponent {
  patientName = '';
  doctorName = '';
  visitTypeName = '';
  description = '';
  durationMinutes: number | null = null;
  message = '';
  error = '';

  constructor(private http: HttpClient) {}

  addVisit() {
    const payload = {
      patientName: this.patientName,
      doctorName: this.doctorName,
      visitTypeName: this.visitTypeName,
      description: this.description,
      durationMinutes: this.durationMinutes
    };

    this.http.post('/api/visits/add', payload).subscribe({
      next: () => {
        this.message = 'Visit added successfully!';
        this.error = '';
      },
      error: err => {
        this.error = err.error?.message || 'Error adding visit.';
        this.message = '';
      }
    });
  }
}
