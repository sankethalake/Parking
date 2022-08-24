import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  readonly APIurl = "http://localhost:55506/api/Vehicle";

  constructor(private http:HttpClient) { }
  getVehicles():Observable<any[]>{
    return this.http.get<any>(this.APIurl);
  }
  getVehiclesByid(id:number):Observable<any[]>{
    return this.http.get<any>(this.APIurl + id);
  }
  addVehicle(vehicle:any):Observable<any>{
    return this.http.post(this.APIurl , vehicle);
  }
  deleteVehicle(vehicleNumber:any):Observable<any>{
    return this.http.delete(this.APIurl+vehicleNumber);
  }
}
