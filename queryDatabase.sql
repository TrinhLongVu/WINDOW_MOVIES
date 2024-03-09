use master;
go
drop database if exists Movie;
go
create database Movie;
go
use Movie

create table Star(
	Id varchar(100),
	Name varchar(100),
	Image varchar(500),
	Story varchar(500)
	primary key (Id)
)

create table MovieStar(
	MovieId varchar(100),
	StarId varchar(100),
	primary key (MovieId, StarId)
)

create table Movie (
	Id varchar(100),
    IdGener varchar(100),
    Name varchar(100),
    Release varchar(100),
    Rating varchar(100),
    Poster varchar(500),
    Certification varchar(100),
	Detail varchar(100)
	primary key (Id)
)

create table MovieDirector(
	MovieId varchar(100),
	DirectorId varchar(100),
	primary key (MovieId, DirectorId)
)

create table Genre (
	Id varchar(100),
	Name varchar(100)
	primary key (Id)
)

create table Director (
	Id varchar(100),
    Name varchar(100),
    Image varchar(500),
    Story varchar(500)
	primary key (Id)
)

create table Schedule (
	Id varchar(100),
	Time varchar(100),
	primary key (Id)
)

create table MovieSchedule(
	IdSchedule varchar(100),
	IdMovie varchar(100)
	primary key (IdSchedule, IdMovie)
)

go

alter table MovieStar
add constraint FK_MVSTAR_STAR foreign key (StarId) references Star (Id),
    constraint FK_MVSTAR_MV   foreign key (MovieId) references Movie(Id)

alter table MovieDirector
add constraint FK_MVDIRECTOR_MV foreign key (MovieId) references Movie(Id),
	constraint FK_MVDIRECTOR_DIRECTOR foreign key (DirectorId) references Director(Id)

alter table MovieSchedule
add constraint FK_MVSCHEDULE_MV foreign key (IdSchedule) references Movie(Id),
	constraint FK_MVSCHEDULE_SCHEDULE foreign key (IdMovie) references Schedule(Id)

alter table Movie 
add constraint FK_GENRE foreign key (IdGener) references Genre(Id)
