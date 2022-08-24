import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetSlotByidComponent } from './get-slot-byid.component';

describe('GetSlotByidComponent', () => {
  let component: GetSlotByidComponent;
  let fixture: ComponentFixture<GetSlotByidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetSlotByidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetSlotByidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
