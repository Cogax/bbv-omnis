import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';

import { Device } from '../device.model';
import { DashboardService } from './dashboard.service';

@Component({
  selector: 'omnis-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  devices$: Observable<Device[]>;

  constructor(private service: DashboardService) {}

  ngOnInit() {
    this.devices$ = this.service.getAll();
  }
}
