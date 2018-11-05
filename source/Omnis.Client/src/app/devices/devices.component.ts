import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';

import { Device } from '../device.model';
import { DevicesService } from './devices.service';

@Component({
  selector: 'omnis-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {
  devices$: Observable<Device[]>;

  constructor(private service: DevicesService) {}

  ngOnInit() {
    this.devices$ = this.service.getAll();
  }

  enable(deviceName: string) {
    this.devices$ = this.service.enable(deviceName);
  }

  disable(deviceName: string) {
    this.devices$ = this.service.disable(deviceName);
  }
}
