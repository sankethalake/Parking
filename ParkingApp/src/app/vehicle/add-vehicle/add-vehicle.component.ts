import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { VehicleService } from '../vehicle.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrls: ['./add-vehicle.component.css']
})
export class AddVehicleComponent implements OnInit {

  vehicleModel = {
    "vehicleNumber": "",
    "company": "",
    "model": "",
    "type": 1
  }
  constructor(private service: VehicleService, private router: Router, private toastr: ToastrService, private shared: SharedService) { }

  ngOnInit(): void {
  }
  onSubmitVehicle(vehicleData: NgForm) {
    //console.warn(playerData);
    console.log(this.vehicleModel);
    // this.vehicleModel.vehicleNumber = String(vehicleData.value.vehicleNumber)
    // this.vehicleModel.company = String(vehicleData.value.company);
    // this.vehicleModel.model = String(vehicleData.value.company);
    this.vehicleModel.type = Number(vehicleData.value.type);
    // console.log(vehicleData);
    this.service.addVehicle(this.vehicleModel).subscribe(
      (res) => {
        console.log(res.type);
        this.shared.setVehicle(res);
        this.toastr.success(res.message);
        this.router.navigateByUrl('parking/book-parking');
      },
      err => {
        this.toastr.error(err.error);
        console.log(err.error);
      }
    )
    vehicleData.reset();
  }

}
