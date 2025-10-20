import { Component, Output, EventEmitter, signal, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { StarshipService } from '../../core/services/starship.service';
import { Starship } from '../../core/models/starship.model';
import { LoaderComponent } from '../../shared/components/loader/loader.component';
import { CardComponent } from '../../shared/components/card/card.component';

@Component({
  selector: 'app-starship-detail',
  standalone: true,
  imports: [CommonModule, CardComponent, LoaderComponent],
  templateUrl: './starship-detail.component.html',
})
export class StarshipDetailComponent implements OnInit {
  starship = signal<Starship | null>(null);
  loading = signal<boolean>(false);
  error = signal<string | null>(null);

  // Event to notify parent to close modal
  @Output() closeModal = new EventEmitter<void>();

  constructor(private route: ActivatedRoute, private starshipService: StarshipService) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!isNaN(id)) {
      this.loading.set(true);
      this.starshipService.getStarshipById(id).subscribe({
        next: (data) => { 
          this.starship.set(data); 
          this.loading.set(false); 
        },
        error: () => { 
          this.error.set('Failed to load'); 
          this.loading.set(false); 
        }
      });
    } else {
      this.error.set('Invalid starship ID');
    }
  }

  close() {
    this.closeModal.emit();
  }
}
