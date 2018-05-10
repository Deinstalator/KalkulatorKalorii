import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable()
export abstract class ProductsBackendService {
    abstract addProduct(newProduct: Product): Observable<number>;

    abstract getProduct(id: number): Observable<Product>;

    abstract getProducts(): Observable<Product[]>;

    abstract updateProduct(updatedProduct: Product): Observable<number>;

    abstract deleteProduct(productId: number): Observable<number>;
}