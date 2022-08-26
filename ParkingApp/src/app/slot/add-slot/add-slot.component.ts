import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SlotService } from '../slot.service';

@Component({
  selector: 'app-add-slot',
  templateUrl: './add-slot.component.html',
  styleUrls: ['./add-slot.component.css']
})
export class AddSlotComponent implements OnInit {

  slotModel = {
    "slotID": "",
    "floor": "",
    "isParked": false,
    "type": 1
  }

  constructor(private service: SlotService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmitSlot(slotData: NgForm) {
    this.slotModel.floor = String(slotData.value.floor)
    this.slotModel.isParked = false;
    this.slotModel.type = Number(slotData.value.type)
    this.router.navigateByUrl("vehicle/all-vehicle");
    this.service.addSlot(this.slotModel).subscribe(
      (res) => {
        this.toastr.success(res.message);
        this.router.navigateByUrl("/parkingSlot");
      },
      // err=>{
      //   this.toastr.error(err.error);
      // }
    )
    slotData.reset();
  }
}
