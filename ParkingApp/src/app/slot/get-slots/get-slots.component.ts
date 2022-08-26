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
  slotToBeBooked: any;
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

  ToVehicle(slotID: any) {
    this.slotToBeBooked = this.service.getSlotByid(slotID)
    this.shared.setData(this.slotToBeBooked);
    this.router.navigateByUrl('vehicle/add-vehicle')
  }

  DeleteSlot(slotID: any) {
    this.toastr.info("Delete need to be added in microservice");
    this.router.navigateByUrl('slot/all-slots');
  }
}
