import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product';
import { ProductsService } from '../services/products.service';
import { Router } from '@angular/router';

@Component({
    templateUrl: './products.component.html'
})

export class ProductsComponent implements OnInit {
    constructor(
        private productsService: ProductsService,
        private router: Router
    ) { };

    products: Array<Product> = new Array<Product>();
    pateTitle: string = "Lista dostępnych produktów";
    tempInfo: string = "Loading...";

    testowaZmienna = "Pozdrowienia z komponentu";

    ngOnInit(): void {
        this.downloadProducts();
        );
    }

    downloadProducts(): void {
        this.productsService.getProducts().subscribe(
            productsFromDb => {
                if (productsFromDb.length == 0) {
                    this.tempInfo = "Records not found";
                }
                else {
                    this.products = productsFromDb;
                }
            },
            error => console.log(error)
        )
    }
}