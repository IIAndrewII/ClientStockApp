import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StockMarketData } from '../models/stock-market-data.model';

@Injectable({
  providedIn: 'root'
})
export class StockMarketService {
  private apiUrl = 'https://localhost:5001/api/stockmarketdata';

  constructor(private http: HttpClient) { }

  getStockMarketData(): Observable<StockMarketData[]> {
    return this.http.get<StockMarketData[]>(this.apiUrl);
  }
}