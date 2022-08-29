import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ParkingService {
  readonly APIurl = "http://localhost:11635/api/Parking";

  constructor(private http: HttpClient) { }
  addParking(parking: any): Observable<any> {
    return this.http.post(this.APIurl, parking);
  }
  updateParking(parking: any) {
    return this.http.put(this.APIurl, parking);
  }
  getParkingBySlot(slotId: any) {
    return this.http.get(this.APIurl + "/" + slotId);
  }
}
