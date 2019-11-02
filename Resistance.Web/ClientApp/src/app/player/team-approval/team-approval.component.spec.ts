import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamApprovalComponent } from './team-approval.component';

describe('TeamApprovalComponent', () => {
  let component: TeamApprovalComponent;
  let fixture: ComponentFixture<TeamApprovalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeamApprovalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
