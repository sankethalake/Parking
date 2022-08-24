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
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
