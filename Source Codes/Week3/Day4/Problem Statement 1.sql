/*Level-1: Problem 1 – Product Analysis Using Nested Queries

Scenario:
You are working as a database developer for an automobile retail company. Management wants to identify products that are priced higher than the average price of products in their respective categories.

Requirements
1. Retrieve product details (product_name, model_year, list_price).
2. Compare each product’s price with the average price of products in the same category using a nested query.
3. Display only those products whose price is greater than the category average.
4. Show calculated difference between product price and category average.
5. Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').

️ Technical Constraints
• Use subquery in WHERE clause.
• Use aggregate function (AVG).
• Use string manipulation functions.
• Use arithmetic expressions for price difference calculation.

Expectations:
• Proper use of nested query.
• Correct calculation of average and difference.
• Clean and readable SQL query.

Learning Outcome
• Understand nested queries with aggregate functions.
• Perform calculations inside SELECT statement.
• Apply string concatenation in SQL.*/


SELECT
CONCAT(products.product_name, ' (', products.model_year, ')') AS product_details,
    products.product_name,
    products.model_year,
    products.list_price,
    (products.list_price - 
        (SELECT AVG(products.list_price)
         FROM products
         WHERE products.category_id = products.category_id)
    ) AS price_difference
FROM products
WHERE products.list_price >
      (SELECT AVG(products.list_price)
       FROM products
       WHERE products.category_id = products.category_id);


SELECT
CONCAT(p.product_name, ' (', p.model_year, ')') AS product_details,
    p.product_name,
    p.model_year,
    p.list_price,
    (p.list_price - 
        (SELECT AVG(p2.list_price)
         FROM products p2
         WHERE p2.category_id = p.category_id)
    ) AS price_difference
FROM products p
WHERE p.list_price >
      (SELECT AVG(p3.list_price)
       FROM products p3
       WHERE p3.category_id = p.category_id);