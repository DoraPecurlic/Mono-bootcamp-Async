SELECT 
    u."FirstName", 
    u."LastName", 
    o."FlowerType", 
    o."Quantity", 
    ot."OrderType"
FROM 
    "Order" o
INNER JOIN 
    "User" u ON o."UserId" = u."Id"
INNER JOIN 
    "OrderType" ot ON o."OrderTypeId" = ot."Id";
