import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaPaginaComponent } from './lista-pagina.component';

describe('ListaPaginaComponent', () => {
  let component: ListaPaginaComponent;
  let fixture: ComponentFixture<ListaPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListaPaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListaPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
