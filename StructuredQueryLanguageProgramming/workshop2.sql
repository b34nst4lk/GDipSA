use dafesty;

print 'Cleaning up'
drop table GoodCustomers;
drop table MemberCategories;

-- 1
print 'Create Member Catergories table';
create table MemberCategories
(
	MemberCategory		nvarchar(2)	not null,
	MemberCatDescription 	nvarchar(200)	not null,
	Primary Key (MemberCategory)
)

-- 2
print 'Insert rows';
insert into MemberCategories 
(MemberCategory, MemberCatDescription)
values
('A',	'Class A Members'),
('B',	'Class B Members'),
('C',	'Class C Members');

-- Check if MemberCategories table successfully created
select * from MemberCategories;

-- 3
print 'Create GoodCustomers table';
create table GoodCustomers
(
	CustomerName		nvarchar(50)	not null,
	Address		 	nvarchar(65),
	PhoneNumber		nvarchar(9)	not null,
	MemberCategory	 	nvarchar(2),
	Primary Key (CustomerName, PhoneNumber),
	Foreign Key (MemberCategory) References MemberCategories (MemberCategory)
)

-- 4
print 'Insert GoodCustomers table with data from Customers Table';
insert into GoodCustomers
(CustomerName, Address, PhoneNumber, MemberCategory)
select CustomerName, null as Address, PhoneNumber, MemberCategory
from Customers
where MemberCategory in ('A', 'B');

-- Check if GoodCustomers table properly created
select * from GoodCustomers;

-- 5
print 'Insert a new row into GoodCustomers';
insert into GoodCustomers
(CustomerName, PhoneNumber, MemberCategory)
values
('Tracy Tan', '736572', 'B');

-- Check if new record inserted correctly
select * from GoodCustomers where CustomerName = 'Tracy Tan';

-- 6 
print 'Insert a new row into GoodCustomers';
insert into GoodCustomers
values
('Grace Leong', '15 Bukit Purmei Road, Singapore 0904', '278865', 'A');

-- Check if new record inserted correctly
select * from GoodCustomers where CustomerName = 'Grace Leong';

-- 7
print 'Attempt to insert a MemberCategory that does not exist';
insert into GoodCustomers
values
('Lynn Lim', '15 Bukit Purmei Road, Singapore 0904', '278865', 'P');

-- Check if new record inserted correctly
select * from GoodCustomers where CustomerName = 'Lynn Lim';

-- 8
print 'Update address of Grace Leong'
update GoodCustomers
set Address = '22 Bukit Purmei Road, Singapore 0904'
where CustomerName = 'Grace Leong' and PhoneNumber = '278865';

-- Check if record updated correctly
select * from GoodCustomers where CustomerName = 'Grace Leong';

-- 9 
-- Check before update
select * from GoodCustomers where CustomerName = 
(
	select CustomerName
	from Customers
	where CustomerId = '5108'
)
and PhoneNumber = 
(
	select PhoneNumber
	from Customers
	where CustomerId = '5108'
)

print 'Update CustomerId of CustomerID 5108';
update GoodCustomers
set MemberCategory = 'B'
where CustomerName = 
(
	select CustomerName
	from Customers
	where CustomerId = '5108'
)
and PhoneNumber = 
(
	select PhoneNumber
	from Customers
	where CustomerId = '5108'
)

-- Check if record updated correctly
select * from GoodCustomers where CustomerName = 
(
	select CustomerName
	from Customers
	where CustomerId = '5108'
)
and PhoneNumber = 
(
	select PhoneNumber
	from Customers
	where CustomerId = '5108'
)

-- 10 
print 'Delete row from GoodCustomers';
delete from GoodCustomers
where CustomerName = 'Grace Leong' and PhoneNumber = '278865';

-- Check if record deleted correctly
select * from GoodCustomers where CustomerName = 'Grace Leong';

-- 11
print 'Remove Customers with MemberCategory B';
delete from GoodCustomers
where MemberCategory = 'B';

-- Check if record deleted correctly
select * from GoodCustomers;

-- 12
print 'Add new FaxNo variable to GoodCustomers';
alter table GoodCustomers
add FaxNo nvarchar(25);

update GoodCustomers
set FaxNo = c.FaxNumber
from Customers c 
join GoodCustomers g
on c.CustomerName = g.CustomerName
and c.PhoneNumber = g.PhoneNumber;

-- Check if new column added correctly
select top 10 * from GoodCustomers;

-- 13
print 'Change width of address column';
alter table GoodCustomers
alter column Address nvarchar(80);

-- Check if address column updated correctly
select top 1 * from GoodCustomers;

-- 14
print 'Add new ICNumber variable to GoodCustomers';
alter table GoodCustomers
add ICNumber nvarchar(10);

-- Check if new column added correctly
select top 1 * from GoodCustomers;

-- 15
print 'Attempt to create unique index using ICNumber column';
-- create unique index ICNumber_idx on GoodCustomers (ICNumber);

-- fail due to duplicate key value

-- 16
print 'Create Index using FaxNo';
create index FaxNo_idx on GoodCustomers (FaxNo);

-- 17
print 'Drop FaxNo index';
drop index FaxNo_idx on GoodCustomers;

-- 18
print 'Drop FaxNo column';
alter table GoodCustomers
drop column FaxNo;

-- check if FaxNo column successfully dropped
select top 1 * from GoodCustomers;

-- 19
print 'Drop all rows in GoodCustomers';
delete from GoodCustomers;

-- check if all rows successfully dropped
select * from GoodCustomers;

-- 20
print 'Cleaning up'
drop table GoodCustomers;
drop table MemberCategories;
