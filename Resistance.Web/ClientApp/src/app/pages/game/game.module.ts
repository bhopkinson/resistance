import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MqttService } from 'ngx-mqtt';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AppMaterialModule } from 'src/app/app-material.module';
import { AppRoutingModule } from 'src/app/app-routing.module';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    AppRoutingModule,
    FlexLayoutModule,
  ],
  declarations: [
  ],
  providers: [
    MqttService
  ]
})
export class GameModule { }
