import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TvTeamPickComponent } from './tv-team-pick.component';

describe('TvTeamPickComponent', () => {
  let component: TvTeamPickComponent;
  let fixture: ComponentFixture<TvTeamPickComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TvTeamPickComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TvTeamPickComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
