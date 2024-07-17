import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { Client } from '../../models/client.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {
  client: Client = { firstName: '', lastName: '', email: '', phoneNumber: '' };
  isEdit = false;

  constructor(
    private clientService: ClientService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEdit = true;
      this.clientService.getClient(+id).subscribe((client) => {
        this.client = client;
      });
    }
  }

  saveClient(): void {
    if (this.isEdit) {
      this.clientService.updateClient(this.client.id!, this.client).subscribe(() => {
        this.router.navigate(['/clients']);
      });
    } else {
      this.clientService.addClient(this.client).subscribe(() => {
        this.router.navigate(['/clients']);
      });
    }
  }
}
