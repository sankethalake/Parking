import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ParkingComponent } from './parking/parking.component';
import { AddSlotComponent } from './slot/add-slot/add-slot.component';
import { GetSlotsComponent } from './slot/get-slots/get-slots.component';
import { SlotComponent } from './slot/slot.component';
import { AddVehicleComponent } from './vehicle/add-vehicle/add-vehicle.component';
import { AllVehiclesComponent } from './vehicle/all-vehicles/all-vehicles.component';
import { GetVehicleComponent } from './vehicle/get-vehicle/get-vehicle.component';
import { VehicleComponent } from './vehicle/vehicle.component';

const routes: Routes = [
  { path: "home", component: HomeComponent },
  {
    path: "vehicle", component: VehicleComponent, children: [
      { path: 'get-vehicle', component: GetVehicleComponent },
      { path: 'add-vehicle', component: AddVehicleComponent },
      { path: 'all-vehicle', component: AllVehiclesComponent }
    ]
  },
  {
    path: "parkingSlot", component: SlotComponent, children: [
      { path: 'add-slot', component: AddSlotComponent },
      { path: 'all-slots', component: GetSlotsComponent }
    ]
  },
  { path: "parking", component: ParkingComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
