import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TvInvestigationComponent } from './tv-investigation.component';

describe('TvInvestigationComponent', () => {
  let component: TvInvestigationComponent;
  let fixture: ComponentFixture<TvInvestigationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TvInvestigationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TvInvestigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
