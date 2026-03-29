CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products WHERE ProductId = @ProductId;
END


select * from Products;