create database Bootcamp;
go

use Bootcamp;

create table Courses 
	(
	ID int not null primary key identity(1,1),
	Title varchar(255) not null,
	Stream varchar(255) not null,
	CourseType varchar(255) not null,
	StartDate date not null,
	EndDate date not null
	);


create table Trainers 
	(
	ID int not null primary key identity(1,1),
	FirstName varchar(255) not null,
	LastName varchar(255) not null,
	CourseSubject varchar(255) not null
	unique (FirstName, LastName)
	);

create table CourseTrainers
	(
	CourseID int not null foreign key references Courses(ID),
	TrainerID int not null foreign key references Trainers(ID),
	primary key (CourseID, TrainerID)
	);


create table Students 
	(
	ID int not null primary key identity(1,1),
	FirstName varchar(255) not null,
	LastName varchar(255) not null,
	DateOfBirth date not null,
	unique (FirstName, LastName)
	);

create table CourseStudents
	(
	CourseID int not null foreign key references Courses(ID),
	StudentID int not null foreign key references Students(ID),
	primary key (CourseID, StudentID)
	);


create table Assignments
	(
	ID int not null primary key identity(1,1),
	Title varchar(255) not null,
	AssignmentDescription varchar(1000),
	SubmissionDate date not null,
	OralMark int not null,
	TotalMark int not null
	);

create table CourseAssignments
	(
	CourseID int not null foreign key references Courses(ID),
	AssignmentID int not null foreign key references Assignments(ID),
	primary key (CourseID, AssignmentID)
	);

create table StudentAssignments
	(
	CourseID int not null,
	StudentID int not null,
	AssignmentID int not null,
	Submitted bit not null,
	OralMark int,
	TotalMark int,
	primary key (CourseID, StudentID, AssignmentID),
	foreign key (CourseID, StudentID) references CourseStudents(CourseID, StudentID),
	foreign key (CourseID, AssignmentID) references CourseAssignments(CourseID, AssignmentID)
	);
