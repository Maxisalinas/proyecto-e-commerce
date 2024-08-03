import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompraLayoutPaginaComponent } from './compra-layout-pagina.component';

describe('CompraLayoutPaginaComponent', () => {
  let component: CompraLayoutPaginaComponent;
  let fixture: ComponentFixture<CompraLayoutPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CompraLayoutPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompraLayoutPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
