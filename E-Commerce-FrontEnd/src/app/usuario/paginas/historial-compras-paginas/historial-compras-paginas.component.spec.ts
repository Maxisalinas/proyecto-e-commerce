import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistorialComprasPaginasComponent } from './historial-compras-paginas.component';

describe('HistorialComprasPaginasComponent', () => {
  let component: HistorialComprasPaginasComponent;
  let fixture: ComponentFixture<HistorialComprasPaginasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HistorialComprasPaginasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HistorialComprasPaginasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
