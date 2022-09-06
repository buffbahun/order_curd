import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { OderEditComponent } from './oder-edit/oder-edit.component';
import { UpdateOrderService } from './services/update-order.service';
import { OderListComponent } from './oder-list/oder-list.component';
import { UnitComponent } from './unit/unit.component';
import { ItemComponent } from './item/item.component';


@NgModule({
  declarations: [
    AppComponent,
    OderEditComponent,
    OderListComponent,
    UnitComponent,
    ItemComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      
    ])
  ],
  providers: [UpdateOrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
