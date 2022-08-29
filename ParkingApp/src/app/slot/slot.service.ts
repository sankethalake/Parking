import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SlotService {
  readonly APIurl = "http://localhost:57481/api/Slot";

  constructor(private http: HttpClient) { }
  getSlot(): Observable<any[]> {
    return this.http.get<any>(this.APIurl);
  }
  getSlotByid(id: number) {
    return this.http.get(this.APIurl + "/getSlot/" + id);
  }
  getParkedSlot(): Observable<any[]> {
    return this.http.get<any>(this.APIurl + "getParkedSlots");
  }
  getUnparkedSlot(): Observable<any[]> {
    return this.http.get<any>(this.APIurl + "getUnparkedSlots");
  }
  addSlot(slot: any): Observable<any> {
    return this.http.post(this.APIurl, slot);
  }
  deleteSlot(slotId: any) {
    console.log(slotId);
    return this.http.delete(this.APIurl + "/" + Number(slotId));
  }
  updateSlot(slot: any): Observable<any> {
    return this.http.put(this.APIurl, slot);
  }
}
