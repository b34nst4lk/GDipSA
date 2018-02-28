use northwind;
-- Clean up
drop view Customer1998;
drop view TotalBusiness;
drop table testProducts;
drop table testCategories;
drop view testCategoryView;
drop view testCatProductView;
-- 1
go
create view Customer1998 as
	select distinct c.CustomerId, c.CompanyName, d.ProductId, p.ProductName
	from [Order Details] d
	join Products p
		on d.ProductId = p.ProductId
	join Orders o 
		on d.OrderId = o.OrderId
	join Customers c
		on o.CustomerId = c.CustomerId
	where year(o.OrderDate) = 1998;
go

-- Test views
print 'Test Customer1998 view';
select * from Customer1998;

-- 2
print 'Using Customer1998, extract CustomerName, ProductID and SupplierNames of Customers who made orders in 1998';
select distinct c.CompanyName as CustomerName, c.ProductName, s.CompanyName as SupplierName
from Customer1998 c
join Orders o
	on c.CustomerId = o.CustomerId
join Products p
	on c.ProductId = p.ProductId
join Suppliers s
	on p.SupplierId = s.SupplierId
where year(OrderDate) = 1998;

-- 3
print 'Using Customer1998, extract CustomerName and number of products ordered in 1998';
select CompanyName, count(distinct ProductId)
from Customer1998
group by CompanyName;

-- 4a
print 'Create view with Customer Name and Total business (Sum of all products * quantity)';
go
create view TotalBusiness as 
	select b.CustomerId, c.CompanyName, b.TotalBusiness
	from Customers c
	join 
	(
		select o.CustomerId, sum(d.UnitPrice * d.Quantity) as TotalBusiness
		from Orders o
		join [Order Details] d
			on o.Orderid = d.OrderId
		group by o.CustomerId
	) b	
		on b.CustomerId = c.CustomerId;
go

-- Test TotalBusiness view
select * 
from TotalBusiness 
order by CustomerId;

-- 4b
print 'Using TotalBusiness view, get average business by customers';
select avg(TotalBusiness) as AvgBusiness
from TotalBusiness

---------------------------------------------------------------
-- Experiment on updating a user view which joins two tables --
---------------------------------------------------------------
--- Create two duplicate tables
go
Create table testCategories
(
	CategoryId	int		not null,
	CategoryName	nvarchar(50)	not null,
	primary key (CategoryId)
)
go
Create table testProducts
(
	ProductId	int		not null,
	ProductName	nvarchar(40) 	not null,
	CategoryID	int		null,
	primary key (ProductId),
	foreign key (CategoryId) references testCategories (CategoryId) on update cascade
)
go

--- Insert rows into tables
insert into testCategories
	select CategoryId, CategoryName from Categories;
insert into testProducts
	select ProductId, ProductName, CategoryId from Products;

--- Test to see that tables are successfully created
select * from testProducts;
select * from testCategories;

--- Create view with only one table
go
create view testCategoryView as
	select * from testCategories;
go

--- Test view
select * from testCategoryView;

--- #Experiment 1: Test updating of view created from one table
update testCategoryView
	set CategoryId = 20
	where categoryId = 8;

--- see results of updates
select * from testCategoryView;
select * from testCategories;
select * from testProducts where CategoryId = 20;

--- create view by joining 2 tables
go
create view testCatProductView as
	select c.CategoryId, c.CategoryName, p.ProductName
	from testCategories c, testProducts p
	where c.CategoryId = p.CategoryId;
go

select * from testCatProductView;

--- #Experiment 2: Test updating of view created from joining two tables
update testCatProductView
set CategoryId = 10, CategoryName = 'Sea food', ProductName = 'Rotten Seafood'
where CategoryId = 20;

--- see results of updates

select * from testCatProductView;

-- Clean up
drop view Customer1998;
drop view TotalBusiness;
drop view TestCategory;
drop table testProducts;
drop table testCategories;
drop view testCategoryView;
drop view testCatProductView;
