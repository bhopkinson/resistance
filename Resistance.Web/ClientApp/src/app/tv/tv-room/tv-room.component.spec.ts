import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TvRoomComponent } from './tv-room.component';

describe('TvRoomComponent', () => {
  let component: TvRoomComponent;
  let fixture: ComponentFixture<TvRoomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TvRoomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TvRoomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
