import { Routes } from '@angular/router';
import { StarshipListComponent } from './features/starship-list/starship-list.component';
import { StarshipDetailComponent } from './features/starship-detail/starship-detail.component';

export const routes: Routes = [
  { path: '', redirectTo: 'starships', pathMatch: 'full' },
  { path: 'starships', component: StarshipListComponent },
  { path: 'starships/:id', component: StarshipDetailComponent },
  { path: '**', redirectTo: 'starships' }
];

