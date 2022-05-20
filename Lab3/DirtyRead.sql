use DBMS

--Dirty read

select * from Teams

--T1
begin tran
update Teams set [name]='Alpine F1' where [name] = 'Alpine'
waitfor delay '00:00:10'
rollback tran

--T2
/*solution: */
--set transaction isolation level read committed 
set transaction isolation level read uncommitted
begin tran
select * from Teams
waitfor delay '00:00:05'
select * from Teams
commit tran