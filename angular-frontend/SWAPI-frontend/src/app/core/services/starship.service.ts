import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Starship } from '../models/starship.model';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class StarshipService {
  constructor(private http: HttpClient) {}
  private base = `${environment.apiBaseUrl}/Starships`;

  getStarships(currency: string = 'GC'): Observable<Starship[]> {
    const params = new HttpParams().set('currency', currency);
    return this.http.get<Starship[]>('https://localhost:7273/api/Starships', { params });
  }

  getStarshipById(id: number, currency: string = 'GC'): Observable<Starship> {
    const url = `${this.base}/${id}`;
    const params = new HttpParams().set('currency', currency);
    return this.http.get<Starship>(url, { params });
  }
}
