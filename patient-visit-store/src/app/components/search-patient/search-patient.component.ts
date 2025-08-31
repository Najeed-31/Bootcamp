import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { VisitStore } from '../../stores/visit.store';

@Component({
  selector: 'app-search-patient',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-patient.component.html',
  styleUrls: ['./search-patient.component.scss']
})
export class SearchPatientComponent {
  patientName = '';

  constructor(public visitStore: VisitStore) {}

  onSearch() {
    if (this.patientName.trim()) {
      this.visitStore.searchByPatient(this.patientName);
    }
  }
}
