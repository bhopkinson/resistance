/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GameLobbyPageComponent } from './game-lobby-page.component';

describe('GameLobbyPageComponent', () => {
  let component: GameLobbyPageComponent;
  let fixture: ComponentFixture<GameLobbyPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameLobbyPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameLobbyPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
