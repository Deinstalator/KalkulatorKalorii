import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product';
import { ProductsService } from '../services/products.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Location } from '@angular/common';
import 'rxjs/add/operator/switchMap';

@Component({
    templateUrl: './product-details.component.html'
})

export class ProductDetailsComponent implements OnInit {
    constructor(
        private productsService: ProductsService,
        private activatedRoute: ActivatedRoute,
        private location: Location
    ) { };

    pageTitle: string;
    urlParam: number;
    isInEditMode: boolean = true;
    product: Product = new Product();

    ngOnInit(): void {
        this.detectUrlParam();

        if (this.location.isCurrentPathEqualTo("/products/new-product")) {
            this.pageTitle = "Nowy produkt";
        }
        else if (this.location.isCurrentPathEqualTo("/products/product-update" + this.urlParam)) {
            this.pageTitle = "Aktualizacja produktu";
            this.downloadProduct();
        }
        else {
            this.pageTitle = "Szczegóły produktu";
            this.isInEditMode = false;
            this.downloadProduct();
        }
    }

    downloadProduct(): void {
        this.productsService.getProduct(this.urlParam).subscribe(
            productFromDb => this.product = productFromDb,
            errorObj => console.log(errorObj)
        );
    }

    onSubmit(propObj: Product): void {
        if (this.location.isCurrentPathEqualTo("/products/new-product")) {
            propObj.productTypeId = 1;
            propObj.macronutrientId = 1;
            this.productsService.addProduct(propObj).subscribe(
                onSuccess => console.log(onSuccess),
                onError => console.log(onError)
            )
        }
        else {
            this.productsService.updateProduct(propObj).subscribe(
                onSuccess => console.log(onSuccess),
                onError => console.log(onError)
            )
        }
    }

    detectUrlParam(): void {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.urlParam = params['id'];
        });
    }

    goBack(): void {
        this.location.back();
    }
}