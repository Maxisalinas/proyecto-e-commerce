import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutenticacionLayoutPaginaComponent } from './autenticacion-layout-pagina.component';

describe('AutenticacionLayoutPaginaComponent', () => {
  let component: AutenticacionLayoutPaginaComponent;
  let fixture: ComponentFixture<AutenticacionLayoutPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AutenticacionLayoutPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AutenticacionLayoutPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
