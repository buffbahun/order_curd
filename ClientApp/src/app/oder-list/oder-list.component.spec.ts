import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OderListComponent } from './oder-list.component';

describe('OderListComponent', () => {
  let component: OderListComponent;
  let fixture: ComponentFixture<OderListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OderListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
