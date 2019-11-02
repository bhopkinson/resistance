import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TvMissionComponent } from './tv-mission.component';

describe('TvMissionComponent', () => {
  let component: TvMissionComponent;
  let fixture: ComponentFixture<TvMissionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TvMissionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TvMissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
