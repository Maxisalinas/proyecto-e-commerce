import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeLayoutPaginaComponent } from './home-layout-pagina.component';

describe('HomeLayoutPaginaComponent', () => {
  let component: HomeLayoutPaginaComponent;
  let fixture: ComponentFixture<HomeLayoutPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HomeLayoutPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeLayoutPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
