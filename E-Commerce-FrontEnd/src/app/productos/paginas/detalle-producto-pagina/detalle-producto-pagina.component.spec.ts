import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleProductoPaginaComponent } from './detalle-producto-pagina.component';

describe('DetalleProductoPaginaComponent', () => {
  let component: DetalleProductoPaginaComponent;
  let fixture: ComponentFixture<DetalleProductoPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetalleProductoPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DetalleProductoPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
