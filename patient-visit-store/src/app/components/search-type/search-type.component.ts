import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { VisitStore } from '../../stores/visit.store';

@Component({
  selector: 'app-search-type',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-type.component.html',
  styleUrls: ['./search-type.component.scss']
})
export class SearchTypeComponent {
  visitType = '';

  constructor(public visitStore: VisitStore) {}

  onSearch() {
    if (this.visitType.trim()) {
      this.visitStore.searchByType(this.visitType);
    }
  }
}
