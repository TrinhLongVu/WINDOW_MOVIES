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
    Title varchar(100),
    Runtime varchar(100),
    Rating varchar(100),
    Poster varchar(500),
	Landscape varchar(500),
    Certification varchar(100),
	Release varchar(100),
	Detail varchar(500)
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

create table Account(
	Id varchar(100),
	Username varchar(100),
	Password varchar(100)
	primary key (Id)
)

go

alter table MovieStar
add constraint FK_MVSTAR_STAR foreign key (StarId) references Star(Id),
    constraint FK_MVSTAR_MV   foreign key (MovieId) references Movie(Id)

alter table MovieDirector
add constraint FK_MVDIRECTOR_MV foreign key (MovieId) references Movie(Id),
	constraint FK_MVDIRECTOR_DIRECTOR foreign key (DirectorId) references Director(Id)

alter table MovieSchedule
add constraint FK_MVSCHEDULE_MV foreign key (IdSchedule) references Movie(Id),
	constraint FK_MVSCHEDULE_SCHEDULE foreign key (IdMovie) references Schedule(Id)

alter table Movie 
add constraint FK_GENRE foreign key (IdGener) references Genre(Id)

go

insert into Genre(Id, Name)
values
('1', 'Horror'),
('2', 'Adventure'),
('3', 'Action'),
('4', 'Romance'),
('5', 'Comedy'),
('6', 'Drama'),
('7', 'History')

insert into Movie(Id, Title, IdGener, Runtime, Detail, Release, Rating, Poster, Landscape, Certification) 
values 
	('1', 'Exhuma', '1', '2h 14m', 'Exhuma (2024) follows a wealthy family in LA haunted by a vengeful ancestor. Two young shamans, Hwa-rim and Bong-gil, are called in to appease the restless spirit. They discover the culprit is buried in a remote Korean village and enlist a geomancer and undertaker to exhume the grave. Unearthing the truth behind the ancestor''s anger unleashes a sinister force with horrifying consequences.', '2024', '7.4', 'https://m.media-amazon.com/images/M/MV5BOWNlMDQwY2MtNzFiMy00NDE3LThiNjctZDZmMDk3NzJhN2FkXkEyXkFqcGdeQXVyNjI4NDY5ODM@._V1_FMjpg_UY2142_.jpg', 'https://6.soompi.io/wp-content/uploads/image/20240202025900_exhuma.jpg', 'PG-16'),
	('2', 'Dune: Part Two', '2', '2h 46m', 'Picking up after the betrayal of House Harkonnen, Paul Atreides seeks revenge while embracing Fremen life on the desert planet Arrakis.  As his bond with Chani deepens, Paul takes on the Fremen mantle of Muad''Dib and leads daring raids against the spice harvesters. Facing a future filled with war and visions of a holy war, Paul must confront not only the remaining Harkonnens but also his own destiny as the Fremen''s messiah.', '2024', '8.9', 'https://m.media-amazon.com/images/M/MV5BN2QyZGU4ZDctOWMzMy00NTc5LThlOGQtODhmNDI1NmY5YzAwXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_FMjpg_UY4096_.jpg', 'https://pbs.twimg.com/media/GFLXqt4a8AAuI4n.jpg', 'PG-16'),
	('3', 'Wonka', '2', '1h 56m', 'Wonka isn''t a tale of golden tickets, but a prequel showing a young Willy Wonka fight poverty and a controlling chocolate industry to open his dream shop. Through fantastical inventions and newfound friendships, Willy overcomes these challenges, paving the way for the magical chocolate world encountered in Charlie and the Chocolate Factory.', '2024', '7.1', 'https://m.media-amazon.com/images/M/MV5BNDM4NTk0NjktZDJhMi00MmFmLTliMzEtN2RkZDY2OTNiMDgzXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY2048_.jpg', 'https://www.chattanoogapulse.com/downloads/27787/download/WONKA_TOS_EM_1920x1080.jpg?cb=6106e572bfe5d4343f83f30ad383fc2d&w=1920', 'PG'),
	('4', 'Damsel', '2', '1h 48m', 'Elodie, a kind woman raised in a harsh village, agrees to marry a prince to secure her people''s future. But the wedding turns out to be a cruel trick: the royal family sacrifices her to a fire-breathing dragon in a cave. With no knight in shining armor coming, Elodie must rely on her own wit and strength to survive the dragon''s lair and find a way to escape.', '2024', '6.3', 'https://m.media-amazon.com/images/M/MV5BNmEzOTE4NzktYWU4Ny00YTQ3LTlhNDEtMjNmNTg3NTRkMzNhXkEyXkFqcGdeQXVyMTMzNzIyNDc1._V1_FMjpg_UX450_.jpg', 'https://www.actvid.co.uk/wp-content/uploads/2024/02/Damsel.jpg', 'PG-13'),
	('5', 'Kung Fu Panda 4', '3', '1h 34m', 'After Po is tapped to become the Spiritual Leader of the Valley of Peace, he needs to find and train a new Dragon Warrior, while a wicked sorceress plans to re-summon all the master villains whom Po has vanquished to the spirit realm.', '2024', '6.8', 'https://m.media-amazon.com/images/M/MV5BZDY0YzI0OTctYjVhYy00MTVhLWE0NTgtYTRmYTBmOTE3YTViXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY5000_.jpg', 'https://vir.com.vn/stores/news_dataimages/2024/032024/11/15/new-kung-fu-panda-kicks-all-comers-to-top-namerica-box-office-20240311150902.jpg?rt=20240311150904', 'PG'),
	('6', 'Megamind vs. The Doom Syndicate', '3', '1h 23m', 'Megamind''s former villain team, The Doom Syndicate, has returned. Our newly crowned blue hero must now keep up evil appearances until he can assemble his friends to stop his former evil teammates from launching Metro City to the Moon.', '2024', '2.2', 'https://m.media-amazon.com/images/M/MV5BOGVkMmU1YWUtNmJlNi00ODJhLWI4NWMtMjY3YTA3MDJjOTVlXkEyXkFqcGdeQXVyMTk2OTAzNTI@._V1_FMjpg_UY3000_.jpg', 'https://i.kym-cdn.com/entries/icons/original/000/048/390/Megamind_vs_the_doom_syndicate_poster_parodies_banner_image.jpg', 'TV-G'),
	('7', 'Lisa Frankenstein', '4', '1h41m', 'A coming of RAGE love story about a teenager and her crush, who happens to be a corpse. After a set of horrific circumstances bring him back to life, the two embark on a journey to find love, happiness - and a few missing body parts.', '2024', '6.2', 'https://m.media-amazon.com/images/M/MV5BNjJkZDExMGQtNGE2YS00YzJiLWJiNjEtNmYwZjIxZGMxNTZiXkEyXkFqcGdeQXVyMjkwOTAyMDU@._V1_FMjpg_UY7466_.jpg', 'https://bouncenationkenya.com/wp-content/uploads/2024/01/Lisa-Frankenstein-Zelda-Williams-Diablo-Cody-horror-5-gets-a.jpg', 'PG-13'),
	('8', 'Code 8: Part II', '3', '1h 40m', 'Follows a girl fighting to get justice for her slain brother by corrupt police officers. She enlists the help of an ex-con and his former partner, they face a highly regarded and well protected police sergeant who doesn''t want to be.', '2024', '5.7', 'https://m.media-amazon.com/images/M/MV5BNmEyNzNlZjgtNzg1Zi00MTZjLWE5NGQtNDljNzUzYTJiODliXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY2222_.jpg', 'https://www.superherohype.com/wp-content/uploads/sites/4/2023/11/EN-US_Code8_P2_Teaser_Vertical_27x40_RGB_PRE-1.jpg', 'PG-16'),
	('9', 'Mean Girls', '5', '1h 52m', 'Cady Heron is a hit with the Plastics, an A-list girl clique at her new school. But everything changes when she makes the mistake of falling for Aaron Samuels, the ex-boyfriend of alpha Plastic Regina George.', '2024', '5.9', 'https://m.media-amazon.com/images/M/MV5BNDExMGMyN2QtYjRkZC00Yzk1LTkzMDktMTliZTI5NjQ0NTNkXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_FMjpg_UX1093_.jpg', 'https://i0.wp.com/stageberry.com/wp-content/uploads/2023/09/New-Mean-Girls-Movie-musical.jpg?fit=1920%2C1080&ssl=1', 'PG-13'),
	('10', 'Madame Web', '3', '1h 56m', 'Cassandra Webb is a New York metropolis paramedic who begins to demonstrate signs of clairvoyance. Forced to challenge revelations about her past, she needs to safeguard three young women from a deadly adversary who wants them destroyed.', '2024', '3.7', 'https://m.media-amazon.com/images/M/MV5BYWJkY2Q4NmYtOGRlMi00YTg5LWE2ZmQtY2NkYzk3YTRmNWZlXkEyXkFqcGdeQXVyMTY3ODkyNDkz._V1_FMjpg_UY2075_.jpg', 'https://images.squarespace-cdn.com/content/v1/51b3dc8ee4b051b96ceb10de/9273aaa5-7c6e-4dbf-b564-224247222d03/new-posters-released-for-the-spider-man-universe-film-madame-web.jpg', 'PG-13'),
	('11', 'Spider-Man: Across the Spider-Verse', '3', '2h 20m', 'Miles Morales catapults across the multiverse, where he encounters a team of Spider-People charged with protecting its very existence. When the heroes clash on how to handle a new threat, Miles must redefine what it means to be a hero.', '2023', '8.6', 'https://m.media-amazon.com/images/M/MV5BMzI0NmVkMjEtYmY4MS00ZDMxLTlkZmEtMzU4MDQxYTMzMjU2XkEyXkFqcGdeQXVyMzQ0MzA0NTM@._V1_FMjpg_UY1929_.jpg', 'https://images8.alphacoders.com/133/1335152.jpg', 'PG'),
	('12', 'Nimona', '3', '1h 41m', 'When a knight in a futuristic medieval world is framed for a crime he didn''t commit, the only one who can help him prove his innocence is Nimona -- a mischievous teen who happens to be a shapeshifting creature he''s sworn to destroy.', '2023', '7.5', 'https://m.media-amazon.com/images/M/MV5BMWYxZjNlMDUtZmFlYS00ZmUwLThkZDItZmQ4MWI4MThhNmEzXkEyXkFqcGdeQXVyMTA1OTcyNDQ4._V1_FMjpg_UY2222_.jpg', 'https://sportshub.cbsistatic.com/i/2023/06/14/89d8fb64-0f94-4c74-b26c-a68bdabaa278/nimona-movie-netflix-poster.jpg?auto=webp&width=1200&height=675&crop=1.778:1,smart', 'PG'),
	('13', 'The Boy and the Heron', '2', '2h 4m', 'In the wake of his mother''s death and his father''s remarriage, a headstrong boy named Mahito ventures into a dreamlike world shared by both the living and the dead.', '2024', '7.6', 'https://m.media-amazon.com/images/M/MV5BZjZkNThjNTMtOGU0Ni00ZDliLThmNGUtZmMxNWQ3YzAxZTQ1XkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY2194_.jpg', 'https://i.ytimg.com/vi/t5khm-VjEu4/maxresdefault.jpg', 'PG-13'),
	('14', 'Anyone But You', '4', '1h 43m', 'After an amazing first date, Bea and Ben''s fiery attr3 turns ice-cold--until they find themselves unexpectedly reunited at a wedding in Australia. So they do what any two mature adults would do: pretend to be a couple.', '2023', '6.2', 'https://m.media-amazon.com/images/M/MV5BOTVhZGU2OWQtNDM1Ni00MzM3LTgzYjgtOTEwYzQzOWZjNTIyXkEyXkFqcGdeQXVyMTcwOTQzOTYy._V1_FMjpg_UY3000_.jpg', 'https://s1.ticketm.net/dam/e/7ab/6510668e-867a-4acc-8e34-9a323534b7ab_RETINA_LANDSCAPE_16_9.jpg', 'R'),
	('15', 'Sixty Minutes', '3', '1h 28m', 'Desperate not to lose custody, a mixed martial arts fighter makes dangerous enemies when he ditches a matchup to race to his daughter''s birthday party.', '2024', '5.7', 'https://m.media-amazon.com/images/M/MV5BNWM3OTdhYjAtMDVlZC00ZDlhLTg2NWUtMTg4ZGFkYTM2YmIzXkEyXkFqcGdeQXVyMDYyODA2Mw@@._V1_FMjpg_UX450_.jpg', 'https://i.ytimg.com/vi/mRsMJs9juaQ/maxresdefault.jpg', 'PG-16'),
	('16', 'Lift', '3', '1h 47m', 'Follows a master thief and his Interpol Agent ex-girlfriend who team up to steal $500 million in gold bullion being transported on an A380 passenger flight.', '2024', '5.5', 'https://m.media-amazon.com/images/M/MV5BNTBlNmEwNzQtZTc5MC00YmVjLTk5NjgtMmM0NDFmZjJkZjYzXkEyXkFqcGdeQXVyNTE1NjY5Mg@@._V1_FMjpg_UX1014_.jpg', 'https://media.cnn.com/api/v1/images/stellar/prod/240109095636-lift-movie-netflix-kevin-hart.jpg?c=original', 'PG-13'),
	('17', 'The Marvels', '3', '1h 45m', 'Carol Danvers gets her powers entangled with those of Kamala Khan and Monica Rambeau, forcing them to work together to save the universe.', '2023', '5.6', 'https://m.media-amazon.com/images/M/MV5BM2U2YWU5NWMtOGI2Ni00MGMwLWFkNjItMjgyZWMxNjllNTMzXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_FMjpg_UY2500_.jpg', 'https://i.ebayimg.com/images/g/0hcAAOSwL1xkSECV/s-l1600.jpg', 'PG-13'),
	('18', 'Monster', '6', '2h 7m', 'A single mom named Saori notices her son Minato acting strangely after a fight at school. Suspecting his teacher, Mr. Hori, of abuse, Saori confronts the school but is met with resistance.', '2023', '7.9', 'https://m.media-amazon.com/images/M/MV5BMDY0YzNlZWQtOTZkOS00NGQ5LTkzYTYtOTg2OWJkYWJiMTVlXkEyXkFqcGdeQXVyMTEzMTI1Mjk3._V1_FMjpg_UX1107_.jpg', 'https://sashaymagazine.com/wp-content/uploads/2023/10/22Monster22-movie-poster.jpg', 'PG-13'),
    ('19', 'Ghostbusters: Frozen Empire', '2', '2h 5m', 'When the discovery of an ancient artifact unleashes an evil force, Ghostbusters new and old must join forces to protect their home and save the world from a second ice age.', '2024', '5.6', 'https://m.media-amazon.com/images/M/MV5BNGE5MWJmZWYtN2ZlMi00ZjY1LTlhYTUtMzQ2Y2IxZWQyYTA2XkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY3000_.jpg', 'https://assets-in.bmscdn.com/discovery-catalog/events/et00380545-jnuxmkycze-landscape.jpg', 'PG-13'),
    ('20', 'Argylle', '3', '2h 19m', 'A reclusive author who writes espionage novels about a secret agent and a global spy syndicate realizes the new book she''s writing starts to mirror real-world events, in real time.', '2024', '5.9', 'https://m.media-amazon.com/images/M/MV5BZDM3YTg4MGUtZmUxNi00YmEyLTllNTctNjYyNjZlZGViNmFhXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_FMjpg_UY5000_.jpg', 'https://www.chattanoogapulse.com/downloads/28126/download/01_ARG_WEB_THEATERS_GENERIC_1920X1080_DATED_RR_F01_010324.jpg?cb=70d13c3ade88e082fe3d7f967fea3e19', 'PG-13'),
    ('21', 'Imaginary', '1', '1h 44m', 'A woman returns to her childhood home to discover that the imaginary friend she left behind is very real and unhappy that she abandoned him.', '2024', '4.8', 'https://m.media-amazon.com/images/M/MV5BODIzOTJiODUtNzM2MC00YjdjLTg5YTktZWZhNjY1N2I5NWRjXkEyXkFqcGdeQXVyMjY5ODI4NDk@._V1_FMjpg_UY5000_.jpg', 'https://img.youtube.com/vi/8XoNfrgrAGM/maxresdefault.jpg', 'PG-13'),
    ('22', 'Insidious: The Red Door', '1', '1h 47m', 'Insidious: The Red Door (2023) reunites a broken Lambert family. Years after battling evil spirits in ''The Further'', Josh struggles to reconnect with his son Dalton, who starts having disturbing visions of a red door. When Dalton gets pulled back into The Further, Josh must confront his own repressed memories and a powerful demon to save his son and finally seal the gateway between worlds.', '2023', '5.5', 'https://m.media-amazon.com/images/M/MV5BOTQyNGY5ZGQtN2E1MC00ZDhkLWJiYWMtMTFjODAwMDFmZDRhXkEyXkFqcGdeQXVyMDc5ODIzMw@@._V1_FMjpg_UX604_.jpg', 'https://assets-in.bmscdn.com/discovery-catalog/events/et00357727-sjgpeajymm-landscape.jpg', 'PG-13'),
    ('23', 'No Way Up', '2', '1h 30m', 'Characters from different backgrounds are thrown together when the plane they''re travelling on crashes into the Pacific Ocean. A nightmare fight for survival ensues with the air supply running out and dangers creeping in from all sides.', '2024', '4.5', 'https://m.media-amazon.com/images/M/MV5BMTEyOTQzZjgtMDM1OC00MWMxLWI2ZGUtYWUwOTQxNTRmZTU0XkEyXkFqcGdeQXVyNTU1MDIzMzg@._V1_FMjpg_UX696_.jpg', 'https://i.ytimg.com/vi/TFO9nzKCa2I/maxresdefault.jpg', 'PG-13'),
    ('24', 'Avatar: The Way of Water', '2', '3h 12m', 'Jake Sully lives with his newfound family formed on the extrasolar moon Pandora. Once a familiar threat returns to finish what was previously started, Jake must work with Neytiri and the army of the Na''vi race to protect their home.', '2022', '7.6', 'https://m.media-amazon.com/images/M/MV5BYjhiNjBlODctY2ZiOC00YjVlLWFlNzAtNTVhNzM1YjI1NzMxXkEyXkFqcGdeQXVyMjQxNTE1MDA@._V1_FMjpg_UX900_.jpg', 'https://img1.wsimg.com/isteam/ip/d6a3e7a7-e920-4711-bf09-856dd846af78/AVATAR2.jpg', 'PG-13'),
    ('25', 'Barbie', '2', '1h 54m', 'Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.', '2023', '6.9', 'https://m.media-amazon.com/images/M/MV5BNjU3N2QxNzYtMjk1NC00MTc4LTk1NTQtMmUxNTljM2I0NDA5XkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_FMjpg_UY2814_.jpg', 'https://staticg.sportskeeda.com/editor/2023/07/cec24-16884422905142-1920.jpg', 'PG-13'),
    ('26', 'Oppenheimer', '7', '3h', 'Christopher Nolan''s ''Oppenheimer'' (2023) explores the life of J. Robert Oppenheimer, the father of the atomic bomb. It weaves between his rise to scientific fame leading the Manhattan Project, the moral complexities of creating such a destructive weapon, and his later fall from grace due to suspected communist ties. The film delves into the personal and ethical struggles of a brilliant mind forever changed by ushering in the nuclear age.', '2023', '8.4', 'https://m.media-amazon.com/images/M/MV5BMDBmYTZjNjUtN2M1MS00MTQ2LTk2ODgtNzc2M2QyZGE5NTVjXkEyXkFqcGdeQXVyNzAwMjU2MTY@._V1_FMjpg_UY3454_.jpg', 'https://thecollision.org/wp-content/uploads/2023/07/2-2.jpeg', 'R'),
    ('27', 'Meg 2: The Trench', '1', '1h 56m', 'In Meg 2: The Trench (2023), Jonas Taylor and a research team on a deep-sea dive encounter a hidden mining operation disturbing a Mariana Trench ecosystem teeming with Megalodons, giant prehistoric sharks. The situation escalates as the team gets caught between the colossal predators and ruthless miners, forcing them to fight for survival and uncover a shocking secret about the mining operation''s true motives.', '2023', '5.0', 'https://m.media-amazon.com/images/M/MV5BMTM2NTU1ZTktNjc4YS00NjNhLWE4NmYtOTM2YjFjOGUzNmYzXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_FMjpg_UY3000_.jpg', 'https://talkiescorner.com/wp-content/uploads/2023/08/Meg-2-The-Trench-Movie-Review.webp', 'PG-13'),
    ('28', 'The Last Voyage of the Demeter', '1', '1h 58m', 'The Demeter, a merchant ship, sets sail from Eastern Europe for London carrying mysterious cargo. As the voyage progresses, the crew dwindles under mysterious circumstances. It turns out they''re not alone - the legendary vampire Dracula is aboard, feeding on the crew and turning the journey into a terrifying fight for survival.', '2023', '6.1', 'https://m.media-amazon.com/images/M/MV5BOTljMzRkNDItNjYxYS00ODA4LThiZjYtMjI0MTFjODlmMGJmXkEyXkFqcGdeQXVyNzU0NzQxNTE@._V1_FMjpg_UY6000_.jpg', 'https://m.media-amazon.com/images/S/pv-target-images/bd9d8f54c54038849e098c424a2d5887fdcbc64988b29ef3b33d51e5f710c9ee.jpg', 'R'),
    ('29', 'Mission: Impossible - Dead Reckoning Part One', '3', '2h 43m', 'Ethan Hunt and his IMF team race against time to find a deadly weapon - a powerful AI program called the Entity - controlled by a two-part key.  The mission takes them around the globe, from rescuing a key fragment from a disavowed agent to a high-stakes chase in Abu Dhabi. Facing a mysterious enemy and double-crosses, Ethan must decide who to trust as he tries to destroy the Entity before it falls into the wrong hands.', '2023', '7.7', 'https://m.media-amazon.com/images/M/MV5BYzFiZjc1YzctMDY3Zi00NGE5LTlmNWEtN2Q3OWFjYjY1NGM2XkEyXkFqcGdeQXVyMTUyMTUzNjQ0._V1_FMjpg_UX695_.jpg', 'https://images8.alphacoders.com/133/1337616.jpg', 'PG-13'),
    ('30', 'Ghosted', '4', '1h 56m', 'Cole falls head over heels for enigmatic Sadie, but then makes the shocking discovery that she''s a secret agent. Before they can decide on a second date, Cole and Sadie are swept away on an international 2 to save the world.', '2023', '5.8', 'https://m.media-amazon.com/images/M/MV5BNGMzYWZlYmYtNTcyMC00ZGVjLThjN2ItMjY4MjkwN2NlMjYwXkEyXkFqcGdeQXVyOTU0NjY1MDM@._V1_FMjpg_UX769_.jpg', 'https://static1.colliderimages.com/wordpress/wp-content/uploads/2023/02/ghosted-chris-evans-ana-de-armas.jpg', 'PG-13')
    
