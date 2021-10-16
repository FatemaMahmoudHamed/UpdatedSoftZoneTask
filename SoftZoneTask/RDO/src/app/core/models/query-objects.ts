
export class QueryObject {
  sortBy?: string = 'name';
  isSortAscending?: boolean = true;
  page: number = 1;
  pageSize: number = 5;
  public constructor(init?: Partial<QueryObject>) {
    Object.assign(this, init);
  }
}
export class QueryResult {
  totalItems: number = 0;
  items: any[] = [];
}

export class RestaurantQueryObject extends QueryObject {
  public constructor(init?: Partial<RestaurantQueryObject>) {
    super(init);
    Object.assign(this, init);
  }
  name?: string;
  description?:number;
}

export class ProductQueryObject extends QueryObject {
  public constructor(init?: Partial<ProductQueryObject>) {
    super(init);
    Object.assign(this, init);
  }
  name?: string;
  description?:number;
}


