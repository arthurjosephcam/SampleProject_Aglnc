export namespace Agilence
{
  export class ProductInventory
  {
    public productId: number;
    public productName: string;
    public inventoryQuantity: number;
    public price: number;
  }

  export enum SortType
  {
    Name=1,
    Price=2,
    Quantity=3
  }
}
