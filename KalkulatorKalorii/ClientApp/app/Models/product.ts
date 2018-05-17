export class Product {
    constructor();
    constructor(
        public id?: number,
        public description?: string,
        public producer?: string,
        public calories?: number,
        public productTypeId?: number,
        public macronutrientId?: number
    ) { };
}