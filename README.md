To create a product, the database has a lot of restrictions to consider, so you can use this JSON to create one:
{
  "name": "Name",
  "productNumber": "AR-538170",
  "makeFlag": true,
  "finishedGoodsFlag": true,
  "color": "Blue",
  "safetyStockLevel": 500,
  "reorderPoint": 375,
  "standardCost": 0.00,
  "listPrice": 0.00,
  "size": "60",
  "sizeUnitMeasureCode": "CM",
  "weightUnitMeasureCode": "LB",
  "weight": 25.13,
  "daysToManufacture": 4,
  "productLine": "R",
  "class": "M",
  "style": "U",
  "productSubcategoryID": 2,
  "productModelID": 28,
  "sellStartDate": "2024-04-10T01:08:45.784Z",
  "sellEndDate": "2024-04-10T01:08:45.784Z",
  "discontinuedDate": "2024-04-10T01:08:45.784Z"
}

To update it, you can use the same one, but the put method requires the id of the product at the beggining.

To create a sales order header, you will also have to consider some restrictions in the database, so you can use this JSON to try the POST method:
{
  "revisionNumber": 8,
  "orderDate": "2024-04-10T04:44:35.180Z",
  "dueDate": "2024-04-10T04:44:35.180Z",
  "shipDate": "2024-04-10T04:44:35.180Z",
  "status": 5,
  "onlineOrderFlag": true,
  "purchaseOrderNumber": "PO19430112391",
  "accountNumber": "10-4020-000336",
  "customerID": 29493,
  "salesPersonID": 279,
  "territoryID": 8,
  "billToAddressID": 970,
  "shipToAddressID": 504,
  "shipMethodID": 5,
  "creditCardID": 4842,
  "creditCardApprovalCode": "68035Vi92659",
  "currencyRateID": 409,
  "subTotal": 300,
  "taxAmt": 12,
  "freight": 3
}


If you want to delete a record in any table, you should delete a record that is not associated with any other table. Therefore, it is ideal to delete a recently created record.

The PUT method on SalesOrderHeader cannot be performed due to triggers in the database that prevent it, instead I create the Delete method.
