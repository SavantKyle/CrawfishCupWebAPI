CREATE TABLE [dbo].[Players]
(
	Id int not null constraint PK_Player primary key identity, 
	FirstName varchar(50) not null, 
	LastName varchar(50) not null, 
	Email varchar(100) not null, 
	Phone varchar(15) not null, 
	RatingId int not null constraint FK_Player_Rating foreign key references Ratings(Id), 
	TeamId int not null constraint FK_Player_Team foreign key references Teams(Id) 
)
