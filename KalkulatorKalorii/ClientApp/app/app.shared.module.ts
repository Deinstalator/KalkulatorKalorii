import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

//***Products Section***\\
import { ProductsComponent } from './components/products/components/products.component';
import { ProductsService } from './components/products/services/products.service';
import { ProductsBackendService } from './services/products-backend.service';
import { HttpProductsBackendService } from './services/http-products-backend.services';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ProductsComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'products', component: ProductsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        ProductsService,
        { provide: ProductsBackendService, useClass: HttpProductsBackendService }
    ]
})
export class AppModuleShared {
}
