import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { VehicleService } from '../vehicle.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-get-vehicle',
  templateUrl: './get-vehicle.component.html',
  styleUrls: ['./get-vehicle.component.css']
})
export class GetVehicleComponent implements OnInit {
  slotId: any;
  constructor(public shared: SharedService, public service: VehicleService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {

  }

  getVehicle(id: any) {
    this.service.getVehiclesByid(id).subscribe(
      (res: any) => {
        if (this.shared.getData().type == res.type) {
          this.shared.setVehicle(res);
          this.router.navigateByUrl('parking/book-parking');
        }
        else {
          this.toastr.warning("Invalid Slot or Vehicle")
        }

      },
      err => {
        this.toastr.info(err.error);
        this.router.navigateByUrl('/vehicle/add-vehicle')
      }
    )
  }

}
