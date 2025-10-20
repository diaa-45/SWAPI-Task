import { Component, Input } from '@angular/core';
import { Starship } from '../../../core/models/starship.model';

@Component({
  selector: 'app-card',
  standalone: true,
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent {
  @Input() starship!: Starship;
}
