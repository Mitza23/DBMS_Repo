use DBMS

--Phantom read

delete from Teams where [name] = 'Haas F1'
select * from Teams

--T1
begin tran
insert into Teams(name) values ('Haas F1')
commit tran

--T2
/*solution: */
--set transaction isolation level read committed 
set transaction isolation level repeatable read
begin tran
select * from Teams
waitfor delay '00:00:05'
select * from Teams
commit tran