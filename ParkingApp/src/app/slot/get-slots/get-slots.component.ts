import { Component, OnInit } from '@angular/core';
import { SlotService } from '../slot.service';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-get-slots',
  templateUrl: './get-slots.component.html',
  styleUrls: ['./get-slots.component.css']
})
export class GetSlotsComponent implements OnInit {
  slots: any = [];
  tempArray: any = [];
  constructor(public service: SlotService, private shared: SharedService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.GetSlots();
  }

  GetSlots() {
    this.service.getSlot().subscribe(
      (res: any) => {
        this.slots = res;
        console.log(this.slots)
      }
    )
  }

  GetAvailableSlots() {
    for (var temp of this.slots) {
      if (!temp.isParked) {
        this.tempArray.add(temp);
      }
    }
    this.slots = this.tempArray;
  }

  ToVehicle(s: any) {
    if (s.isParked) {
      this.toastr.warning("Slot Unavailable");
    }
    this.shared.setData(s);
    this.router.navigateByUrl('vehicle/add-vehicle')
  }

  DeleteSlot(slotID: any) {
    this.service.deleteSlot(slotID).subscribe(
      (res: any) => {
        this.toastr.success(res.message);
        this.router.navigateByUrl('slot/all-slots');
      },
      err => {
        this.toastr.error(err.error);
        this.router.navigateByUrl('slot/all-slots');
      }
    )


  }
}
