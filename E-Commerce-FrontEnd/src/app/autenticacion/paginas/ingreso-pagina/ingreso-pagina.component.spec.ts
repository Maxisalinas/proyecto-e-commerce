import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngresoPaginaComponent } from './ingreso-pagina.component';

describe('IngresoPaginaComponent', () => {
  let component: IngresoPaginaComponent;
  let fixture: ComponentFixture<IngresoPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IngresoPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IngresoPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
