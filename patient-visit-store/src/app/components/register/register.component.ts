import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthStore } from '../../stores/auth.store';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  username = '';
  password = '';

  constructor(public auth: AuthStore, private router: Router) {}

  onSubmit() {
    this.auth.register(this.username, this.password);
  }

  goToLogin() {
    this.router.navigate(['/']);
  }
}
