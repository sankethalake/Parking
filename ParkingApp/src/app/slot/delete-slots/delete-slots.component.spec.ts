import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteSlotsComponent } from './delete-slots.component';

describe('DeleteSlotsComponent', () => {
  let component: DeleteSlotsComponent;
  let fixture: ComponentFixture<DeleteSlotsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteSlotsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteSlotsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
