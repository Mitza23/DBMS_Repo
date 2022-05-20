use DBMS

create table Teams (
	id int primary key identity,
	[name] varchar(50)
)

create table Races (
	id int primary key identity,
	[name] varchar(50),
	laps int
)

create table Participations (
	id int primary key identity,
	team_id int foreign key references Teams(id),
	race_id int foreign key references Races(id)
)


insert into Teams(name) values
('Scuderia Ferrari'),
('Mercedes AMG'),
('Alpine'),
('Aston Martin'),
('Red Bull Racing')

insert into Races(name, laps) values
('Monaco GP', 65),
('Styrian GP', 70),
('Grand Premio del Emiglia Romagna', 56),
('Grand Premio del Monza', 62)


create function validateLaps(@laps int) returns int as
begin
	declare @return int
	set @return = 0
	if(@laps > 50 and @laps < 80)
		set @return = 1
	return @return
end

create function validateTeamName(@name varchar(50)) returns int as
begin
	declare @return int
	set @return = 0
	if(LEN(@name) > 4 or LEN(@name) <= 50)
		set @return = 1
	return @return
end

/* setup */


/*grade: 3*/

create procedure addTeamAndRace @teamName varchar(50), @raceName varchar(50), @laps int as 
begin
	begin tran
	begin try
		declare @teamId int, @raceId int
		if(dbo.validateTeamName(@teamName) <>1)
		begin
			raiserror('Team name must be between 4 and 50 chars', 14, 1)
		end
		insert into Teams(name) values(@name)
		set @teamId = @@IDENTITY
		if(dbo.validateLaps(@name) <>1)
		begin
			raiserror('Race must have between 50 and 80 laps', 14, 1)
		end
		insert into Races(name, laps) values(@name, @laps)
		set @raceId = @@IDENTITY
		insert into Participations(team_id, race_id) values(@teamId, @raceId)
		commit tran
		select 'COMMITTED'
	end try

	begin catch
		rollback tran
		select 'ROLLBACK'
	end catch

end


/* grade 5*/

create procedure addTeam @name varchar(50) as
begin
	begin tran
	begin try
		if(dbo.validateTeamName(@name) <>1)
		begin
			raiserror('Team name must be between 4 and 50 chars', 14, 1)
		end
		insert into Teams(name) values(@name)
		commit tran
		select 'SUCCESS'
		return @@IDENTITY
	end try

	begin catch
		rollback tran
		select 'ROLLBACK'
		return -1
	end catch
end

create procedure addRace @name varchar(50), @laps int as
begin
	begin tran
	begin try
		if(dbo.validateLaps(@name) <>1)
		begin
			raiserror('Race must have between 50 and 80 laps', 14, 1)
		end
		insert into Races(name, laps) values(@name, @laps)
		commit tran
		select 'SUCCESS'
		return @@IDENTITY
	end try

	begin catch
		rollback tran
		select 'ROLLBACK'
		return -1
	end catch
end

create procedure addParticipation @teamId int, @raceId int as
begin
	begin tran
	insert into Participations(team_id, race_id) values (@teamId, @raceId)
	commit tran
end


create procedure addAll @teamName varchar(50), @raceName varchar(50), @laps int as
begin
	begin tran
	declare @teamId int, @raceId int
	exec @teamId= dbo.addTeam @teamName
	exec @raceId = dbo.addRace @raceName, @laps

	if(@raceId < 0 or @teamId < 0)
	begin
		select 'Error adding race or team'
		return -1
	end
	
	exec dbo.addParticipation @teamId, @raceId

end


/* Dirty Reads */
--T2
set transaction isolation level read uncommitted
begin tran
    select * from Teams
    waitfor delay '00:00:05'
    select * from Teams
commit tran

/* Unrepeatable Reads */
--T2
set transaction isolation level read committed
begin tran
select * from Teams
waitfor delay '00:00:05'
select * from Teams
commit tran

/*Phantom Reads */
--T2
/*solution: */
--set transaction isolation level serializable 
set transaction isolation level repeatable read
begin tran
select * from Teams
waitfor delay '00:00:05'
select * from Teams
commit tran


/* Deadlock */

--T2
/*solution: */
--set deadlock_priority high 
set transaction isolation level serializable
begin tran
update Races set [laps]=66 where [name] = 'Monaco GP'
waitfor delay '00:00:05'
update Teams set [name]='Alpine F1' where [name] = 'Alpine'
commit tran

use DBMS

ALTER DATABASE DBMS SET ALLOW_SNAPSHOT_ISOLATION ON

/* Optimistic Isolation Level */

--T2
set transaction isolation level snapshot
begin tran
select * from Teams where id = 3
waitfor delay '00:00:03'
select * from Teams
update Teams set [name] ='Alpine F1 Team' where id = 3
commit tran