use DBMS

--Optimistic Isolation Level

ALTER DATABASE DBMS SET ALLOW_SNAPSHOT_ISOLATION ON
/* Solution: */
--ALTER DATABASE DBMS SET ALLOW_SNAPSHOT_ISOLATION OFF

--T1
begin tran
update Teams set [name] ='Alpine F1' where id = 3
waitfor delay '00:00:10'
commit tran

--T2
set transaction isolation level snapshot
begin tran
select * from Teams where id = 3
waitfor delay '00:00:03'
select * from Teams
update Teams set [name] ='Alpine F1 Team' where id = 3
commit tran