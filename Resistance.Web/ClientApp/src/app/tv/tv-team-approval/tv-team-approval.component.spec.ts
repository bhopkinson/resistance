import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TvTeamApprovalComponent } from './tv-team-approval.component';

describe('TvTeamApprovalComponent', () => {
  let component: TvTeamApprovalComponent;
  let fixture: ComponentFixture<TvTeamApprovalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TvTeamApprovalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TvTeamApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
