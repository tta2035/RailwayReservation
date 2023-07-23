import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { ComponentsModule } from './admin/components/components.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './admin/admin.component';
import { PassengersModule } from './passengers/passengers.module';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    PassengersModule
  ],
  declarations: [
    AppComponent,
    AdminComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
