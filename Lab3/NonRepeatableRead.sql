use DBMS

update Teams set [name]='Alpine' where [name] = 'Alpine F1'
select * from Teams
--T1
begin tran
update Teams set [name]='Alpine F1' where [name] = 'Alpine'
commit tran

--T2
/*solution: */
--set transaction isolation level repeatable read 
set transaction isolation level read committed 
begin tran
select * from Teams
waitfor delay '00:00:05'
select * from Teams
commit tran