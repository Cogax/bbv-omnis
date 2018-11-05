import { Component, Input, OnDestroy, OnInit } from '@angular/core';

import { BroadcastEventListener, ISignalRConnection, SignalR } from 'ng2-signalr';

import { HeartBeat } from '../dashboard/heartbeat.model';
import { Device } from '../device.model';

@Component({
  selector: 'omnis-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.css']
})
export class DeviceComponent implements OnInit, OnDestroy {
  @Input()
  device: Device;

  private connection: ISignalRConnection;
  private heartBeat$: BroadcastEventListener<HeartBeat>;

  constructor(private signalR: SignalR) {}

  ngOnInit() {
    this.signalR.connect().then(connection => {
      this.connection = connection;
      this.heartBeat$ = new BroadcastEventListener<HeartBeat>('HeartBeat');

      this.connection.invoke('Register', this.device.deviceName);
      this.connection.listen(this.heartBeat$);

      this.heartBeat$.subscribe(hb => {
        this.device.state = hb.ConnectionState;
      });
    });
  }

  ngOnDestroy() {
    this.connection.invoke('UnRegister', this.device.deviceName);
    this.heartBeat$.unsubscribe();
  }
}
