import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompraPagoPaginaComponent } from './compra-pago-pagina.component';

describe('CompraPagoPaginaComponent', () => {
  let component: CompraPagoPaginaComponent;
  let fixture: ComponentFixture<CompraPagoPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CompraPagoPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompraPagoPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
