use master
go
drop database if exists Movie;
go
create database Movie;
go
use Movie
go

create table Star(
	Id INT IDENTITY(1, 1),
	Name varchar(100),
	Image varchar(500),
	Story varchar(1000)
	primary key (Id)
)

create table Movie (
	Id INT IDENTITY(1, 1),
    IdGener INT,
    Title varchar(100),
    Runtime varchar(100),
    Rating float,
    Poster varchar(500),
	Landscape varchar(500),
    Certification varchar(100),
	Release varchar(100),
	Detail varchar(500)
	primary key (Id)
)

create table MovieStar(
	MovieId INT,
	StarId int,
	primary key (MovieId, StarId)
)

create table MovieDirector(
	MovieId int,
	DirectorId int,
	primary key (MovieId, DirectorId)
)

create table Genre (
	Id INT IDENTITY(1, 1),
	Name varchar(100)
	primary key (Id)
)

create table Director (
	Id INT IDENTITY(1, 1),
    Name varchar(100),
    Image varchar(500),
    Story varchar(500)
	primary key (Id)
)

create table Schedule (
	Id INT IDENTITY(1, 1),
	Time varchar(100) unique,
	primary key (Id)
);

insert into Schedule(Time) values
('08:00:00'),
('10:15:00'),
('13:30:00'),
('15:45:00'),
('18:00:00'),
('20:15:00'),
('22:15:00')

go

create table MovieSchedule(
	Id INT IDENTITY(1, 1),
	IdSchedule INT,
	IdMovie INT,
    Date Date,
	primary key (Id),
    unique (IdSchedule, Date)
)

create table Account(
	Id INT IDENTITY(1, 1),
	Role varchar(100),
	Birthday varchar(100),
	Username varchar(100) unique,
	Password varchar(100)
	primary key (Id)
)

create table Seat(
	Id int IDENTITY(1, 1),
	Position char(4) unique,
	primary key(Id)
)
insert into Seat(Position) values('A-1')
insert into Seat(Position) values('A-2')
insert into Seat(Position) values('A-3')
insert into Seat(Position) values('A-4')
insert into Seat(Position) values('A-5')

insert into Seat(Position) values('B-1')
insert into Seat(Position) values('B-2')
insert into Seat(Position) values('B-3')
insert into Seat(Position) values('B-4')
insert into Seat(Position) values('B-5')

insert into Seat(Position) values('C-1')
insert into Seat(Position) values('C-2')
insert into Seat(Position) values('C-3')
insert into Seat(Position) values('C-4')
insert into Seat(Position) values('C-5')

insert into Seat(Position) values('D-1')
insert into Seat(Position) values('D-2')
insert into Seat(Position) values('D-3')
insert into Seat(Position) values('D-4')
insert into Seat(Position) values('D-5')

insert into Seat(Position) values('E-1')
insert into Seat(Position) values('E-2')
insert into Seat(Position) values('E-3')
insert into Seat(Position) values('E-4')
insert into Seat(Position) values('E-5')

go

create table Ticket(
	Id INT IDENTITY(1, 1),
	SeatId int,
    MovieScheduleId int,
    UserId int,
    Date Date,
    Price float check(Price > 0.0),
	primary key(Id),
    unique(SeatId, MovieScheduleId, Date)
)
go

create table Coupon(
    Id int identity(1, 1),
    Name varchar(100),
    Expire date,
    UserId int,
    Discount float check(Discount > 0.0 and Discount < 1.0),
    primary key(Id)
)
go

alter table Coupon
add constraint FK_CP_ACC foreign key(UserId) references Account(Id)

go

create table BirthDateCouponCache(
    UserId int,
    Month int check(Month >= 1 and Month <= 12),
)
go

alter table  BirthDateCouponCache
add constraint FK_BDCC_CP foreign key(UserId) references Account(Id)

go

alter table Ticket
add constraint FK_TICK_SEAT foreign key(SeatId) references Seat(Id),
	constraint FK_TICK_MVSCHE foreign key(MovieScheduleId) references MovieSchedule(Id),
    constraint FK_TICK_USER foreign key(UserId) references Account(Id)


go

alter table MovieStar
add constraint FK_MVSTAR_STAR foreign key (StarId) references Star(Id),
    constraint FK_MVSTAR_MV   foreign key (MovieId) references Movie(Id)

alter table MovieDirector
add constraint FK_MVDIRECTOR_MV foreign key (MovieId) references Movie(Id),
	constraint FK_MVDIRECTOR_DIRECTOR foreign key (DirectorId) references Director(Id)

alter table MovieSchedule
add constraint FK_MVSCHEDULE_MV foreign key (IdSchedule) references Schedule(Id),
	constraint FK_MVSCHEDULE_SCHEDULE foreign key (IdMovie) references Movie(Id)

alter table Movie 
add constraint FK_GENRE foreign key (IdGener) references Genre(Id)

go

insert into Genre(Name)
values
('Horror'),
('Adventure'),
('Action'),
('Romance'),
('Comedy'),
('Drama'),
('History')

insert into Star(Name, Image, Story)
values
	('Lee Do-hyun', 'https://m.media-amazon.com/images/M/MV5BZjY2MDM1ZGMtODY4OS00ZWY1LThmYzktMDdhNDI0ZjdhNzAzXkEyXkFqcGdeQXVyNTI5NjIyMw@@._V1_FMjpg_UX556_.jpg', 'Lee Do-hyun was born on April 11, 1995 in Goyang, South Korea. He is an actor, known for Youth of May (2021), Sweet Home (2020) and 18 Again (2020).'),
    ('Timothée Chalamet', 'https://m.media-amazon.com/images/M/MV5BNThiOTM4NTAtMDczNy00YzlkLWJhNTEtZTZhNDVmYzlkZWI0XkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_FMjpg_UX2160_.jpg', 'Timothée Hal Chalamet was born in Manhattan, to Nicole Flender, a real estate broker and dancer, and Marc Chalamet, a UNICEF editor. His mother, who is from New York, is Jewish, of Russian Jewish and Austrian Jewish descent. His father, who is from Nîmes, France, is of French and English ancestry. He is the brother of actress Pauline Chalamet, a nephew of director Rodman Flender, and a grandson of screenwriter Harold Flender.'),
    ('Zendaya', 'https://m.media-amazon.com/images/M/MV5BMjAxZTk4NDAtYjI3Mi00OTk3LTg0NDEtNWFlNzE5NDM5MWM1XkEyXkFqcGdeQXVyOTI3MjYwOQ@@._V1_FMjpg_UX780_.jpg', 'Zendaya is an American actress and singer born in Oakland, California. She began her career appearing as a child model working for Macy''s, Mervyns and Old Navy. She was a backup dancer before gaining prominence for her role as Rocky Blue on the Disney Channel sitcom Shake It Up (2010) which also includes Bella Thorne, Kenton Duty and Roshon Fegan.'),
    ('Timothée Chalamet', 'https://m.media-amazon.com/images/M/MV5BNThiOTM4NTAtMDczNy00YzlkLWJhNTEtZTZhNDVmYzlkZWI0XkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_FMjpg_UX2160_.jpg', 'Timothée Hal Chalamet was born in Manhattan, to Nicole Flender, a real estate broker and dancer, and Marc Chalamet, a UNICEF editor. His mother, who is from New York, is Jewish, of Russian Jewish and Austrian Jewish descent. His father, who is from Nîmes, France, is of French and English ancestry. He is the brother of actress Pauline Chalamet, a nephew of director Rodman Flender, and a grandson of screenwriter Harold Flender.')     ,
    ('Millie Bobby Brown', 'https://m.media-amazon.com/images/M/MV5BMjA5NzA0NzQzMF5BMl5BanBnXkFtZTgwMTQxNjUzNjM@._V1_FMjpg_UY2048_.jpg', 'Millie Bobby Brown (born 19 February 2004) is an English actress and model. She rose to prominence for her role as Eleven in the Netflix science fiction drama series Stranger Things (2016), for which she earned a Primetime Emmy Award nomination for Outstanding Supporting Actress in a Drama Series at age 13. She is also the youngest person ever to feature on TIME 100 list.'),
    ('Jack Black', 'https://m.media-amazon.com/images/M/MV5BYTFiMWNlNmItMDRiYy00NzA4LWE5YjItZmViNWQ2NzhhOWZlXkEyXkFqcGdeQXVyMTA2Mjc5ODMy._V1_FMjpg_UX750_.jpg', 'Thomas Jacob Jack Black was born on August 28, 1969 in Santa Monica, California and raised in Hermosa Beach, California to Judith Love Cohen & Thomas William Black, both satellite engineers. He is of Russian Jewish & British-German ancestry. Black attended the University of California at Los Angeles. While at UCLA, he was a member of Tim Robbins'' acting troupe & it was through this collaboration that led to his 1992 film debut in Bob Roberts (1992). Although he was just a background voice in his first film, Jack''s appearances in such television shows as The X-Files (1993), his breakthrough performance in High Fidelity (2000) & his rock-5 band, Tenacious D have created an ever-growing cult following.'),
    ('Laura Post', 'https://m.media-amazon.com/images/M/MV5BZTRkNTg2MWEtNTRhMS00ZTkyLWI1MzUtODQzNDE5NDczYWU3XkEyXkFqcGdeQXVyNTg1MzgzNjg@._V1_FMjpg_UX880_.jpg', 'Laura Post was born in Chicago, Illinois, USA. She is an actress, known for Persona 5 Royal (2019), Justice League 3 (2016) and Batman: The Enemy Within (2017). She has been married to Shannon Wilson since 8 September 2012.'),
    ('Kathryn Newton', 'https://m.media-amazon.com/images/M/MV5BMDM5YjI2NDItYWY1My00ZmUyLTgyZjMtOGQzMmEyNjk0ODU5XkEyXkFqcGdeQXVyMjQwMDg0Ng@@._V1_FMjpg_UX959_.jpg', 'Kathryn co-starred as Cassie Lang in Ant-Man and the Wasp: Quantumania 2023, followed by Lisa Frankenstein starring alongside Cole Sprouse and Winner starring Emilia Jones, with release dates sometime in 2023. She can be seen as the lead of Amazon''s The Map of Tiny Perfect Things, on Prime Video. In the fall of 2020, Kathryn starred opposite Vince Vaughn in Universal''s highly anticipated horror-5 Freaky, in which she starred as a high schooler who switches bodies with the local serial killer, played by Vaughn.'),
    ('Robbie Amell', 'https://m.media-amazon.com/images/M/MV5BMjE2OTMyMDM2Ml5BMl5BanBnXkFtZTgwNDAyMjU4NzE@._V1_FMjpg_UX353_.jpg', 'Along with his sister, Robbie Amell started acting when he was just six years old. At sixteen, he started to land theater roles at Lawrence Park Stage in plays such as Louis and Dave, Picasso at the Lapin Agile and The Importance of Being Earnest. The experience brought Robbie to realize that he wanted to pursue a career in acting.'),
    ('Angourie Rice', 'https://m.media-amazon.com/images/M/MV5BMzhkMTczYWEtOThmYS00MDEyLTgzZjAtODE5YTUwMmJiMjAzXkEyXkFqcGdeQXVyOTE0NjgwMjY@._V1_FMjpg_UX649_.jpg', 'Angourie Rice is an Australian actress with international credits including Spider-Man: Far From Home and Black Mirror: Rachel, Jack and Ashley Too.'),
    ('Dakota Johnson', 'https://m.media-amazon.com/images/M/MV5BZDE0ZmEzNzAtZDU2NS00YmI3LWI5YzYtYTBjZGYzODU1YTBkXkEyXkFqcGdeQXVyNDg2MjUxNjM@._V1_FMjpg_UX2160_.jpg', 'Dakota Mayi Johnson is an American actress and fashion model. She was born in Austin, Texas, and is the daughter of actors Don Johnson and Melanie Griffith. Her maternal grandmother is actress Tippi Hedren.'),
    ('Shameik Moore', 'https://m.media-amazon.com/images/M/MV5BMjAwNDU2OTc5M15BMl5BanBnXkFtZTgwOTk0ODMyNDE@._V1_FMjpg_UY3600_.jpg', 'Born in Atlanta of Jamaican descent, Shameik Moore booked his first lead role of Malcolm in Rick Famuyiwa''s Dope (2015), produced by Forest Whitaker and Nina Yang Bongiovi. The film, which is narrated by Forest Whitaker, also stars Tony Revolori, Kiersey Clemons, Zoë Kravitz, Kimberly Elise and A$AP Rocky.'),
    ('Chloe Grace Moretz', 'https://m.media-amazon.com/images/M/MV5BNjBlZTljOTctZmJjZS00YzE0LWE5NTUtMzA2MTE1MGQwMDFhXkEyXkFqcGdeQXVyMTYxNjg0Njgy._V1_FMjpg_UX1010_.jpg', 'Moretz is best known for her work in the sci-fi thriller series The Peripheral, created by Scott B. Smith; the Mattson Tomlin-directed sci-fi thriller Mother/Android; Neil Jordan''s thriller Greta; Roseanne Liang''s Shadow in the Cloud, which claimed the Midnight Madness People''s Choice Award at the Toronto Film Festival in 2020'),
    ('Ko Shibasaki', 'https://m.media-amazon.com/images/M/MV5BODY2MzQwMTE2N15BMl5BanBnXkFtZTcwNzMzNzEzOA@@._V1_FMjpg_UX552_.jpg', 'Ko Shibasaki was born on August 5, 1981 in Tokyo. Her real name is Yukie Yamamura (Ko Shibasaki is a main character of her favorite manga). She started her career at 14 when her talent was discovered by a star agent.'),
    ('Sydney Sweeny', 'https://m.media-amazon.com/images/M/MV5BOTVjOTkxNjMtNDJiYS00YzEzLThmZTItZjJhM2E4NWQyM2Q2XkEyXkFqcGdeQXVyNzM1NTU0NA@@._V1_FMjpg_UY2667_.jpg', 'Sydney Sweeney (born September 12, 1997) is an American actress best known for her roles as Haley Caren on In the Vault (2017) and Emaline Addario on the Netflix series Everything Sucks! (2018).'),
    ('Emilio Sakraya', 'https://m.media-amazon.com/images/M/MV5BOWViZWNhOGMtYzg3MS00MTExLTk5NTgtMGRmOGU1ZGUzYWM0XkEyXkFqcGdeQXVyNjE3NzgzMDM@._V1_FMjpg_UX2061_.jpg', 'Emilio Sakraya started his career at the age of nine with several appearances in film productions. In his childhood years, he discovered his passion for music, karate, kung fu and parkour. He won the German Championship in Full-Contact Karate twice.'),
    ('Kevin Hart', 'https://m.media-amazon.com/images/M/MV5BMTY4OTAxMjkxN15BMl5BanBnXkFtZTgwODg5MzYyMTE@._V1_FMjpg_UY2048_.jpg', 'Kevin Darnell Hart is an African-American comedian and actor who is known for his roles in the Jumanji sequels including Jumanji: Welcome to the Jungle (2017) and Jumanji: The Next Level (2019), Undeclared (2001), Scary Movie 3 (2003), Think Like a Man (2012), Ride Along (2014), The Secret Life of Pets (2016), Captain Underpants: The First Epic Movie (2017), Central Intelligence (2016) and Fast & Furious Presents: Hobbs & Shaw (2019).'),
    ('Brie Larson', 'https://m.media-amazon.com/images/M/MV5BNDE4ZWY1ZTUtYjNhMy00MTQyLWFmMjktNTkyYTFjOGRlNDk0XkEyXkFqcGdeQXVyMTE1MTYxNDAw._V1_FMjpg_UY3000_.jpg', 'Brie Larson has built an impressive career as an acclaimed television actress, rising feature film star and emerging recording artist. A native of Sacramento, Brie started studying drama at the early age of 6, as the youngest student ever to attend the American Conservatory Theater in San Francisco.'),
    ('Sakura Ando', 'https://m.media-amazon.com/images/M/MV5BMDhkZWIwN2EtOWZhMC00NDIwLWEwMmYtYTNmYjg4N2FmMTQyXkEyXkFqcGdeQXVyNTI5NjIyMw@@._V1_FMjpg_UX759_.jpg', 'With parents in the show business perhaps it is not surprising that Ando Sakura would become an actress and, moreover, also end up marrying an actor.'),
    ('Mckenna Grace', 'https://m.media-amazon.com/images/M/MV5BMzI4Y2EzNTEtZWZiZS00NzZmLTlmZWYtNGUwYmE3YjliOWQ5XkEyXkFqcGdeQXVyMzQxNjUxMDE@._V1_FMjpg_UY2400_.jpg', 'Mckenna Grace is an American actress and singer from Grapevine, Texas who is known for playing Phoebe Spengler from Ghostbusters: Afterlife, Jasmine from Crash & Bernstein, Faith Newman from The Young and the Restless and Mary Adler from Gifted. She also acted in I, Tonya, Amityville: The Awakening, The Handmaid''s Tale, Spirit Untamed and Scoob.'),
    ('Bryce Dallas Howard', 'https://m.media-amazon.com/images/M/MV5BNGRkZGQ5OGQtNTlkZS00MDJjLWFlNzMtODRmMDVmYmE1ZTIzXkEyXkFqcGdeQXVyMjQ0MTg4Nw@@._V1_FMjpg_UY2837_.jpg', 'Bryce Dallas Howard was born on March 2, 1981, in Los Angeles, California. She was conceived in Dallas, Texas (the reason for her middle name). Her father, Ron Howard, is a former actor turned Oscar-winning director.'),
    ('DeWanda Wise', 'https://m.media-amazon.com/images/M/MV5BODI2NjE5NjY4Nl5BMl5BanBnXkFtZTgwNjUyMjM5NzM@._V1_FMjpg_UX2048_.jpg', 'In film, television, and theater, DeWanda Wise has established herself as one of the industry''s most consistently critically acclaimed artists.Of her work as Kayla Watts in Jurassic World Dominion, she''s been nearly universally considered a standout of the sixth installment with critics noting her magnetism, swagger, wit, and charisma.'),
    ('Patrick Wilson', 'https://m.media-amazon.com/images/M/MV5BMTkzNzcxNzcxMF5BMl5BanBnXkFtZTgwOTM1ODUzMTE@._V1_FMjpg_UY2048_.jpg', 'Patrick Joseph Wilson was born in Norfolk, Virginia and raised in St. Petersburg, Florida, the son of Mary Kathryn (Burton), a voice teacher and professional singer, and John Franklin Wilson, a news anchor.Wilson has a B.F.A. in Drama from Carnegie-Mellon University. His theater work has produced many nominations and awards.'),
    ('Sophie McIntosh', 'https://m.media-amazon.com/images/M/MV5BNTAyNDdlMzktYmNlZi00NzBmLWIzYTgtYWEyOWQ4ZDZjNzA3XkEyXkFqcGdeQXVyNTgzMzQ4NjI@._V1_FMjpg_UX720_.jpg', 'Sophie McIntosh was born and raised in Auckland, New Zealand. She began dancing at the age of three and trained in classical ballet, contemporary dance and jazz throughout her childhood, performing and competing both nationally and internationally.'),
    ('Sam Worthington', 'https://m.media-amazon.com/images/M/MV5BZWUwNmEwZTUtYzMxMS00ODg5LTlmYjItMGU4ZjNmN2Q1NjkwXkEyXkFqcGdeQXVyMTM1MjAxMDc3._V1_FMjpg_UX567_.jpg', 'Samuel Henry John Worthington was born August 2, 1976 in Surrey, England. His parents, Jeanne (Martyn) and Ronald Worthington, a power plant employee, moved the family to Australia when he was six months old, and raised him and his sister Lucinda in Warnbro, a suburb of Perth, Western Australia.'),
    ('Margot Robbie', 'https://m.media-amazon.com/images/M/MV5BMTgxNDcwMzU2Nl5BMl5BanBnXkFtZTcwNDc4NzkzOQ@@._V1_FMjpg_UX1000_.jpg', 'Margot Elise Robbie was born on July 2, 1990 in Dalby, Queensland, Australia to Scottish parents. Her mother, Sarie Kessler, is a physiotherapist, and her father, is Doug Robbie. She comes from a family of four children, having two brothers and one sister.'),
    ('Cillian Murphy', 'https://m.media-amazon.com/images/M/MV5BMDUxY2M1NTQtNzcwNC00ZDljLTk4YjctYzJjZGNiYTc0YTE1XkEyXkFqcGdeQXVyMTY5MDA5MDc3._V1_FMjpg_UY8256_.jpg', 'Striking Irish actor Cillian Murphy was born in Douglas, the oldest child of Brendan Murphy, who works for the Irish Department of Education, and a mother who is a teacher of French. He has three younger siblings.'),
    ('Jason Statham', 'https://sf2.closermag.fr/wp-content/uploads/closermag/2023/04/jason-statham.png', 'Jason Statham was born in Shirebrook, Derbyshire, to Eileen (Yates), a dancer, and Barry Statham, a street merchant and lounge singer. He was a Diver on the British National Diving Team and finished twelfth in the World Championships in 1992.'),
    ('Corey Hawkins', 'https://m.media-amazon.com/images/M/MV5BMzRkZDVlOWUtNzk4Zi00Y2I2LWI4NjctODg1ZDA0OTEyOTNmXkEyXkFqcGdeQXVyMjQxMzY5NzE@._V1_FMjpg_UX600_.jpg', 'Corey Hawkins was born on 22 October 1988 in Washington, District of Columbia, USA. He is an actor and producer, known for Straight Outta Compton (2015), Kong: Skull Island (2017) and BlacKkKlansman (2018).'),
    ('Tom Cruise', 'https://m.media-amazon.com/images/M/MV5BYTFlOTdjMjgtNmY0ZC00MDgxLThjNmEtZGIxZTQyZDdkMTRjXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UY5122_.jpg', 'In 1976, if you had told fourteen-year-old Franciscan seminary student Thomas Cruise Mapother IV that one day in the not too distant future he would be Tom Cruise, one of the top 100 movie stars of all time, he would have probably grinned and told you that his ambition was to join the priesthood.'),
    ('Ana de Armas', 'https://m.media-amazon.com/images/M/MV5BMWM3MDMzNjMtODM5Ny00YmY0LWJhNzQtNTE1ZDNlNjllNDQ0XkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_FMjpg_UX2160_.jpg', 'Ana de Armas was born in Cuba on April 30, 1988. At the age of 14 (2002) she began her studies at the National Theatre School of Havana, where she graduated after 4 years. At the age of 16 (2004) she made her first film, Virgin Rose (2006), directed by Manuel Gutiérrez Aragón.')

insert into Director(Name, Image, Story)
values
('Jae-hyun Jang', 'https://asianwiki.com/images/5/5e/Jang-Jae-Hyun-11-08-2015.jpg', 'South Korean director Jang Jae-hyun, born in 1981, has carved a niche in supernatural films. After building his name with shorts like Bus and graduating to features like The Priests in 2015, he''s become known for meticulous portrayals of Korean shamanism and the occult.'),
('Denis Villeneuve', 'https://m.media-amazon.com/images/M/MV5BMTc0NTEyMTAwN15BMl5BanBnXkFtZTgwOTM5OTAyMDE@._V1_FMjpg_UX852_.jpg', 'Denis Villeneuve is a French Canadian film director and writer. He was born in 1967, in Trois-Rivières, Québec, Canada. He started his career as a filmmaker at the National Film Board of Canada. He is best known for his feature films Arrival (2016), Sicario (2015), Prisoners (2013), Enemy (2013), and Incendies (2010). He is married to Tanya Lapointe.'),
('Paul King', 'https://m.media-amazon.com/images/M/MV5BMTUwODA0NjUyNV5BMl5BanBnXkFtZTgwODk3Mzk5MzE@._V1_FMjpg_UY2048_.jpg', 'Paul King is known for Wonka (2023), Paddington (2014) and Paddington 2 (2017).'),
('Juan Carlos Fresnadillo', 'https://m.media-amazon.com/images/M/MV5BMTUyOTcyNjk4N15BMl5BanBnXkFtZTgwOTU5OTA5OTE@._V1_FMjpg_UY2048_.jpg', 'Juan Carlos Fresnadillo was born on 5 December 1967 in Tenerife, Canary Islands, Spain. He is a producer and director, known for 28 Weeks Later (2007), Intacto (2001) and Linked (1996).'),
('Mike Mitchell', 'https://m.media-amazon.com/images/M/MV5BMjMwNDkwNTcyN15BMl5BanBnXkFtZTgwODA1NjU4MDI@._V1_FMjpg_UY2048_.jpg', 'Mike Mitchell was born in Oklahoma City to parents, Robert Mitchell, and Julia Baker. He graduated from Putnam City North High School, having been deeply involved with their arts programs. He then left behind his hometown and moved to Los Angeles to attend the California Institute of the Arts. During his time in college, animators were in high demand. This led him into television, working for distinguished filmmakers such as Tim Burton and Spike Jonze.'),
('Eric Fogel', 'https://m.media-amazon.com/images/M/MV5BMmY5MzM5ZjUtYjFmNC00YTIyLTg1Y2UtM2JhNWViZmYzNzRmXkEyXkFqcGdeQXVyNjA0NDM4MzI@._V1_FMjpg_UX2160_.jpg', 'With a BFA in Film/TV from New York University''s Tisch School of the Arts, Eric has been directing animation for over 20 years. He created his first animated series at MTV, a quirky sci-fi 5 called The Head. In just two years, it acquired a cult following and spawned a successful graphic novel.'),
('Zelda Williams', 'https://m.media-amazon.com/images/M/MV5BZjIzYzQ4MGYtZWYzNS00N2FjLThjZmEtNDhjNjJkNTQxNDJmXkEyXkFqcGdeQXVyMTU2MDcyMjMw._V1_FMjpg_UY1510_.jpg', 'Zelda Williams was born on 31 July 1989 in New York City, New York, USA. She is an actress and director, known for Were the World Mine (2008), The Legend of Korra (2012) and Never (2014).'),
('Jeff Chan', 'https://m.media-amazon.com/images/M/MV5BNWM5MGUyOWQtYTExYy00ODFmLTgxZTctM2U0MDA0YzUxZjJjXkEyXkFqcGdeQXVyMzE5NDIyODU@._V1_FMjpg_UX1516_.jpg', 'Jeff Chan is known for Code 8 (2016).'),
('Samantha Jayne', 'https://m.media-amazon.com/images/M/MV5BMTYzMDQ1NDc5OV5BMl5BanBnXkFtZTgwNzY1NjI0NDE@._V1_FMjpg_UY7097_.jpg', 'Samantha Jayne is known for Quarter Life Poetry (2019), Vanity (2015) and Quarter Life Poetry: Poems for the Young, Broke & Hangry (2016). She is married to Arturo Perez Jr..'),
('S.J. Clarkson', 'https://m.media-amazon.com/images/M/MV5BOWNhZGE2NjQtMzdlMC00ZjM5LWFmMzYtYjdiZThjNzI0YTZmXkEyXkFqcGdeQXVyMTczMDQyNTQ2._V1_FMjpg_UX1080_.jpg', 'S.J. Clarkson is known for Madame Web (2024), The Defenders (2017) and Life on Mars (2006).'),
('Joaquim Dos Santos', 'https://m.media-amazon.com/images/M/MV5BNjcyNTcxOTU4MV5BMl5BanBnXkFtZTcwODAxNzkyMg@@._V1_FMjpg_UX1138_.jpg', 'Joaquim Dos Santos was born on 22 June 1977 in Lisbon, Portugal. He is a producer, known for Spider-Man: Across the Spider-Verse (2023), The Legend of Korra (2012) and Avatar: The Last Airbender (2005).'),
('Nick Bruno', 'https://m.media-amazon.com/images/M/MV5BZTQwZGRmNjMtZjFmNS00M2E4LTkwN2EtMTEzYmM2ZTMyNzVjXkEyXkFqcGdeQXVyMTA5NTIzMzA1._V1_FMjpg_UY5184_.jpg', 'A veteran of Blue Sky Studios, Nick Bruno makes his directorial debut with Spies in Disguise.Born and raised in Mohegan Lake, NY he learned at an early age that he could combine his love for drawing and filmmaking by pursuing a career in animation, which led him to study illustration and the fine arts at UMass, Dartmouth.'),
('Hayao Miyazaki', 'https://m.media-amazon.com/images/M/MV5BMDZiZTI4NDMtYjEwYi00Njg5LWEzMjAtYjIzNWI2MDdlZDcxXkEyXkFqcGdeQXVyNTAyNDQ2NjI@._V1_FMjpg_UX1200_.jpg', 'Hayao Miyazaki is 1 of Japan''s greatest animation directors. The entertaining plots, compelling characters & breathtaking animation in his films have earned him international renown from critics as well as public recognition within Japan.'),
('Will Gluck', 'https://m.media-amazon.com/images/M/MV5BMjM2NTcxMjA3OF5BMl5BanBnXkFtZTgwODAyODY2ODE@._V1_FMjpg_UX2048_.jpg', 'Will Gluck is the Golden Globe-nominated writer/director/producer known for Easy A (2010), Friends with Benefits (2011), Annie (2014), the Peter Rabbit (2018) movies, and a number of TV shows including Woke (2020), Chicago Party Aunt (2021), and The Michael J. Fox Show (2013).'),
('Oliver Kienle', 'https://m.media-amazon.com/images/M/MV5BNjlhN2JmZjctNDMxYi00NWZiLThkYjAtY2ZjZGM4YTE4NzNhXkEyXkFqcGdeQXVyNzgyNzQxOA@@._V1_FMjpg_UX2160_.jpg', 'Oliver Kienle was born in 1982 in Dettelbach, Bavaria, Germany. He is a writer and director, known for Stronger Than Blood (2010), Bad Banks (2018) and Four Hands (2017).'),
('Felix Gary Gray', 'https://m.media-amazon.com/images/M/MV5BMTQzNTAwNzY4N15BMl5BanBnXkFtZTcwOTU5MzE0NQ@@._V1_FMjpg_UY2048_.jpg', 'Felix Gary Gray is an African-American music video director, film producer and film director from New York City known for directing films such as Friday, Men in Black: International, Be Cool, The Fate of the Furious, Set It Off, The Negotiator, Straight Outta Compton and The Italian Job.'),
('Nia DaCosta', 'https://m.media-amazon.com/images/M/MV5BMjc4NDk1ZTAtY2I0Ni00ODZmLTg4OGYtNGE4ZDNhY2EzZmNhXkEyXkFqcGdeQXVyMjQwMDg0Ng@@._V1_FMjpg_UX437_.jpg', 'Nia DaCosta was born on 8 November 1989 in Brooklyn, New York City, New York, USA. She is a writer and producer, known for Candyman (2021), Little Woods (2018) and The Marvels (2023).'),
('Kore-eda Hirokazu', 'https://m.media-amazon.com/images/M/MV5BNjc3NDY4MzgzMV5BMl5BanBnXkFtZTcwNDI5NTc1OQ@@._V1_FMjpg_UY2048_.jpg', 'Born in Tokyo in 1962. Originally intended to be a novelist, but after graduating from Waseda University in 1987 went on to become an assistant director at T.V. Man Union.'),
('Gil Kenan', 'https://m.media-amazon.com/images/M/MV5BMzkzMjc0NzI5NV5BMl5BanBnXkFtZTcwOTI0NTE4MQ@@._V1_FMjpg_UX450_.jpg', 'Gil Kenan was born on 16 October 1976 in London, England, UK. He is a director and writer, known for Monster House (2006), Ghostbusters: Afterlife (2021) and City of Ember (2008).'),
('Matthew Vaughn', 'https://m.media-amazon.com/images/M/MV5BNmU4NmQ5N2UtYzBhNS00ODhjLWEwYzktZWY3NmUzMzNjYWU0XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX2160_.jpg', 'Matthew Vaughn is an English film producer and director. He is known for producing such films as Lock, Stock and Two Smoking Barrels (1998) and Snatch (2000) and for directing the crime thriller, Layer Cake (2004), the fantasy epic, Stardust (2007), the superhero 5, Kick-Ass (2010), and the superhero film, X-Men: First Class (2011). Vaughn was educated at Stowe School in Buckingham, England.'),
('Jeff Wadlow', 'https://m.media-amazon.com/images/M/MV5BZTg2YjViZDMtYWQyMi00ZTVhLWE5N2MtMjAwZWMzM2FkOGFmXkEyXkFqcGdeQXVyNDAwMjExMTA@._V1_FMjpg_UY1537_.jpg', 'DGA award nominee Jeff Wadlow''s forthcoming theatrical film, Imaginary, marks his third collaboration with Jason Blum under a first look deal that launched Jeff''s own production company, Tower of Babble Entertainment.'),
('Patrick Wilson', 'https://m.media-amazon.com/images/M/MV5BMTkzNzcxNzcxMF5BMl5BanBnXkFtZTgwOTM1ODUzMTE@._V1_FMjpg_UY2048_.jpg', 'Patrick Joseph Wilson was born in Norfolk, Virginia and raised in St. Petersburg, Florida, the son of Mary Kathryn (Burton), a voice teacher and professional singer, and John Franklin Wilson, a news anchor.Wilson has a B.F.A. in Drama from Carnegie-Mellon University. His theater work has produced many nominations and awards.'),
('Claudio Fah', 'https://m.media-amazon.com/images/M/MV5BNjQwYzBkZGUtMzQ0ZC00MWJmLTlhZDgtNDg5Y2EwNTNlODljXkEyXkFqcGdeQXVyMzc3ODE5NzA@._V1_FMjpg_UX1924_.jpg', 'Fah''s latest work is the upcoming survival thriller ''No Way Up'' for Altitude Film Entertainment and Ingenious Media, starring Colm Meaney (Hell on Wheels, Star Trek) alongside BAFTA Award winner Phyllis Logan (Downton Abbey), Sophie McIntosh (Brave New World) and Will Attenborough (Dunkirk). ''No Way Up'' is scheduled for a 2024 release in theaters and online worldwide.'),
('James Cameron', 'https://m.media-amazon.com/images/M/MV5BZDM0ZWIxN2EtODQwZC00NWI3LTgxNzMtNjBkZjQzNDUzYzY0XkEyXkFqcGdeQXVyMzQ3Nzk5MTU@._V1_FMjpg_UY1968_.jpg', 'James Francis Cameron was born on August 16, 1954 in Kapuskasing, Ontario, Canada. He moved to the United States in 1971. The son of an engineer, he majored in physics at California State University before switching to English, and eventually dropping out. He then drove a truck to support his screenwriting ambition.'),
('Greta Gerwig', 'https://m.media-amazon.com/images/M/MV5BNDE5MTIxMTMzMV5BMl5BanBnXkFtZTcwMjMxMDYxOQ@@._V1_FMjpg_UY2048_.jpg', 'Greta Gerwig is an American actress, playwright, screenwriter, and director. She has collaborated with Noah Baumbach on several films, including Greenberg (2010), Frances Ha (2012), for which she earned a Golden Globe nomination, and Mistress America (2015).'),
('Christopher Nolan', 'https://m.media-amazon.com/images/M/MV5BYjcxODI4OTgtYWI4NC00ZjhjLWFjYjYtNGZkODM4OTE4NGFhXkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_FMjpg_UX1165_.jpg', 'Best known for his cerebral, often nonlinear, storytelling, acclaimed writer-director Christopher Nolan was born on July 30, 1970, in London, England. Over the course of 15 years of filmmaking, Nolan has gone from low-budget independent films to working on some of the biggest blockbusters ever made.At 7 years old, Nolan began making short movies with his father''s Super-8 camera.'),
('Ben Wheatley', 'https://m.media-amazon.com/images/M/MV5BMTMyMDAxODIyMl5BMl5BanBnXkFtZTcwOTg5MjUzNA@@._V1_FMjpg_UY1936_.jpg', 'Ben Wheatley was born in May 1972 in Billericay, Essex, England, UK. He is a director and writer, known for Free Fire (2016), Kill List (2011) and Sightseers (2012).'),
('Andre Ovredal', 'https://m.media-amazon.com/images/M/MV5BMTU4MjYxNzc4Ml5BMl5BanBnXkFtZTcwNjQzNTMyNQ@@._V1_FMjpg_UY2048_.jpg', 'Andre Ovredal was born on 6 May 1973. He is a director and writer, known for Troll Hunter (2010), The Autopsy of Jane Doe (2016) and Tunnelen (2016).'),
('Christopher McQuarrie', 'https://m.media-amazon.com/images/M/MV5BMzQyMzg1NjUxN15BMl5BanBnXkFtZTgwNDAyMjAwMDE@._V1_FMjpg_UY2048_.jpg', 'Christopher McQuarrie is an acclaimed producer, director and an Academy Award® winning writer. McQuarrie grew up in Princeton Junction, New Jersey and in lieu of college, he spent the first five years out of school traveling and working at a detective agency. He later moved to Los Angeles to pursue a career in film.'),
('Dexter Fletcher', 'https://m.media-amazon.com/images/M/MV5BMGMwNWMxZGEtNzgzMi00ZDcwLTgwMWEtNjg3OGFkZTBjZDJkXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_FMjpg_UY3808_.jpg', 'Two-time BAFTA-nominated director Dexter Fletcher is an English actor-turned-filmmaker whose movies and TV work include the Academy Award-winning Elton John biopic Rocketman. Fletcher started his career in front of the camera at the age of 6; three years later he played ''Baby Face'' in Alan Parker''s Bugsy Malone.')


insert into Movie(Title, IdGener, Runtime, Detail, Release, Rating, Poster, Landscape, Certification) 
values 
	('Exhuma', '1', '2h 14m', 'Exhuma (2024) follows a wealthy family in LA haunted by a vengeful ancestor. Two young shamans, Hwa-rim and Bong-gil, are called in to appease the restless spirit. They discover the culprit is buried in a remote Korean village and enlist a geomancer and undertaker to exhume the grave. Unearthing the truth behind the ancestor''s anger unleashes a sinister force with horrifying consequences.', '2024', 7.4, 'https://m.media-amazon.com/images/M/MV5BOWNlMDQwY2MtNzFiMy00NDE3LThiNjctZDZmMDk3NzJhN2FkXkEyXkFqcGdeQXVyNjI4NDY5ODM@._V1_FMjpg_UY2142_.jpg', 'https://6.soompi.io/wp-content/uploads/image/20240202025900_exhuma.jpg', 'PG-16'),
	('Dune: Part Two', '2', '2h 46m', 'Picking up after the betrayal of House Harkonnen, Paul Atreides seeks revenge while embracing Fremen life on the desert planet Arrakis.  As his bond with Chani deepens, Paul takes on the Fremen mantle of Muad''Dib and leads daring raids against the spice harvesters. Facing a future filled with war and visions of a holy war, Paul must confront not only the remaining Harkonnens but also his own destiny as the Fremen''s messiah.', '2024', 8.9, 'https://m.media-amazon.com/images/M/MV5BN2QyZGU4ZDctOWMzMy00NTc5LThlOGQtODhmNDI1NmY5YzAwXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_FMjpg_UY4096_.jpg', 'https://pbs.twimg.com/media/GFLXqt4a8AAuI4n.jpg', 'PG-16'),
	('Wonka', '2', '1h 56m', 'Wonka isn''t a tale of golden tickets, but a prequel showing a young Willy Wonka fight poverty and a controlling chocolate industry to open his dream shop. Through fantastical inventions and newfound friendships, Willy overcomes these challenges, paving the way for the magical chocolate world encountered in Charlie and the Chocolate Factory.', '2024', 7.1, 'https://m.media-amazon.com/images/M/MV5BNDM4NTk0NjktZDJhMi00MmFmLTliMzEtN2RkZDY2OTNiMDgzXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY2048_.jpg', 'https://www.chattanoogapulse.com/downloads/27787/download/WONKA_TOS_EM_1920x1080.jpg?cb=6106e572bfe5d4343f83f30ad383fc2d&w=1920', 'PG'),
	('Damsel', '2', '1h 48m', 'Elodie, a kind woman raised in a harsh village, agrees to marry a prince to secure her people''s future. But the wedding turns out to be a cruel trick: the royal family sacrifices her to a fire-breathing dragon in a cave. With no knight in shining armor coming, Elodie must rely on her own wit and strength to survive the dragon''s lair and find a way to escape.', '2024', 6.3, 'https://m.media-amazon.com/images/M/MV5BNmEzOTE4NzktYWU4Ny00YTQ3LTlhNDEtMjNmNTg3NTRkMzNhXkEyXkFqcGdeQXVyMTMzNzIyNDc1._V1_FMjpg_UX450_.jpg', 'https://www.actvid.co.uk/wp-content/uploads/2024/02/Damsel.jpg', 'PG-13'),
	('Kung Fu Panda 4', '3', '1h 34m', 'After Po is tapped to become the Spiritual Leader of the Valley of Peace, he needs to find and train a new Dragon Warrior, while a wicked sorceress plans to re-summon all the master villains whom Po has vanquished to the spirit realm.', '2024', 6.8, 'https://m.media-amazon.com/images/M/MV5BZDY0YzI0OTctYjVhYy00MTVhLWE0NTgtYTRmYTBmOTE3YTViXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY5000_.jpg', 'https://vir.com.vn/stores/news_dataimages/2024/032024/11/15/new-kung-fu-panda-kicks-all-comers-to-top-namerica-box-office-20240311150902.jpg?rt=20240311150904', 'PG'),
	('Megamind vs. The Doom Syndicate', '3', '1h 23m', 'Megamind''s former villain team, The Doom Syndicate, has returned. Our newly crowned blue hero must now keep up evil appearances until he can assemble his friends to stop his former evil teammates from launching Metro City to the Moon.', '2024', 2.2, 'https://m.media-amazon.com/images/M/MV5BOGVkMmU1YWUtNmJlNi00ODJhLWI4NWMtMjY3YTA3MDJjOTVlXkEyXkFqcGdeQXVyMTk2OTAzNTI@._V1_FMjpg_UY3000_.jpg', 'https://i.kym-cdn.com/entries/icons/original/000/048/390/Megamind_vs_the_doom_syndicate_poster_parodies_banner_image.jpg', 'TV-G'),
	('Lisa Frankenstein', '4', '1h41m', 'A coming of RAGE love story about a teenager and her crush, who happens to be a corpse. After a set of horrific circumstances bring him back to life, the two embark on a journey to find love, happiness - and a few missing body parts.', '2024', 6.2, 'https://m.media-amazon.com/images/M/MV5BNjJkZDExMGQtNGE2YS00YzJiLWJiNjEtNmYwZjIxZGMxNTZiXkEyXkFqcGdeQXVyMjkwOTAyMDU@._V1_FMjpg_UY7466_.jpg', 'https://dailydead.com/wp-content/uploads/2024/02/Lisa-Frankenstein-1000-03.jpg', 'PG-13'),
	('Code 8: Part II', '3', '1h 40m', 'Follows a girl fighting to get justice for her slain brother by corrupt police officers. She enlists the help of an ex-con and his former partner, they face a highly regarded and well protected police sergeant who doesn''t want to be.', '2024', 5.7, 'https://m.media-amazon.com/images/M/MV5BNmEyNzNlZjgtNzg1Zi00MTZjLWE5NGQtNDljNzUzYTJiODliXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY2222_.jpg', 'https://www.superherohype.com/wp-content/uploads/sites/4/2023/11/EN-US_Code8_P2_Teaser_Vertical_27x40_RGB_PRE-1.jpg', 'PG-16'),
	('Mean Girls', '5', '1h 52m', 'Cady Heron is a hit with the Plastics, an A-list girl clique at her new school. But everything changes when she makes the mistake of falling for Aaron Samuels, the ex-boyfriend of alpha Plastic Regina George.', '2024', 5.9, 'https://m.media-amazon.com/images/M/MV5BNDExMGMyN2QtYjRkZC00Yzk1LTkzMDktMTliZTI5NjQ0NTNkXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_FMjpg_UX1093_.jpg', 'https://i0.wp.com/stageberry.com/wp-content/uploads/2023/09/New-Mean-Girls-Movie-musical.jpg?fit=1920%2C1080&ssl=1', 'PG-13'),
	('Madame Web', '3', '1h 56m', 'Cassandra Webb is a New York metropolis paramedic who begins to demonstrate signs of clairvoyance. Forced to challenge revelations about her past, she needs to safeguard three young women from a deadly adversary who wants them destroyed.', '2024', 3.7, 'https://m.media-amazon.com/images/M/MV5BYWJkY2Q4NmYtOGRlMi00YTg5LWE2ZmQtY2NkYzk3YTRmNWZlXkEyXkFqcGdeQXVyMTY3ODkyNDkz._V1_FMjpg_UY2075_.jpg', 'https://images.squarespace-cdn.com/content/v1/51b3dc8ee4b051b96ceb10de/9273aaa5-7c6e-4dbf-b564-224247222d03/new-posters-released-for-the-spider-man-universe-film-madame-web.jpg', 'PG-13'),
('Spider-Man: Across the Spider-Verse', '3', '2h 20m', 'Miles Morales catapults across the multiverse, where he encounters a team of Spider-People charged with protecting its very existence. When the heroes clash on how to handle a new threat, Miles must redefine what it means to be a hero.', '2023', 8.6, 'https://m.media-amazon.com/images/M/MV5BMzI0NmVkMjEtYmY4MS00ZDMxLTlkZmEtMzU4MDQxYTMzMjU2XkEyXkFqcGdeQXVyMzQ0MzA0NTM@._V1_FMjpg_UY1929_.jpg', 'https://images8.alphacoders.com/133/1335152.jpg', 'PG'),
('Nimona', '3', '1h 41m', 'When a knight in a futuristic medieval world is framed for a crime he didn''t commit, the only one who can help him prove his innocence is Nimona -- a mischievous teen who happens to be a shapeshifting creature he''s sworn to destroy.', '2023', 7.5, 'https://m.media-amazon.com/images/M/MV5BMWYxZjNlMDUtZmFlYS00ZmUwLThkZDItZmQ4MWI4MThhNmEzXkEyXkFqcGdeQXVyMTA1OTcyNDQ4._V1_FMjpg_UY2222_.jpg', 'https://sportshub.cbsistatic.com/i/2023/06/14/89d8fb64-0f94-4c74-b26c-a68bdabaa278/nimona-movie-netflix-poster.jpg?auto=webp&width=1200&height=675&crop=1.778:1,smart', 'PG'),
('The Boy and the Heron', '2', '2h 4m', 'In the wake of his mother''s death and his father''s remarriage, a headstrong boy named Mahito ventures into a dreamlike world shared by both the living and the dead.', '2024', 7.6, 'https://m.media-amazon.com/images/M/MV5BZjZkNThjNTMtOGU0Ni00ZDliLThmNGUtZmMxNWQ3YzAxZTQ1XkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY2194_.jpg', 'https://i.ytimg.com/vi/t5khm-VjEu4/maxresdefault.jpg', 'PG-13'),
('Anyone But You', '4', '1h 43m', 'After an amazing first date, Bea and Ben''s fiery attr3 turns ice-cold--until they find themselves unexpectedly reunited at a wedding in Australia. So they do what any two mature adults would do: pretend to be a couple.', '2023', 6.2, 'https://m.media-amazon.com/images/M/MV5BOTVhZGU2OWQtNDM1Ni00MzM3LTgzYjgtOTEwYzQzOWZjNTIyXkEyXkFqcGdeQXVyMTcwOTQzOTYy._V1_FMjpg_UY3000_.jpg', 'https://s1.ticketm.net/dam/e/7ab/6510668e-867a-4acc-8e34-9a323534b7ab_RETINA_LANDSCAPE_16_9.jpg', 'R'),
('Sixty Minutes', '3', '1h 28m', 'Desperate not to lose custody, a mixed martial arts fighter makes dangerous enemies when he ditches a matchup to race to his daughter''s birthday party.', '2024', 5.7, 'https://m.media-amazon.com/images/M/MV5BNWM3OTdhYjAtMDVlZC00ZDlhLTg2NWUtMTg4ZGFkYTM2YmIzXkEyXkFqcGdeQXVyMDYyODA2Mw@@._V1_FMjpg_UX450_.jpg', 'https://i.ytimg.com/vi/mRsMJs9juaQ/maxresdefault.jpg', 'PG-16'),
('Lift', '3', '1h 47m', 'Follows a master thief and his Interpol Agent ex-girlfriend who team up to steal $500 million in gold bullion being transported on an A380 passenger flight.', '2024', 5.5, 'https://m.media-amazon.com/images/M/MV5BNTBlNmEwNzQtZTc5MC00YmVjLTk5NjgtMmM0NDFmZjJkZjYzXkEyXkFqcGdeQXVyNTE1NjY5Mg@@._V1_FMjpg_UX1014_.jpg', 'https://media.cnn.com/api/v1/images/stellar/prod/240109095636-lift-movie-netflix-kevin-hart.jpg?c=original', 'PG-13'),
('The Marvels', '3', '1h 45m', 'Carol Danvers gets her powers entangled with those of Kamala Khan and Monica Rambeau, forcing them to work together to save the universe.', '2023', 5.6, 'https://m.media-amazon.com/images/M/MV5BM2U2YWU5NWMtOGI2Ni00MGMwLWFkNjItMjgyZWMxNjllNTMzXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_FMjpg_UY2500_.jpg', 'https://i.ebayimg.com/images/g/0hcAAOSwL1xkSECV/s-l1600.jpg', 'PG-13'),
('Monster', '6', '2h 7m', 'A single mom named Saori notices her son Minato acting strangely after a fight at school. Suspecting his teacher, Mr. Hori, of abuse, Saori confronts the school but is met with resistance.', '2023', 7.9, 'https://m.media-amazon.com/images/M/MV5BMDY0YzNlZWQtOTZkOS00NGQ5LTkzYTYtOTg2OWJkYWJiMTVlXkEyXkFqcGdeQXVyMTEzMTI1Mjk3._V1_FMjpg_UX1107_.jpg', 'https://sashaymagazine.com/wp-content/uploads/2023/10/22Monster22-movie-poster.jpg', 'PG-13'),
('Ghostbusters: Frozen Empire', '2', '2h 5m', 'When the discovery of an ancient artifact unleashes an evil force, Ghostbusters new and old must join forces to protect their home and save the world from a second ice age.', '2024', 5.6, 'https://m.media-amazon.com/images/M/MV5BNGE5MWJmZWYtN2ZlMi00ZjY1LTlhYTUtMzQ2Y2IxZWQyYTA2XkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY3000_.jpg', 'https://assets-in.bmscdn.com/discovery-catalog/events/et00380545-jnuxmkycze-landscape.jpg', 'PG-13'),
('Argylle', '3', '2h 19m', 'A reclusive author who writes espionage novels about a secret agent and a global spy syndicate realizes the new book she''s writing starts to mirror real-world events, in real time.', '2024', 5.9, 'https://m.media-amazon.com/images/M/MV5BZDM3YTg4MGUtZmUxNi00YmEyLTllNTctNjYyNjZlZGViNmFhXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY5000_.jpg', 'https://www.chattanoogapulse.com/downloads/28126/download/01_ARG_WEB_THEATERS_GENERIC_1920X1080_DATED_RR_F01_010324.jpg?cb=70d13c3ade88e082fe3d7f967fea3e19', 'PG-13'),
('Imaginary', '1', '1h 44m', 'A woman returns to her childhood home to discover that the imaginary friend she left behind is very real and unhappy that she abandoned him.', '2024', 4.8, 'https://m.media-amazon.com/images/M/MV5BODIzOTJiODUtNzM2MC00YjdjLTg5YTktZWZhNjY1N2I5NWRjXkEyXkFqcGdeQXVyMjY5ODI4NDk@._V1_FMjpg_UY5000_.jpg', 'https://img.youtube.com/vi/8XoNfrgrAGM/maxresdefault.jpg', 'PG-13'),
('Insidious: The Red Door', '1', '1h 47m', 'Insidious: The Red Door (2023) reunites a broken Lambert family. Years after battling evil spirits in ''The Further'', Josh struggles to reconnect with his son Dalton, who starts having disturbing visions of a red door. When Dalton gets pulled back into The Further, Josh must confront his own repressed memories and a powerful demon to save his son and finally seal the gateway between worlds.', '2023', 5.5, 'https://m.media-amazon.com/images/M/MV5BOTQyNGY5ZGQtN2E1MC00ZDhkLWJiYWMtMTFjODAwMDFmZDRhXkEyXkFqcGdeQXVyMDc5ODIzMw@@._V1_FMjpg_UX604_.jpg', 'https://assets-in.bmscdn.com/discovery-catalog/events/et00357727-sjgpeajymm-landscape.jpg', 'PG-13'),
('No Way Up', '2', '1h 30m', 'Characters from different backgrounds are thrown together when the plane they''re travelling on crashes into the Pacific Ocean. A nightmare fight for survival ensues with the air supply running out and dangers creeping in from all sides.', '2024', 4.5, 'https://m.media-amazon.com/images/M/MV5BMTEyOTQzZjgtMDM1OC00MWMxLWI2ZGUtYWUwOTQxNTRmZTU0XkEyXkFqcGdeQXVyNTU1MDIzMzg@._V1_FMjpg_UX696_.jpg', 'https://i.ytimg.com/vi/TFO9nzKCa2I/maxresdefault.jpg', 'PG-13'),
('Avatar: The Way of Water', '2', '3h 12m', 'Jake Sully lives with his newfound family formed on the extrasolar moon Pandora. Once a familiar threat returns to finish what was previously started, Jake must work with Neytiri and the army of the Na''vi race to protect their home.', '2022', 7.6, 'https://m.media-amazon.com/images/M/MV5BYjhiNjBlODctY2ZiOC00YjVlLWFlNzAtNTVhNzM1YjI1NzMxXkEyXkFqcGdeQXVyMjQxNTE1MDA@._V1_FMjpg_UX900_.jpg', 'https://img1.wsimg.com/isteam/ip/d6a3e7a7-e920-4711-bf09-856dd846af78/AVATAR2.jpg', 'PG-13'),
('Barbie', '2', '1h 54m', 'Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.', '2023', 6.9, 'https://m.media-amazon.com/images/M/MV5BNjU3N2QxNzYtMjk1NC00MTc4LTk1NTQtMmUxNTljM2I0NDA5XkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_FMjpg_UY2814_.jpg', 'https://staticg.sportskeeda.com/editor/2023/07/cec24-16884422905142-1920.jpg', 'PG-13'),
('Oppenheimer', '7', '3h', 'Christopher Nolan''s ''Oppenheimer'' (2023) explores the life of J. Robert Oppenheimer, the father of the atomic bomb. It weaves between his rise to scientific fame leading the Manhattan Project, the moral complexities of creating such a destructive weapon, and his later fall from grace due to suspected communist ties. The film delves into the personal and ethical struggles of a brilliant mind forever changed by ushering in the nuclear age.', '2023', 8.4, 'https://m.media-amazon.com/images/M/MV5BMDBmYTZjNjUtN2M1MS00MTQ2LTk2ODgtNzc2M2QyZGE5NTVjXkEyXkFqcGdeQXVyNzAwMjU2MTY@._V1_FMjpg_UY3454_.jpg', 'https://thecollision.org/wp-content/uploads/2023/07/2-2.jpeg', 'R'),
('Meg 2: The Trench', '1', '1h 56m', 'In Meg 2: The Trench (2023), Jonas Taylor and a research team on a deep-sea dive encounter a hidden mining operation disturbing a Mariana Trench ecosystem teeming with Megalodons, giant prehistoric sharks. The situation escalates as the team gets caught between the colossal predators and ruthless miners, forcing them to fight for survival and uncover a shocking secret about the mining operation''s true motives.', '2023', 5.0, 'https://m.media-amazon.com/images/M/MV5BMTM2NTU1ZTktNjc4YS00NjNhLWE4NmYtOTM2YjFjOGUzNmYzXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_FMjpg_UY3000_.jpg', 'https://talkiescorner.com/wp-content/uploads/2023/08/Meg-2-The-Trench-Movie-Review.webp', 'PG-13'),
('The Last Voyage of the Demeter', '1', '1h 58m', 'The Demeter, a merchant ship, sets sail from Eastern Europe for London carrying mysterious cargo. As the voyage progresses, the crew dwindles under mysterious circumstances. It turns out they''re not alone - the legendary vampire Dracula is aboard, feeding on the crew and turning the journey into a terrifying fight for survival.', '2023', 6.1, 'https://m.media-amazon.com/images/M/MV5BOTljMzRkNDItNjYxYS00ODA4LThiZjYtMjI0MTFjODlmMGJmXkEyXkFqcGdeQXVyNzU0NzQxNTE@._V1_FMjpg_UY6000_.jpg', 'https://m.media-amazon.com/images/S/pv-target-images/bd9d8f54c54038849e098c424a2d5887fdcbc64988b29ef3b33d51e5f710c9ee.jpg', 'R'),
('Mission: Impossible - Dead Reckoning Part One', '3', '2h 43m', 'Ethan Hunt and his IMF team race against time to find a deadly weapon - a powerful AI program called the Entity - controlled by a two-part key.  The mission takes them around the globe, from rescuing a key fragment from a disavowed agent to a high-stakes chase in Abu Dhabi. Facing a mysterious enemy and double-crosses, Ethan must decide who to trust as he tries to destroy the Entity before it falls into the wrong hands.', '2023', 7.7, 'https://m.media-amazon.com/images/M/MV5BYzFiZjc1YzctMDY3Zi00NGE5LTlmNWEtN2Q3OWFjYjY1NGM2XkEyXkFqcGdeQXVyMTUyMTUzNjQ0._V1_FMjpg_UX695_.jpg', 'https://images8.alphacoders.com/133/1337616.jpg', 'PG-13'),
('Ghosted', '4', '1h 56m', 'Cole falls head over heels for enigmatic Sadie, but then makes the shocking discovery that she''s a secret agent. Before they can decide on a second date, Cole and Sadie are swept away on an international 2 to save the world.', '2023', 5.8, 'https://m.media-amazon.com/images/M/MV5BNGMzYWZlYmYtNTcyMC00ZGVjLThjN2ItMjY4MjkwN2NlMjYwXkEyXkFqcGdeQXVyOTU0NjY1MDM@._V1_FMjpg_UX769_.jpg', 'https://static1.colliderimages.com/wordpress/wp-content/uploads/2023/02/ghosted-chris-evans-ana-de-armas.jpg', 'PG-13')
   
insert MovieStar(MovieId, StarId)
values
	('1', '1'),
	('2', '2'),
	('2', '3'),
	('3', '4'),
	('4', '5'),
	('5', '6'),
	('6', '7'),
	('7', '8'),
	('8', '9'),
	('9', '10'),
	('10', '11'),
	('11', '12'),
	('12', '13'),
	('13', '14'),
	('14', '15'),
	('15', '16'),
	('16', '17'),
	('17', '18'),
	('18', '19'),
	('19', '20'),
	('20', '21'),
	('21', '22'),
	('22', '23'),
	('23', '24'),
	('24', '25'),
	('25', '26'),
	('26', '27'),
	('27', '28'),
	('28', '29'),
	('29', '30'),
	('30', '31')

insert into MovieDirector(MovieId, DirectorId)
values
('1','1') ,
('2','2') ,
('3','3') ,
('4','4') ,
('5','5') ,
('6','6') ,
('7','7') ,
('8','8') ,
('9','9') ,
('10','10'),
('11','11'),
('12','12'),
('13','13'),
('14','14'),
('15','15'),
('16','16'),
('17','17'),
('18','18'),
('19','19'),
('20','20'),
('21','21'),
('22','22'),
('23','23'),
('24','24'),
('25','25'),
('26','26'),
('27','27'),
('28','28'),
('29','29'),
('30','30')

insert into Account(Role, Birthday, Username, Password)
values
('user', '1/1/2000 12:00:00 AM', 'un1', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'),
('admin', '1/1/2001 12:00:00 AM', 'ad1', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')

go

insert into MovieSchedule(IdMovie, IdSchedule, Date) values
(1, 1, '3/22/2024'),
(2, 3, '3/22/2024'),
(1, 7, '3/22/2024'),
(2, 2, '3/23/2024'),
(1, 5, '3/23/2024'),
(3, 7, '3/23/2024'),
(2, 3, '3/24/2024'),
(4, 5, '3/24/2024'),
(5, 7, '3/24/2024'),
(6, 2, '3/25/2024'),
(4, 4, '3/25/2024'),
(3, 6, '3/25/2024'),
(5, 7, '3/25/2024'),
(6, 1, '3/26/2024'),
(7, 3, '3/26/2024'),
(6, 5, '3/26/2024'),
(8, 7, '3/26/2024'),
(7, 3, '3/27/2024'),
(9, 5, '3/27/2024'),
(10, 7, '3/27/2024'),
(13, 2, '3/28/2024'),
(15, 4, '3/28/2024'),
(11, 1, '4/1/2024'),
(12, 4, '4/2/2024'),
(14, 5, '4/3/2024'),
(14, 1, '4/4/2024'),
(16, 7, '4/5/2024'),
(17, 3, '4/6/2024'),
(18, 7, '4/7/2024'),
(19, 2, '4/8/2024'),
(20, 6, '4/9/2024'),
(21, 1, '4/10/2024'),
(22, 2, '4/11/2024'),
(23, 5, '4/12/2024'),
(24, 2, '4/13/2024'),
(25, 1, '4/14/2024'),
(26, 2, '4/15/2024'),
(27, 5, '4/16/2024'),
(28, 6, '4/17/2024'),
(29, 5, '4/18/2024'),
(30, 3, '4/19/2024')

go

insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 16, 1, '03/1/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 7, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 12, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 19, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 14, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 6, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 9, 1, '03/1/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 5, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 12, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 16, 1, '03/1/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 7, 1, '03/1/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 13, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(13, 11, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(14, 12, 1, '03/1/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 6, 1, '03/2/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 8, 1, '03/2/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 2, 1, '03/2/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 15, 1, '03/2/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 13, 1, '03/2/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 11, 1, '03/2/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 14, 1, '03/2/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 14, 1, '03/2/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 5, 1, '03/2/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 14, 1, '03/2/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 22, 1, '03/3/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 13, 1, '03/3/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 16, 1, '03/3/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 20, 1, '03/3/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 3, 1, '03/4/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 21, 1, '03/4/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 7, 1, '03/4/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 16, 1, '03/4/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 20, 1, '03/4/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 21, 1, '03/4/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 20, 1, '03/4/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 8, 1, '03/4/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 12, 1, '03/4/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 10, 1, '03/4/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 13, 1, '03/5/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 7, 1, '03/5/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 12, 1, '03/5/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 1, 1, '03/5/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 21, 1, '03/5/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 11, 1, '03/5/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 20, 1, '03/5/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 7, 1, '03/5/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 15, 1, '03/6/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 20, 1, '03/6/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 22, 1, '03/6/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 7, 1, '03/6/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 20, 1, '03/6/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 16, 1, '03/6/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 21, 1, '03/6/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 18, 1, '03/6/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 13, 1, '03/6/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 13, 1, '03/6/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 5, 1, '03/6/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 1, 1, '03/7/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 11, 1, '03/7/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 19, 1, '03/7/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 1, 1, '03/7/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 16, 1, '03/7/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 14, 1, '03/7/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 20, 1, '03/7/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 18, 1, '03/7/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 4, 1, '03/7/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 2, 1, '03/7/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 17, 1, '03/7/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 10, 1, '03/7/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 3, 1, '03/8/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 22, 1, '03/8/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 10, 1, '03/8/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 1, 1, '03/8/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 12, 1, '03/8/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 17, 1, '03/8/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 1, 1, '03/8/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 12, 1, '03/8/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 3, 1, '03/8/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 21, 1, '03/8/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 12, 1, '03/8/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 16, 1, '03/8/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(13, 14, 1, '03/8/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(14, 10, 1, '03/8/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(15, 12, 1, '03/8/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(16, 17, 1, '03/8/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(17, 16, 1, '03/8/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(18, 7, 1, '03/8/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 19, 1, '03/9/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 1, 1, '03/9/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 14, 1, '03/9/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 16, 1, '03/9/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 13, 1, '03/9/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 7, 1, '03/9/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 14, 1, '03/9/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 17, 1, '03/9/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 5, 1, '03/9/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 4, 1, '03/9/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 5, 1, '03/9/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 3, 1, '03/10/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 12, 1, '03/10/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 18, 1, '03/10/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 8, 1, '03/10/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 6, 1, '03/10/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 7, 1, '03/10/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 14, 1, '03/10/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 1, 1, '03/10/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 18, 1, '03/10/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 1, 1, '03/10/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 21, 1, '03/10/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 11, 1, '03/10/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(13, 13, 1, '03/10/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 2, 1, '03/11/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 11, 1, '03/11/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 10, 1, '03/11/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 3, 1, '03/11/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 3, 1, '03/11/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 18, 1, '03/11/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 22, 1, '03/11/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 16, 1, '03/11/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 22, 1, '03/11/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 20, 1, '03/11/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 22, 1, '03/11/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 17, 1, '03/11/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(13, 7, 1, '03/11/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 6, 1, '03/12/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 12, 1, '03/12/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 21, 1, '03/12/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 20, 1, '03/12/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 7, 1, '03/12/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 10, 1, '03/12/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 5, 1, '03/12/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 5, 1, '03/12/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 7, 1, '03/12/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 5, 1, '03/12/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 5, 1, '03/12/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 13, 1, '03/12/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 4, 1, '03/13/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 18, 1, '03/13/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 1, 1, '03/13/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 13, 1, '03/13/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 13, 1, '03/13/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 13, 1, '03/13/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 10, 1, '03/13/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 2, 1, '03/13/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 19, 1, '03/13/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 18, 1, '03/14/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 7, 1, '03/14/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 14, 1, '03/14/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 9, 1, '03/14/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 2, 1, '03/14/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 20, 1, '03/15/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 9, 1, '03/15/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 11, 1, '03/15/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 4, 1, '03/15/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 22, 1, '03/15/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 7, 1, '03/15/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 4, 1, '03/16/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 4, 1, '03/16/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 3, 1, '03/16/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 2, 1, '03/16/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 17, 1, '03/17/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 12, 1, '03/17/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 7, 1, '03/17/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 14, 1, '03/17/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 19, 1, '03/17/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 1, 1, '03/17/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 4, 1, '03/17/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 15, 1, '03/17/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 22, 1, '03/17/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 21, 1, '03/17/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 1, 1, '03/17/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 11, 1, '03/18/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 10, 1, '03/18/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 2, 1, '03/18/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 10, 1, '03/18/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 17, 1, '03/18/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 13, 1, '03/19/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 7, 1, '03/19/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 14, 1, '03/19/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 9, 1, '03/19/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 9, 1, '03/19/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 9, 1, '03/19/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 11, 1, '03/19/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 2, 1, '03/19/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 17, 1, '03/20/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 15, 1, '03/20/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 14, 1, '03/20/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 15, 1, '03/20/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 14, 1, '03/20/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 22, 1, '03/20/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 5, 1, '03/20/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 19, 1, '03/20/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 11, 1, '03/20/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 20, 1, '03/20/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 18, 1, '03/20/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 16, 1, '03/20/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(13, 9, 1, '03/20/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(14, 9, 1, '03/20/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(15, 16, 1, '03/20/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 15, 1, '03/21/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 6, 1, '03/21/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 12, 1, '03/21/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 22, 1, '03/21/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 13, 1, '03/21/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 4, 1, '03/21/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 11, 1, '03/21/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 10, 1, '03/21/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 19, 1, '03/21/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 21, 1, '03/21/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 7, 1, '03/21/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 16, 1, '03/21/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 10, 1, '03/22/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 22, 1, '03/22/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 6, 1, '03/22/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 15, 1, '03/22/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 15, 1, '03/22/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 10, 1, '03/22/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 1, 1, '03/22/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 2, 1, '03/22/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 15, 1, '03/22/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 17, 1, '03/22/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 8, 1, '03/22/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 20, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 12, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 2, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 11, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 10, 1, '03/23/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 19, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 9, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 9, 1, '03/23/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 4, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 12, 1, '03/23/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 3, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 8, 1, '03/23/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(13, 21, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(14, 4, 1, '03/23/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(15, 8, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(16, 16, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(17, 11, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(18, 8, 1, '03/23/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(19, 20, 1, '03/23/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 20, 1, '03/24/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 21, 1, '03/24/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 3, 1, '03/24/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 21, 1, '03/24/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 1, 1, '03/24/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 9, 1, '03/24/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 10, 1, '03/24/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 11, 1, '03/24/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 15, 1, '03/24/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 18, 1, '03/24/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 11, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 21, 1, '03/25/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 19, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 12, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 18, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 15, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 2, 1, '03/25/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 12, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 7, 1, '03/25/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 6, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 11, 1, '03/25/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 15, 1, '03/25/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(13, 16, 1, '03/25/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(14, 6, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(15, 16, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(16, 4, 1, '03/25/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(17, 2, 1, '03/25/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(18, 6, 1, '03/25/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 21, 1, '03/26/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 20, 1, '03/26/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 13, 1, '03/26/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 3, 1, '03/26/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 21, 1, '03/27/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 13, 1, '03/27/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 18, 1, '03/27/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 16, 1, '03/27/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 1, 1, '03/27/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 10, 1, '03/27/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 8, 1, '03/27/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 18, 1, '03/27/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 5, 1, '03/27/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 8, 1, '03/28/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 10, 1, '03/28/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 13, 1, '03/28/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 1, 1, '03/28/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 13, 1, '03/28/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 10, 1, '03/28/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 16, 1, '03/28/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 11, 1, '03/28/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 12, 1, '03/28/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(10, 3, 1, '03/28/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(11, 13, 1, '03/28/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(12, 10, 1, '03/28/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(13, 6, 1, '03/28/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(14, 22, 1, '03/28/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(15, 6, 1, '03/28/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(16, 15, 1, '03/28/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(1, 15, 1, '03/29/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(2, 9, 1, '03/29/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(3, 20, 1, '03/29/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(4, 12, 1, '03/29/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(5, 1, 1, '03/29/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(6, 22, 1, '03/29/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(7, 12, 1, '03/29/2024', 81000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(8, 13, 1, '03/29/2024', 90000)
insert into Ticket(SeatId, MovieScheduleId, UserId, Date, Price) values(9, 12, 1, '03/29/2024', 90000)

