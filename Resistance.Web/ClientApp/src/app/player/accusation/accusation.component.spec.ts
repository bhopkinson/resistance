import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccusationComponent } from './accusation.component';

describe('AccusationComponent', () => {
  let component: AccusationComponent;
  let fixture: ComponentFixture<AccusationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccusationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccusationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
