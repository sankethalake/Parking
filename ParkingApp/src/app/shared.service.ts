import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  slot: any;
  vehicle: any
  constructor() { }
  // set slot slot
  setData(_data: any) {
    this.slot = _data;
  }
  // GEt slot slot
  getData() {
    return this.slot
  }

  // set vehicle slot
  setVehicle(_data: any) {
    this.vehicle = _data
  }

  // GEt vehicle slot
  getVehicle() {
    return this.vehicle
  }
}
