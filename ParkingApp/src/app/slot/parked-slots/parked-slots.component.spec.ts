import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParkedSlotsComponent } from './parked-slots.component';

describe('ParkedSlotsComponent', () => {
  let component: ParkedSlotsComponent;
  let fixture: ComponentFixture<ParkedSlotsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParkedSlotsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParkedSlotsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
