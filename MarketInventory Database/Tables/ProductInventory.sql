CREATE TABLE [dbo].[ProductInventory]
(
	[ProductID] INT NOT NULL PRIMARY KEY, 
    [ProductName] NVarCHAR(250) NOT NULL, 
    [Price] MONEY NOT NULL DEFAULT 0.00, 
    [InventoryQuantity] INT NOT NULL DEFAULT 0
)
