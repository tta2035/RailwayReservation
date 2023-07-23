import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/app/environments/environment';
import { AdminService } from '../admin.service';
import { DataService } from '../data.service';

@Injectable({
  providedIn: 'root'
})
export class RouteService {
  private baseURL: string = environment.baseURL;

  constructor(
    private http: HttpClient,
    private adminService: AdminService,
    private dataService: DataService
  ) { }

  updateRoute(data: any) {
    return this.http.put<any>(`${this.baseURL}Route`, data);
  }

  addRoute(data: any) {
    return this.http.post<any>(`${this.baseURL}Route`, data);
  }

  reloadRoute() {
    this.adminService.getAllRoute()
      .subscribe({
        next: (data) => {
          this.dataService.sendRoute(data);
        }
      })
  }
}
