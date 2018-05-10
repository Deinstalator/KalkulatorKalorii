import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Product } from '../models/product';
import { ProductsBackendService } from '../services/products-backend.service';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { retry } from 'rxjs/operator/retry';

@Injectable()
export class HttpProductsBackendService extends ProductsBackendService {
    private addProductUrl: string = "api/product/addproduct";
    private getProductUrl: string = "api/product/getproduct?productId=";
    private getPruductsUrl: string = "api/product/getproducts";
    private updateProductUrl: string = "api/product/updateproduct";
    private deleteProductUrl: string = "api/product/deleteproduct?productId=";

    private jsonContentOptions: RequestOptions;
    constructor(private http: Http) {
        super();
        let headersJson: Headers = new Headers({
            'Content-Type': 'application/json',
        });
        this.jsonContentOptions = new RequestOptions({ headers: headersJson })
    }

    addProduct(newProduct: Product): Observable<number> {
        return this.http.post(this.addProductUrl, JSON.stringify(newProduct), this.jsonContentOptions).
            map(response => response.json() as number);
    }
    getProduct(id: number): Observable<Product> {
        return this.http.get(this.getProductUrl + id, this.jsonContentOptions).map(response => response.json());
    }
    getProducts(): Observable<Product[]> {
        return this.http.get(this.getPruductsUrl, this.jsonContentOptions).map(response => response.json());
    }
    updateProduct(updateProduct: Product): Observable<number> {
        return this.http.post(this.updateProductUrl, JSON.stringify(updateProduct), this.jsonContentOptions).
            map(response => response.json() as number);
    }
    deleteProduct(productId: number): Observable<number> {
        return this.http.get(this.deleteProductUrl + productId, this.jsonContentOptions).map(response => response.json());
    }

}