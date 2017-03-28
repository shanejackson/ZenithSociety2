import { Component } from '@angular/core';
import {Account} from './account';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Zenith Society';
  auth = false;
  user: Account = {
    Username: "USER",
  }

}
