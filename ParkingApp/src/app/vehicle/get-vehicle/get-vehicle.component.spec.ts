import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetVehicleComponent } from './get-vehicle.component';

describe('GetVehicleComponent', () => {
  let component: GetVehicleComponent;
  let fixture: ComponentFixture<GetVehicleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetVehicleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetVehicleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
