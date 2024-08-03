import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdenarBusquedaComponent } from './ordenar-busqueda.component';

describe('OrdenarBusquedaComponent', () => {
  let component: OrdenarBusquedaComponent;
  let fixture: ComponentFixture<OrdenarBusquedaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OrdenarBusquedaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OrdenarBusquedaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
