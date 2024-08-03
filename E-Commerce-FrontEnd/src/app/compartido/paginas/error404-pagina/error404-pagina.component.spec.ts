import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Error404PaginaComponent } from './error404-pagina.component';

describe('Error404PaginaComponent', () => {
  let component: Error404PaginaComponent;
  let fixture: ComponentFixture<Error404PaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Error404PaginaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(Error404PaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
