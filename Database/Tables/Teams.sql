CREATE TABLE [dbo].[Teams]
(
	Id int not null constraint PK_Team primary key identity, 
	Gender varchar(6) not null, 
	Name varchar(100) not null, 
	RatingId int constraint FK_Team_Rating foreign key references Ratings(Id)
)
