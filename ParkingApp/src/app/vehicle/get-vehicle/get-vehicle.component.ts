import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { VehicleService } from '../vehicle.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-get-vehicle',
  templateUrl: './get-vehicle.component.html',
  styleUrls: ['./get-vehicle.component.css']
})
export class GetVehicleComponent implements OnInit {
  slotId:any;
  vehicle:any;
  constructor(public shared:SharedService, public service:VehicleService, private router:Router) { }

  ngOnInit(): void {
    this.slotId = this.shared.getData();
    
  }

  getVehicle(id:any){
    this.service.getVehiclesByid(id).subscribe(
      (res:any)=>{
        this.vehicle=res

      },
      err=>{
        this.router.navigateByUrl('/vehicle/add-vehicle')
      }
    )
  }

}
