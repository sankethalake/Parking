import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  data:any
  constructor() { }
  setData(_data:any){
    this.data = _data
  }
  getData(){
    return this.data
  }
}
