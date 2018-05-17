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

    ngOnInit(): void {
        this.downloadProducts();
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

    getProduct(id: number): void {
        this.router.navigate(['./products/product-details', id]);
    }

    updateProduct(id: number): void {
        this.router.navigate(['./products/product-update', id]);
    }

    deleteProduct(id: number): void {
        this.productsService.deleteProduct(id).subscribe(
            onSuccess => {
                console.log(onSuccess);
                this.products.splice(this.products.findIndex(prop => prop.id == id), 1)
            },
            onError => console.log(onError)
        );
        
    }
}