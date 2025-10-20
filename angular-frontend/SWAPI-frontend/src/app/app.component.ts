import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { StarshipListComponent } from './features/starship-list/starship-list.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,RouterModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SWAPI-frontend';
}
