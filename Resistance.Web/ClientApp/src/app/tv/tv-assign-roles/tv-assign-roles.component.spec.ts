import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TvAssignRolesComponent } from './tv-assign-roles.component';

describe('TvAssignRolesComponent', () => {
  let component: TvAssignRolesComponent;
  let fixture: ComponentFixture<TvAssignRolesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TvAssignRolesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TvAssignRolesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
