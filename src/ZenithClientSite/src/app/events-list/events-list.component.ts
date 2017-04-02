import { Component, OnInit } from '@angular/core';
import {ZenithEventService} from '../zenith-event.service';
import {Router} from '@angular/router';
import {Event} from '../event';

@Component({
  selector: 'app-events-list',
  templateUrl: './events-list.component.html',
  styleUrls: ['./events-list.component.css']
})
export class EventsListComponent implements OnInit {
  events: Event[];
  eventWeek:Date = new Date();
  nextWeek = new Date(this.eventWeek.getFullYear(), this.eventWeek.getMonth(), this.eventWeek.getDate()+7);


  constructor(
    private eventService: ZenithEventService, 
    private router: Router
    ) { }


  getEvents(): void{
    this.eventService.getEvents()
      .then(events => {
        this.events = events;
        console.log(events);
        this.filterEvents();    
        console.log(events);
      });
  } 

  onPrevWeek(): void{
    this.nextWeek = this.eventWeek;
    this.eventWeek = new Date(this.nextWeek.getFullYear(), this.nextWeek.getMonth(), this.nextWeek.getDate()-7);
    this.getEvents();
  }
  
  onNextWeek(): void{
    this.eventWeek = this.nextWeek;
    this.nextWeek = new Date(this.eventWeek.getFullYear(), this.eventWeek.getMonth(), this.eventWeek.getDate()+7);
    this.getEvents();
}

  filterEvents(): void{
    var t = this;
    var filtered:Event[];
    this.events.map(function(e, i, array){
      
      if((new Date(e.eventFrom).getTime() >= new Date(t.eventWeek).getTime() && new Date(e.eventTo).getTime() <= new Date(t.nextWeek).getTime())){
        filtered.push(t.events[i]);
        console.log("eventfrom: " + new Date(e.eventFrom).getTime() + " eventweek: " + new Date(t.eventWeek).getTime());
        console.log("eventto: " + new Date(e.eventTo).getTime() + " nextweek: " + new Date(t.nextWeek).getTime());

      }
    });
    t.events = filtered;
  }

  ngOnInit() {
    this.getEvents();
  }

}
