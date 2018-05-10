import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Product } from '../../../models/product';
import { ProductsBackendService } from '../../../services/products-backend.service';

@Injectable()
export class ProductsService {
    constructor(private productsBackendService: ProductsBackendService) { }

    addProduct(newProduct: Product): Observable<number> {
        return this.productsBackendService.addProduct(newProduct);
    }

    getProduct(productId: number): Observable<Product> {
        return this.productsBackendService.getProduct(productId);
    }

    getProducts(): Observable<Product[]> {
        return this.productsBackendService.getProducts();
    }

    updateProduct(updatedProduct: Product): Observable<Product> {
        return this.updateProduct(updatedProduct);
    }

    deleteProduct(productId: number): Observable<number> {
        return this.productsBackendService.deleteProduct(productId);
    }
}