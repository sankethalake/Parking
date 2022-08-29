import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ParkingService } from '../parking.service';
import { SlotService } from 'src/app/slot/slot.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-update-parking',
  templateUrl: './update-parking.component.html',
  styleUrls: ['./update-parking.component.css']
})
export class UpdateParkingComponent implements OnInit {
  parking: any;
  slot: any;

  constructor(private shared: SharedService, private service: ParkingService, private router: Router, private slotService: SlotService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.RefreshData();
  }

  RefreshData() {
    this.slot = this.shared.getData();
    this.service.getParkingBySlot(this.slot.slotID).subscribe(
      res => {
        this.parking = res;
        this.parking.unparkedTime = new Date();
        console.log(this.parking);
      }
    )
  }

  EndParking() {
    console.log(this.parking.slot.slotID);
    this.service.updateParking(this.parking).subscribe(
      res => {
        this.parking.slot.isParked = false;
        this.slotService.updateSlot(this.parking.slot).subscribe(
          res => {
            this.router.navigateByUrl("parkingSlot");
          }
        )
        // this.slotService.getSlotByid(this.parking.slot.SlotID).subscribe(
        //   res => {
        //     this.parking.slot = res;
        //     this.parking.slot.isParked = false;
        //     this.slotService.updateSlot(this.parking.slot);
        //   }
        // )
      }
    )
  }

}
