use northwind;

-- Get column names example
select Column_name
from information_schema.columns
where table_name = 'employees';


-- 1a
print 'List all shippers';
select * from Shippers;

-- 1b
print 'List all shippers in asc order';
select * 
from Shippers 
order by CompanyName

-- 2a
print 'List all employee''s first name, last name, title, dob and city of resi';
select FirstName, LastName, Title, BirthDate, City
from Employees;

-- 2b
print 'List distinct title';
select distinct Title
from Employees;

-- 3
print 'List all orders from 19 May 1997';
select * 
from Orders
where OrderDate = '19 May 1997';

-- 4
print 'Retrieve details of all customers located in London or Madrid';
select * 
from Customers
where City in ('London', 'Madrid');


-- 5 
print 'List all number and name of customer located in UK';
select Phone, ContactName
from Customers
where Country = 'UK';

-- 6
print 'List orders made by customer ID Hanar';
select *
from Orders
where CustomerID = 'HANAR';

-- 7
print 'List full names ''Salutation +  FirstName +  LastName''';
select concat(TitleOfCourtesy, ' ', FirstName, ' ', LastName) as FullName
from Employees
order by LastName;

-- 8
print 'List all order number and date made by Customer Maison Dewey';
select OrderId, OrderDate
from Orders
where CustomerId in 
(
	select CustomerId 
	from Customers 
	where CompanyName = 'Maison Dewey'
);

-- 9
print 'List all details of products with ''lager'' in the name';
select *
from Products
where ProductName like '%lager%';

-- 10
print 'List all customer ids and contactname who have yet to order any products';
select CustomerId, ContactName
from Customers
where CustomerId not in 
(
	select CustomerId
	from Orders
);

-- 11
print 'Get average product price';
select avg(UnitPrice)
from Products;

-- 12
print 'List cities where customers reside in';
select distinct City
from Customers;

-- 13
print 'Count number of customers who have made orders';
select count(*)
from Customers
where CustomerId in
(
	select CustomerId
	from Orders
);

-- 14
print 'List company name and phone number without fax number';
select CompanyName, Phone
from Customers
where Fax is NULL;

-- 15
print 'Retrieve total sales made';
select convert(decimal(10,2), sum(UnitPrice * Quantity))
from [Order Details];

-- 16
print 'List order Ids made by ''Alan Out'' and ''Blone Coy''';
select OrderId 
from Orders
where CustomerId in 
(
	select CustomerID
	from Customers
	where CompanyName in ('Alan Out', 'Blone Coy')
);
-- 17
print 'List of customer id and number of orders made by customer';
select 
	c.CustomerId, 
	Count(o.OrderId) as OrderCount
from Customers c join Orders o
on c.CustomerId = o.CustomerId
group by c.CustomerId
order by OrderCount;

-- 18 
print 'Get Company name and all all order IDs of ''BONAP''';
select
	c.CompanyName,
	o.OrderId
from Customers c join Orders o
on c.CustomerId = o.CustomerId
where c.CustomerId = 'BONAP';

-- 19a
print 'Count orders made, IDs and Company Names of all customers that made more than 10 orders';
select o.CustomerId, c.CompanyName, o.OrderCount
from 
	Customers c 
left join 
	(select CustomerId, count(OrderId) as OrderCount
	from Orders 
	group by CustomerId) o
on c.CustomerId = o.CustomerId
where o.OrderCount > 10
order by OrderCount desc;

-- 19b
print 'Count orders made, retrieve ID and Company name of for customerId = ''BONAP''';
select o.CustomerId, c.CompanyName, o.OrderCount
from 
	Customers c 
left join 
	(select CustomerId, count(OrderId) as OrderCount
	from Orders 
	group by CustomerId) o
on c.CustomerId = o.CustomerId
where c.CustomerId = 'BONAP'
order by OrderCount desc;

-- 19c
print 'Count orders made, retrieve ID and company name of customers with more orders than ''BONAP''';
select o.CustomerId, c.CompanyName, o.OrderCount
from 
	Customers c 
left join 
(	
	select CustomerId, count(OrderId) as OrderCount
	from Orders 
	group by CustomerId
) o -- Get table with count of orders
on c.CustomerId = o.CustomerId
where o.OrderCount > 
	(	
		select count(OrderId)
		from Orders 
		where CustomerId = 'BONAP'
		group by CustomerId
	) -- Get count of orders from BONAP
order by OrderCount desc;

-- 20a
print 'Get product code and product names where categoryId = 1, 2';
select ProductId, ProductName 
from products
where CategoryId in ('1', '2')
order by ProductId, ProductName;

-- 20b
print 'Get product code and product names where CategoryName = Beverages, Condiments';
select ProductId, ProductName 
from products
where CategoryId in 
(
	select CategoryID 
	from categories 
	where CategoryName in ('Beverages', 'Condiments')
)
order by ProductId, ProductName;

-- 21a
print 'Get no of employees';
select count(EmployeeId) as NoOfEmployees
from Employees;

-- 21b
print 'Get no of employees in USA';
select count(EmployeeId) as NoOfEmployeesInUSA
from Employees
where Country = 'USA';

-- 22
print 'Retrieve orders administered by Sales Representative and shipped by United Package';
select o.* 
from Orders o
left join Employees e on o.EmployeeId = e.EmployeeId
left join Shippers s on o.ShipVia = s.ShipperId
where e.Title = 'Sales Representative' and s.CompanyName = 'United Package';

-- 23
print 'Retrieve names of employees and their manager';
select Concat(e.FirstName, ' ', e.LastName) as EmployeeName, Concat(m.FirstName, ' ', m.LastName)
from Employees e
left join Employees m on e.ReportsTo = m.EmployeeId;

-- 24
print 'Retrieve five most discounted products';
select top 5 ProductId ,sum(UnitPrice * Quantity * Discount) as TotalDiscount
from [Order Details]
group by ProductId
order by TotalDiscount desc;

-- 25
print 'Retrieve list of customers in areas with no suppliers';
select CompanyName 
from Customers 
where City not in 
(
	select distinct City
	from Suppliers
);

-- 26
print 'List all cities with customers and suppliers';
select distinct City
from Customers 
where City in 
(
	select distinct City
	from Suppliers
);

-- 27a
print 'Customers and Suppliers details';
select CompanyName, Address, Phone
from Customers
union
select CompanyName, Address, Phone 
from Suppliers
order by CompanyName;

-- 27b
print 'Combine Customers, Suppliers and Shippers details';
select CompanyName, Address, Phone, 1 as [type]
from Customers
union
select CompanyName, Address, Phone, 2 as [type]
from Suppliers
union
select CompanyName, null as Address, Phone, 3 as [type]
from Shippers
order by "type";

-- Q28
print 'Get name of manager for employee who handled order 10248';
select Concat(LastName, ' ', FirstName) as Name
from Employees
where EmployeeId = 
(
	select ReportsTo
	from Employees
	where EmployeeId = 
	(
		select EmployeeId
		from Orders
		where OrderId = 10248
	)
)
;

-- 29
print 'List products above average unit price';
select *
from Products
where UnitPrice >
(
	select avg(UnitPrice)
	from Products
)
;

-- 30
print 'List all orders above $10000';
select OrderId, sum(UnitPrice * Quantity) as TotalOrderPrice
from [Order Details]
group by OrderId
having sum(UnitPrice * Quantity) > 10000

-- 31
print 'List all orders id and customer id of orders above $10000';
select d.OrderId, o.CustomerId
from 
(
	select OrderId, sum(UnitPrice * Quantity) as TotalOrderPrice
	from [Order Details]
	group by OrderId
) d 
join Orders o on d.OrderID = o.OrderId
where TotalOrderPrice > 10000

-- 32
print 'List all orders id and customer id and name of orders above $10000';
select d.OrderId, o.CustomerId, c.CompanyName
from 
(
	select OrderId, sum(UnitPrice * Quantity) as TotalOrderPrice
	from [Order Details]
	group by OrderId
	having sum(UnitPrice * Quantity) > 10000
) d 
join Orders o on d.OrderID = o.OrderId
join Customers c on o.CustomerId = c.CustomerId;

-- 33
print 'Total price of all orders by customers';
select o.CustomerId, sum(o.UnitPrice * o.Quantity) as TotalPrice 
from 
(
	select d.OrderId, d.UnitPrice, d.Quantity, o.CustomerId
	from [Order Details] d
	join Orders o on d.OrderId = o.OrderId
) o
group by o.CustomerId;

-- 34
print 'Average value of all orders by customers';
select avg(a.TotalPrice) as AvgOrderValueByCustomer
from 
(
	select o.CustomerId, sum(o.UnitPrice * o.Quantity) as TotalPrice 
	from 
	(
		select d.OrderId, d.UnitPrice, d.Quantity, o.CustomerId
		from [Order Details] d
		join Orders o on d.OrderId = o.OrderId
	) o
	group by o.CustomerId
) a;

-- 35
print 'List customer id and name with total order value more than average';

select o.CustomerId, c.CompanyName, sum(d.UnitPrice * d.Quantity) as TotalCustValue
from [Order Details] d
join Orders o on o.OrderId = d.OrderId
join Customers c on o.CustomerId = c.CustomerId
group by o.CustomerId, c.CompanyName
having sum(d.UnitPrice * d.Quantity) > 
(
	select avg(x.TotalCustValue)
	from
	(
		select sum(d.UnitPrice * d.Quantity) as TotalCustValue
		from [Order Details] d
		join Orders o on o.OrderId = d.OrderId
		group by o.CustomerId
	) x
)

-- 36
print 'List customer id and total order value of each customer in 1997';
select o.CustomerId, sum(o.UnitPrice * o.Quantity) as TotalPrice 
from 
(
	select d.OrderId, d.UnitPrice, d.Quantity, o.CustomerId
	from [Order Details] d
	join Orders o on d.OrderId = o.OrderId
	where year(OrderDate) = 1997
) o
group by o.CustomerId
