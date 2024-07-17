import { Component, OnInit } from '@angular/core';
import { StockMarketService } from '../../services/stock-market.service';
import { StockMarketData } from '../../models/stock-market-data.model';

@Component({
  selector: 'app-stock-market',
  templateUrl: './stock-market.component.html',
  styleUrls: ['./stock-market.component.css']
})
export class StockMarketComponent implements OnInit {
  stockMarketData: StockMarketData[] = [];

  constructor(private stockMarketService: StockMarketService) { }

  ngOnInit(): void {
    this.loadStockMarketData();
  }

  loadStockMarketData(): void {
    this.stockMarketService.getStockMarketData().subscribe((data) => {
      this.stockMarketData = data;
    });
  }
}
