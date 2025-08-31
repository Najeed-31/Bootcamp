import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { VisitStore } from '../../stores/visit.store';

@Component({
  selector: 'app-search-doctor',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-doctor.component.html',
  styleUrls: ['./search-doctor.component.scss']
})
export class SearchDoctorComponent {
  doctorName = '';

  constructor(public visitStore: VisitStore) {}

  onSearch() {
    if (this.doctorName.trim()) {
      this.visitStore.searchByDoctor(this.doctorName);
    }
  }
}
