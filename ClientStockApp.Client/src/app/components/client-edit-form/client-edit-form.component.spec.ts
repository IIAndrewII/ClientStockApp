import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from '../../services/client.service';
import { Client } from '../../models/client.model'; // Ensure correct path to your client model

@Component({
  selector: 'app-client-edit-form',
  templateUrl: './client-edit-form.component.html',
  styleUrls: ['./client-edit-form.component.css']
})
export class ClientEditFormComponent implements OnInit {
  client: Client = { id: 0, firstName: '', lastName: '', email: '', phoneNumber: '' }; // Initialize with default values

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService
  ) { }

  ngOnInit(): void {
    const clientId = +this.route.snapshot.paramMap.get('id');
    this.clientService.getClientById(clientId).subscribe(client => {
      this.client = client;
    });
  }

  save(): void {
    if (this.isEdit) {
      this.clientService.updateClient(this.client.id!, this.client).subscribe(() => {
        this.router.navigate(['/clients']);
      });
    } else {
      this.clientService.addClient(this.client).subscribe(() => {
        this.router.navigate(['/clients']);
      });

  cancel(): void {
    this.router.navigate(['/clients']);
  }

