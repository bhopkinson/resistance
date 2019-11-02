import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TvGameOverComponent } from './tv-game-over.component';

describe('TvGameOverComponent', () => {
  let component: TvGameOverComponent;
  let fixture: ComponentFixture<TvGameOverComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TvGameOverComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TvGameOverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
