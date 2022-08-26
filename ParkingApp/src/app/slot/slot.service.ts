import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SlotService {
  readonly APIurl = "http://localhost:57481/api/Slot";

  constructor(private http:HttpClient) { }
  getSlot():Observable<any[]>{
    return this.http.get<any>(this.APIurl);
  }
  getSlotByid(id:number):Observable<any[]>{
    return this.http.get<any>(this.APIurl + id);
  }
  getParkedSlot():Observable<any[]>{
    return this.http.get<any>(this.APIurl+"getParkedSlots");
  }
  getUnparkedSlot():Observable<any[]>{
    return this.http.get<any>(this.APIurl+"getUnparkedSlots");
  }
  addSlot(slot:any):Observable<any>{
    return this.http.post(this.APIurl , slot);
  }
  deleteVehicle(slotId:any):Observable<any>{
    return this.http.delete(this.APIurl+slotId);
  }
}
