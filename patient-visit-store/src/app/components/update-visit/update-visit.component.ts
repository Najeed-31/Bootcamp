import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { VisitStore } from '../../stores/visit.store';

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

  constructor(public visitStore: VisitStore) {}

  onSubmit() {
    if (!this.patientName || !this.doctorName || !this.visitTypeName || !this.durationMinutes) {
      this.visitStore.setError('All required fields must be filled.');
      return;
    }

    this.visitStore.updateVisit({
      patientName: this.patientName,
      doctorName: this.doctorName,
      visitTypeName: this.visitTypeName,
      description: this.description,
      durationMinutes: this.durationMinutes
    });

    // Reset form after submit
    this.patientName = '';
    this.doctorName = '';
    this.visitTypeName = '';
    this.description = '';
    this.durationMinutes = null;
  }
}
