import { Injectable } from '@angular/core';
import {Event} from './event';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class ZenithEventService {
  private BASE_URL = "http://localhost:54675/api/EventsApi"
  
  constructor(private http: Http) { }


  getEvents(): Promise<Event[]> {
    return this.http.get(this.BASE_URL)
    .toPromise()
    .then(response => response.json() as Event[])
    .catch(this.handleError);
  }

  getEventById(id: number): Promise<Event> {
    return this.getEvents()
      .then(result => result.find(event => event.eventId === id));
  } 

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
