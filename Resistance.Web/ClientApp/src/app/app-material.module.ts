import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatCardModule, MatIconModule, MatChipsModule, MatDialogModule, MatInputModule, MatFormFieldModule } from '@angular/material';
import { MatProgressButtonsModule } from 'mat-progress-buttons';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatButtonModule,
    MatCardModule,
    MatChipsModule,
    MatDialogModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatProgressButtonsModule
  ],
  exports: [
    MatButtonModule,
    MatCardModule,
    MatChipsModule,
    MatDialogModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatProgressButtonsModule
  ]
})
export class AppMaterialModule { }
