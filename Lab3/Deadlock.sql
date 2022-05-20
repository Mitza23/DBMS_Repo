use DBMS

--Deadlock

delete from Teams where [name] = 'Haas F1'
select * from Teams

--T1
set transaction isolation level serializable
begin tran
update Teams set [name]='Alpine F1' where [name] = 'Alpine'
waitfor delay '00:00:05'
update Races set [laps]=66 where [name] = 'Monaco GP'
commit tran

--T2
/*solution: */
--set deadlock_priority high 
set transaction isolation level serializable
begin tran
update Races set [laps]=66 where [name] = 'Monaco GP'
waitfor delay '00:00:05'
update Teams set [name]='Alpine F1' where [name] = 'Alpine'
commit tran