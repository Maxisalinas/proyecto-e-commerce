import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioLayoutPaginaComponent } from './usuario-layout-pagina.component';

describe('UsuarioLayoutPaginaComponent', () => {
  let component: UsuarioLayoutPaginaComponent;
  let fixture: ComponentFixture<UsuarioLayoutPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UsuarioLayoutPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UsuarioLayoutPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
