import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcersiseComponent } from './excersise.component';

describe('ExcersiseComponent', () => {
  let component: ExcersiseComponent;
  let fixture: ComponentFixture<ExcersiseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExcersiseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExcersiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
