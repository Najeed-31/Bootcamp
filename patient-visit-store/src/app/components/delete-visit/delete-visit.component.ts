import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { VisitStore } from '../../stores/visit.store';

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

  constructor(public visitStore: VisitStore) {}

  onSubmit() {
    if (!this.patientName || !this.doctorName || !this.visitTypeName || !this.durationMinutes) {
      this.visitStore.setError('All required fields must be filled.');
      return;
    }

    this.visitStore.deleteVisit({
      patientName: this.patientName,
      doctorName: this.doctorName,
      visitTypeName: this.visitTypeName,
      durationMinutes: this.durationMinutes
    });

    // Reset form after submit
    this.patientName = '';
    this.doctorName = '';
    this.visitTypeName = '';
    this.durationMinutes = null;
  }
}
