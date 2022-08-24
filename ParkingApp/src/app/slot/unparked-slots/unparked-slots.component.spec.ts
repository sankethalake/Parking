import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnparkedSlotsComponent } from './unparked-slots.component';

describe('UnparkedSlotsComponent', () => {
  let component: UnparkedSlotsComponent;
  let fixture: ComponentFixture<UnparkedSlotsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnparkedSlotsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UnparkedSlotsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
