import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { KendoUIModule } from './kendo-ui/kendo-ui.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientListComponent } from './components/client-list/client-list.component';
import { ClientFormComponent } from './components/client-form/client-form.component';
import { StockMarketComponent } from './components/stock-market/stock-market.component';
import { ClientService } from './services/client.service';
import { StockMarketService } from './services/stock-market.service';
import { ClientEditFormComponent } from './components/client-edit-form/client-edit-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ClientListComponent,
    ClientFormComponent,
    StockMarketComponent,
    ClientEditFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    MatToolbarModule,
    MatButtonModule,
    KendoUIModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [ClientService, StockMarketService],
  bootstrap: [AppComponent]
})
export class AppModule { }
