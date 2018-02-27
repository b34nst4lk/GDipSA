use northwind;
-- Clean up
drop view Customer1998;
drop view TotalBusiness
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

-- Clean up
drop view Customer1998;
drop view TotalBusiness
