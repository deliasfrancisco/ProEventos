import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PalestratantesComponent } from './palestratantes.component';

describe('PalestratantesComponent', () => {
  let component: PalestratantesComponent;
  let fixture: ComponentFixture<PalestratantesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PalestratantesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PalestratantesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
