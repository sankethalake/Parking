import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SharedService } from 'src/app/shared.service';
import { ParkingService } from '../parking.service';
import { Router } from '@angular/router';
import { SlotService } from 'src/app/slot/slot.service';

@Component({
  selector: 'app-add-parking',
  templateUrl: './add-parking.component.html',
  styleUrls: ['./add-parking.component.css']
})
export class AddParkingComponent implements OnInit {
  slot: any;
  vehicle: any
  constructor(private shared: SharedService, private service: ParkingService, private toastr: ToastrService, private router: Router, private slotService: SlotService) { }
  parkingModel = {
    "vehicle": {
      "vehicleNumber": "",
      "company": "",
      "model": "",
      "type": 1
    },
    "slot": {
      "slotID": "",
      "floor": "",
      "isParked": false,
      "type": 1
    },
    "parkedTime": new Date(),
    "unparkedTime": new Date()
  }

  ngOnInit(): void {
    this.slot = this.shared.getData();
    this.vehicle = this.shared.getVehicle();
  }
  BookParking() {
    this.parkingModel.vehicle = this.vehicle;
    this.parkingModel.slot = this.slot;
    this.parkingModel.parkedTime = new Date();
    this.parkingModel.unparkedTime = new Date();
    console.log(this.parkingModel);
    this.service.addParking(this.parkingModel).subscribe(
      res => {
        this.parkingModel.slot.isParked = true;
        this.slotService.updateSlot(this.parkingModel.slot).subscribe(
          res => {
            this.toastr.success("Booked");
            this.router.navigateByUrl('parkingSlot')
          },
          err => {
            this.toastr.error("error updating slot");
            this.router.navigateByUrl('parkingSlot')
          }
        )

      },
      err => {
        this.toastr.error(err.error);
      }
    )
  }

}
