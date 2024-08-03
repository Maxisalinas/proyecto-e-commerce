import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfiguracionPaginaComponent } from './configuracion-pagina.component';

describe('ConfiguracionPaginaComponent', () => {
  let component: ConfiguracionPaginaComponent;
  let fixture: ComponentFixture<ConfiguracionPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ConfiguracionPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ConfiguracionPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
