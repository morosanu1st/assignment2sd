import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabManagementComponent } from './lab-management.component';

describe('LabManagementComponent', () => {
  let component: LabManagementComponent;
  let fixture: ComponentFixture<LabManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
