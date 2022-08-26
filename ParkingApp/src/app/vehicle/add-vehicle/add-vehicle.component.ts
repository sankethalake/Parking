import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { VehicleService } from '../vehicle.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrls: ['./add-vehicle.component.css']
})
export class AddVehicleComponent implements OnInit {

  vehicleModel={
    "vehicleNumber": "",
    "company": "",
    "model": "",
    "type": 1
  }
  constructor(private service: VehicleService, private router:Router, private toastr:ToastrService) { }

  ngOnInit(): void {
  }
  onSubmitVehicle(vehicleData: NgForm){
    //console.warn(playerData);
    this.vehicleModel.vehicleNumber=String(vehicleData.value.vehicleNumber)
    this.vehicleModel.company=String(vehicleData.value.company);
    this.vehicleModel.model=String(vehicleData.value.company);
    this.vehicleModel.type=Number(vehicleData.value.type)
    this.router.navigateByUrl("vehicle/all-vehicle");
    this.service.addVehicle(this.vehicleModel).subscribe(
      (res)  => {
      this.toastr.success(res.message);
      this.router.navigateByUrl("vehicle/all-vehicle");
    },
    // err=>{
    //   this.toastr.error(err.error);
    // }
    )
    vehicleData.reset();
  }

}
