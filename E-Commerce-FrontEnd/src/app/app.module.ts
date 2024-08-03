import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompartidoModule } from './compartido/compartido.module';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
      AppComponent
    ],
    imports: [
      BrowserModule,
      HttpClientModule,

      // Mis modulos
      CompartidoModule,







      
      AppRoutingModule,
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
