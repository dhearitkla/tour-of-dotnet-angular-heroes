import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

import { HeroesComponent } from './heroes/heroes.component';
import { HeroDetailComponent} from "./hero-detail/hero-detail.component";
import { MessagesComponent} from "./messages/messages.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeroesComponent, HeroDetailComponent, MessagesComponent, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Tour of Heroes';
}
