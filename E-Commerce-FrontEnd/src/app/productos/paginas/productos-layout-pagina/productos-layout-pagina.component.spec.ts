import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductosLayoutPaginaComponent } from './productos-layout-pagina.component';

describe('ProductosLayoutPaginaComponent', () => {
  let component: ProductosLayoutPaginaComponent;
  let fixture: ComponentFixture<ProductosLayoutPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProductosLayoutPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProductosLayoutPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
