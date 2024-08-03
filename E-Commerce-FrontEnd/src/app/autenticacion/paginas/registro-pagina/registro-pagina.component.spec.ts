import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroPaginaComponent } from './registro-pagina.component';

describe('RegistroPaginaComponent', () => {
  let component: RegistroPaginaComponent;
  let fixture: ComponentFixture<RegistroPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegistroPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegistroPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
