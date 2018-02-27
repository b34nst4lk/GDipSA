use dafesty;

-- 1
print 'Create procedure listing customers of member category A';
go
create procedure PMemberA as
	select CustomerId, CustomerName
	from Customers
	where MemberCategory = 'A'
go

exec PMemberA;

-- 2
print 'Create procedure listing customers of chosen member category';
go
create procedure PMember(@memCat nvarchar(2))as
	print 'Customers with MemberCategory: ' + @memCat;
	select CustomerId, CustomerName
	from Customers
	where MemberCategory = @memCat
go

exec PMember 'B';
exec PMember @memCat='B';
exec PMember @memCat='Z';

drop procedure PMemberA;
drop procedure PMember;
