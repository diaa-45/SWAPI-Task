// currency-display.pipe.ts
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'currencyDisplay',
  standalone: true
})
export class CurrencyDisplayPipe implements PipeTransform {
  transform(value: string | number, currency: string = 'GC'): string {
    if (!value) return 'Unknown';
    switch (currency.toUpperCase()) {
      case 'USD':
        return `$${Number(value) * 1.5}`;
      case 'EUR':
        return `€${Number(value) * 1.3}`;
      default:
        return `${value} GC`;
    }
  }
}
