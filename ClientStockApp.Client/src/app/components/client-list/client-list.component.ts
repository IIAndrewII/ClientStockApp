import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientService } from '../../services/client.service';
import { Client } from '../../models/client.model';
import { GridDataResult, PageChangeEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { process, State } from '@progress/kendo-data-query';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {
  clients: Client[] = [];
  gridData: GridDataResult;
  skip = 0;
  pageSize = 10;

  constructor(private clientService: ClientService, private router: Router) {
    this.gridData = { data: [], total: 0 };
  }
  ngOnInit(): void {
    this.loadClients();
  }

  loadClients(): void {
    this.clientService.getClients().subscribe((clients) => {
      this.clients = clients;
      this.gridData = process(this.clients, { skip: this.skip, take: this.pageSize });
    });
  }

  pageChange(event: PageChangeEvent): void {
    this.skip = event.skip;
    this.gridData = process(this.clients, { skip: this.skip, take: this.pageSize });
  }

  dataStateChange(state: DataStateChangeEvent): void {
    this.skip = state.skip;
    this.pageSize = state.take;
    this.gridData = process(this.clients, state);
  }

  editClient(id: number): void {
    this.router.navigate(['/clients/edit', id]);
  }

  deleteClient(id: number): void {
    this.clientService.deleteClient(id).subscribe(() => {
      this.loadClients();
    });
  }
}
