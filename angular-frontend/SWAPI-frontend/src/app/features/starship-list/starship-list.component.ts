import { ChangeDetectionStrategy, Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Starship } from '../../core/models/starship.model';
import { StarshipService } from '../../core/services/starship.service';
import { Router, RouterModule } from '@angular/router';
import { CardComponent } from '../../shared/components/card/card.component';
import { LoaderComponent } from '../../shared/components/loader/loader.component';
import { HttpClientModule } from '@angular/common/http';
@Component({
  selector: 'app-starship-list',
  standalone: true,
  imports: [CommonModule,RouterModule,CardComponent, LoaderComponent,HttpClientModule],
  templateUrl: './starship-list.component.html',
  styleUrls: ['./starship-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class StarshipListComponent implements OnInit {
  starships = signal<Starship[]>([]);
  loading = signal<boolean>(false);
  error = signal<string | null>(null);
  currency = signal<string>('GC');

  constructor(
    private starshipService: StarshipService,
    private router: Router
  ) {}

  ngOnInit() {
    //this.loadStarships();
    
    this.loading.set(true);
    this.error.set(null);
    this.starshipService.getStarships(this.currency()).subscribe({
      next: (items) => { this.starships.set(items); this.loading.set(false); },
      error: () => { this.error.set('Failed to load starships'); this.loading.set(false); }
    });
  }
  
  /* loadStarships() {
    this.loading.set(true);
    this.error.set(null);
    this.starshipService.getStarships(this.currency()).subscribe({
      next: (items) => { this.starships.set(items); this.loading.set(false); },
      error: () => { this.error.set('Failed to load starships'); this.loading.set(false); }
    });
  }
 */
  changeCurrency(c: string) {
    this.currency.set(c);
    //this.loadStarships();
  }

  openDetail(id: number) {
    this.router.navigate(['/starships', id]);
  }
}
