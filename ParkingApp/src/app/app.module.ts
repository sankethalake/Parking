import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VehicleComponent } from './vehicle/vehicle.component';
import { AddVehicleComponent } from './vehicle/add-vehicle/add-vehicle.component';
import { AllVehiclesComponent } from './vehicle/all-vehicles/all-vehicles.component';
import { GetVehicleComponent } from './vehicle/get-vehicle/get-vehicle.component';
import { DeleteComponent } from './vehicle/delete/delete.component';
import { SlotComponent } from './slot/slot.component';
import { GetSlotsComponent } from './slot/get-slots/get-slots.component';
import { GetSlotByidComponent } from './slot/get-slot-byid/get-slot-byid.component';
import { ParkedSlotsComponent } from './slot/parked-slots/parked-slots.component';
import { UnparkedSlotsComponent } from './slot/unparked-slots/unparked-slots.component';
import { UpdateSlotsComponent } from './slot/update-slots/update-slots.component';
import { DeleteSlotsComponent } from './slot/delete-slots/delete-slots.component';
import { ParkingComponent } from './parking/parking.component';
import { AddParkingComponent } from './parking/add-parking/add-parking.component';
import { UpdateParkingComponent } from './parking/update-parking/update-parking.component';
import { VehicleService } from './vehicle/vehicle.service';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    VehicleComponent,
    AddVehicleComponent,
    AllVehiclesComponent,
    GetVehicleComponent,
    DeleteComponent,
    SlotComponent,
    GetSlotsComponent,
    GetSlotByidComponent,
    ParkedSlotsComponent,
    UnparkedSlotsComponent,
    UpdateSlotsComponent,
    DeleteSlotsComponent,
    ParkingComponent,
    AddParkingComponent,
    UpdateParkingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar:true
    })
  ],
  providers: [VehicleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
