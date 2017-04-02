import { Injectable } from '@angular/core';
import {Activity} from './activity';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class ZenithActivityService {
  private BASE_URL = "http://zenithsocietyasgn2.azurewebsites.net/api/ActivitiesApi/"
  
  constructor(private http: Http) { }


  getActivities(): Promise<Activity[]> {
    return this.http.get(this.BASE_URL)
    .toPromise()
    .then(response => response.json() as Activity[])
    .catch(this.handleError);
  }

  getActivityById(id: number): Promise<Activity> {
    return this.getActivities()
      .then(result => result.find(activity => activity.activityId === id));
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
