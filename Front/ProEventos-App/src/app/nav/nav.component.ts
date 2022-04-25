import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  constructor(
    public router: Router,
    // private authService: AuthService,
    // private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
  }

  showMenu(){
    return this.router.url !== '/user/login'
  }

  LoggedIn(){
    // return this.authService.loggedIn();
  }

  logout(){
    localStorage.removeItem('token');
    // this.toastr.show('Log Out')
    this.router.navigate(['/user/login']);
  }

  entrar(){
    this.router.navigate(['/user/login']);
  }

  userName(){
    return sessionStorage.getItem('username');
  }
}
