import { Component, OnInit } from '@angular/core';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/admin/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
    { path: '/admin/trip-panel', title: 'Trip Panel',  icon:'content_paste', class: '' },
    { path: '/admin/ticket-panel', title: 'Ticket Panel',  icon:'library_books', class: '' },
    { path: '/admin/booking-panel', title: 'Booking Panel',  icon:'bubble_chart', class: '' },
    { path: '/admin/route-panel', title: 'Route Panel',  icon:'location_on', class: '' },
    { path: '/admin/station-panel', title: 'Station Panel',  icon:'notifications', class: '' },
    { path: '/admin/train-panel', title: 'Train Panel',  icon:'unarchive', class: '' },
    { path: '/admin/seat-type-panel', title: 'Seat Type',  icon:'unarchive', class: '' },
    { path: '/admin/user-profile', title: 'User Profile',  icon:'person', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
