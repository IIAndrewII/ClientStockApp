import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from '../../services/client.service';
import { Client } from '../../models/client.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-client-edit-form',
  templateUrl: './client-edit-form.component.html',
  styleUrls: ['./client-edit-form.component.css']
})
export class ClientEditFormComponent implements OnInit {
  client: Client = { id: 0, firstName: '', lastName: '', email: '', phoneNumber: '' };
  clientForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService
  ) {
    this.clientForm = this.fb.group({
      id: [0],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]]
    });
}

  ngOnInit(): void {
    // Accessing the id parameter safely
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
      const clientId = +id; // Convert id to number if not null
      if (!isNaN(clientId)) { // Check if clientId is a valid number
        this.clientService.getClientById(clientId).subscribe(client => {
          this.client = client;
        });
      } else {
        console.error('Invalid id parameter:', id);
        // Handle the case where id is not a valid number
      }
    } else {
      console.error('Missing id parameter.');
      // Handle the case where id parameter is missing
    }
  }

  save(): void {
    if (this.client.id !== undefined) {
      this.clientService.updateClient(this.client.id, this.client).subscribe(() => {
        this.router.navigate(['/clients']);
      });
    } else {
      this.clientService.addClient(this.client).subscribe(() => {
        this.router.navigate(['/clients']);
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/clients']);
  }
}
