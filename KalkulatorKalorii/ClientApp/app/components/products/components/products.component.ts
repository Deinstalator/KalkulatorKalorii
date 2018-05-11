import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product';
import { ProductsService } from '../services/products.service';

@Component({
    templateUrl: './products.component.html'
})

export class ProductsComponent implements OnInit {
    constructor(private productsService: ProductsService) { };

    testowaZmienna = "Pozdrowienia z komponentu";

    ngOnInit(): void {
        this.productsService.getProducts().subscribe(
            props => { console.log("Products", props) },
            error => { console.log("Error", error) }
        );
    }
}