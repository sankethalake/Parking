import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from './User/user.service';
import { AuthGuard } from './Auth/auth.guard';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ParkingApp';
  constructor(private router: Router, public service: UserService, private auth: AuthGuard) { }
  ToParkingSlot() {
    this.router.navigateByUrl("parkingSlot");
  }
  onLogout() {
    localStorage.removeItem('token');
    this.router.navigateByUrl('/login');
  }
}
