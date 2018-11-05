import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';

import { Observable } from 'rxjs';

import { Device } from '../device.model';

export class DevicesService {
  constructor(private http: HttpClient, @Inject('baseUrl') private baseUrl: string) {}

  getAll(): Observable<Device[]> {
    const url = `${this.baseUrl}/api/v1/devices`;
    return this.http.get<Device[]>(url);
  }

  enable(deviceName: string): Observable<Device[]> {
    const url = `${this.baseUrl}/api/v1/${deviceName}/enable`;
    return this.http.post<Device[]>(url, {});
  }

  disable(deviceName: string): Observable<Device[]> {
    const url = `${this.baseUrl}/api/v1/${deviceName}/disable`;
    return this.http.post<Device[]>(url, {});
  }
}
