import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { SlotService } from './slot.service';
import { UserService } from '../User/user.service';

@Component({
  selector: 'app-slot',
  templateUrl: './slot.component.html',
  styleUrls: ['./slot.component.css']
})
export class SlotComponent implements OnInit {
  slots: any = [];
  // tempArray: any = [];
  slot: any;
  constructor(public service: SlotService, private shared: SharedService, private router: Router, private toastr: ToastrService, public userService: UserService) { }

  ngOnInit(): void {
    this.GetSlots();
  }
  GetSlots() {
    this.service.getSlot().subscribe(
      (res: any) => {
        this.slots = res;

      }
    )
  }

  GetAvailableSlots() {
    var tempArray = new Array();
    for (var temp of this.slots) {
      if (!temp.isParked) {
        tempArray.push(temp);

      }
    }
    this.slots = new Array();
    tempArray.forEach(val => this.slots.push(Object.assign({}, val)));
  }


  ToVehicle(slot: any) {
    if (slot.isParked) {
      this.toastr.warning("Slot Unavailable");
    }
    else {
      this.shared.setData(slot);
      this.router.navigateByUrl('vehicle/search-vehicle')
    }
  }

  EndParking(slot: any) {
    if (!slot.isParked) {
      this.toastr.warning("Select Correct Slot");
      return;
    }
    this.shared.setData(slot);
    this.router.navigateByUrl('parking/end-parking');
  }
  DeleteSlot(slotID: any) {
    console.log(Number(slotID));
    console.log(this.service.getSlotByid(Number(slotID)));
    this.service.deleteSlot(Number(slotID)).subscribe(
      (res: any) => {
        this.toastr.success(res.message);
        this.router.navigateByUrl('parkingSlot');
      },
      err => {
        this.toastr.error(err.error);
        this.router.navigateByUrl('parkingSlot');
      }
    )


  }
}
