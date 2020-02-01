MERGE [ProductInventory] AS [P]
USING 
(
	VALUES 
		(1,'table',29.99, 4),
		(2,'chair',9.99, 7),
		(3,'couch',50, 2),
		(4,'pillow',5, 1),
		(5,'bed',225.00, 1),
		(6,'bench',29.99, 3),
		(7,'stool',19.99, 5)

)

AS [S] ([ProductID],[ProductName],[Price], [InventoryQuantity])

ON [P].[ProductID]= [S].[ProductID]

WHEN MATCHED  THEN
	UPDATE SET 
	[ProductName] = [S].[ProductName],
	[Price] = [S].[Price],
	[InventoryQuantity] = [S].[InventoryQuantity]
	

WHEN NOT MATCHED THEN
	INSERT ([ProductID],[ProductName],[Price], [InventoryQuantity])
	VALUES ([S].[ProductID],[S].[ProductName],[S].[Price], [S].[InventoryQuantity])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;