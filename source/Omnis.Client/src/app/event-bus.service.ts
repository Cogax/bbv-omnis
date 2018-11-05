import { Injectable } from '@angular/core';

import { Subject } from 'rxjs';
import { filter, map } from 'rxjs/operators';

export interface EventBusArgs {
  type: string;
  data: any;
}

@Injectable({
  providedIn: 'root'
})
export class EventBusService {
  private messages$ = new Subject<EventBusArgs>();

  publish(eventType: string, eventData: any) {
    this.messages$.next({ type: eventType, data: eventData });
  }

  observe(eventType: string) {
    return this.messages$.pipe(
      filter(args => args.type === eventType),
      map(args => args.data)
    );
  }
}
