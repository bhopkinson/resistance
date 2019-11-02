import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HuntingComponent } from './hunting.component';

describe('HuntingComponent', () => {
  let component: HuntingComponent;
  let fixture: ComponentFixture<HuntingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HuntingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HuntingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
