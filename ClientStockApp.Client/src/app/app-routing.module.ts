import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientListComponent } from './components/client-list/client-list.component';
import { ClientFormComponent } from './components/client-form/client-form.component';
import { StockMarketComponent } from './components/stock-market/stock-market.component';
import { ClientEditFormComponent } from './components/client-edit-form/client-edit-form.component'; // Update with correct path


const routes: Routes = [
  { path: 'clients', component: ClientListComponent },
  { path: 'clients/new', component: ClientFormComponent },
  { path: 'clients/edit/:id', component: ClientFormComponent },
  { path: 'stock-market', component: StockMarketComponent },
  { path: '', redirectTo: '/clients', pathMatch: 'full' },
  { path: 'clients/edit/:id', component: ClientEditFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
