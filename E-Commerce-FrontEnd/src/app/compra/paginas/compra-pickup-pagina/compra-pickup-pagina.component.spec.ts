import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompraPickupPaginaComponent } from './compra-pickup-pagina.component';

describe('CompraPickupPaginaComponent', () => {
  let component: CompraPickupPaginaComponent;
  let fixture: ComponentFixture<CompraPickupPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CompraPickupPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompraPickupPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
