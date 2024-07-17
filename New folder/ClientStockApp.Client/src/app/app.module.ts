import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientListComponent } from './components/client-list/client-list.component';
import { ClientFormComponent } from './components/client-form/client-form.component';
import { StockMarketComponent } from './components/stock-market/stock-market.component';
import { KendoUIModule } from './kendo-ui/kendo-ui.module';
import { ClientService } from './services/client.service';
import { StockMarketService } from './services/stock-market.service';

@NgModule({
  declarations: [
    AppComponent,
    ClientListComponent,
    ClientFormComponent,
    StockMarketComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule, // Ensure RouterModule is imported
    KendoUIModule,
    AppRoutingModule
  ],
  providers: [ClientService, StockMarketService],
  bootstrap: [AppComponent]
})
export class AppModule { }
