import {Activity} from './activity';

export class Event {
    eventId:number;
    eventFrom:Date;
    eventTo:Date;
    enteredBy:string;
    activityId:number;
    creationDate:Date;
    isActive:boolean;
    activity:Activity;
}
