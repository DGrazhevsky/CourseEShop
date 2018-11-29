UPDATE EShop.dbo.Products
SET Image = (SELECT BulkColumn 
FROM Openrowset( Bulk 'C:\Users\dimag\Desktop\WineS\WineS\Images\p5.jpg', Single_Blob) as img)
WHERE id = 5;