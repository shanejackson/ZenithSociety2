import { Component } from '@angular/core';
import {Account} from './account';
import {ZenithEventService} from './zenith-event.service';
import {ZenithActivityService} from './zenith-activity.service';
import {AuthService} from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ZenithEventService, ZenithActivityService, AuthService]
})
export class AppComponent {
  title = 'Zenith Society';
  auth = false;
  user: Account = {
    Username: "USER",
  }

}
