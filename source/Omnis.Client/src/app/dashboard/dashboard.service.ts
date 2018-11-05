import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';

import { Observable } from 'rxjs';

import { Device } from '../device.model';

export class DashboardService {
  constructor(private http: HttpClient, @Inject('baseUrl') private baseUrl: string) {}

  getAll(): Observable<Device[]> {
    const url = `${this.baseUrl}/api/v1/devices/enabled`;
    return this.http.get<Device[]>(url);
  }
}
