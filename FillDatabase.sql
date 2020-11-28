use Bootcamp;

insert into Courses (Title, Stream, CourseType, StartDate, EndDate) values ('CB12','C#', 'Full Time', '2020/1/1', '2020/3/1');
insert into Courses (Title, Stream, CourseType, StartDate, EndDate) values ('CB12','C#', 'Part Time', '2020/1/1', '2020/6/1');
insert into Courses (Title, Stream, CourseType, StartDate, EndDate) values ('CB12','Java', 'Full Time', '2020/1/1', '2020/3/1');
insert into Courses (Title, Stream, CourseType, StartDate, EndDate) values ('CB12','Java', 'Part Time', '2020/1/1', '2020/6/1');



insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('C# ConsoleApp1','The first project', '2020/1/10', 20, 80);
insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('C# IndividualProject1','The individual semester project', '2020/2/1', 20, 80);
insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('C# GroupProject','The last group project', '2020/3/1', 20, 80);

insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('C# ConsoleApp1','The first project for part time class', '2020/2/1', 20, 80);
insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('C# IndividualProject1','The individual semester project for part time class', '2020/4/1', 20, 80);
insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('C# GroupProject','The last group project for part time class', '2020/6/1', 20, 80);

insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('Java ConsoleApp1','The first project', '2020/1/10', 20, 80);
insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('Java IndividualProject1','The individual semester project', '2020/2/1', 20, 80);
insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('Java GroupProject','The last group project', '2020/3/1', 20, 80);

insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('Java ConsoleApp1','The first project for part time class', '2020/2/1', 20, 80);
insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('Java IndividualProject1','The individual semester project for part time class', '2020/3/1', 20, 80);
insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values ('Java GroupProject','The last group project for part time class', '2020/6/1', 20, 80);

insert into CourseAssignments (CourseID, AssignmentID) values (1, 1);
insert into CourseAssignments (CourseID, AssignmentID) values (1, 2);
insert into CourseAssignments (CourseID, AssignmentID) values (1, 3);
insert into CourseAssignments (CourseID, AssignmentID) values (2, 4);
insert into CourseAssignments (CourseID, AssignmentID) values (2, 5);
insert into CourseAssignments (CourseID, AssignmentID) values (2, 6);
insert into CourseAssignments (CourseID, AssignmentID) values (3, 7);
insert into CourseAssignments (CourseID, AssignmentID) values (3, 8);
insert into CourseAssignments (CourseID, AssignmentID) values (3, 9);
insert into CourseAssignments (CourseID, AssignmentID) values (4, 10);
insert into CourseAssignments (CourseID, AssignmentID) values (4, 11);
insert into CourseAssignments (CourseID, AssignmentID) values (4, 12);



insert into Trainers (FirstName, LastName, CourseSubject) values ('Takis','Roumba', 'C#');
insert into Trainers (FirstName, LastName, CourseSubject) values ('Makis','Mak', 'C#');
insert into Trainers (FirstName, LastName, CourseSubject) values ('Sakis','Soyer', 'C#, SQL');
insert into Trainers (FirstName, LastName, CourseSubject) values ('Pakis','Preos', 'Java');
insert into Trainers (FirstName, LastName, CourseSubject) values ('Lakis','Lalos', 'Java');
insert into Trainers (FirstName, LastName, CourseSubject) values ('Akis','Aravias', 'Javascript');

insert into CourseTrainers (CourseID, TrainerID) values (1, 1);
insert into CourseTrainers (CourseID, TrainerID) values (1, 2);
insert into CourseTrainers (CourseID, TrainerID) values (2, 1);
insert into CourseTrainers (CourseID, TrainerID) values (2, 3);
insert into CourseTrainers (CourseID, TrainerID) values (3, 4);
insert into CourseTrainers (CourseID, TrainerID) values (4, 5);



insert into Students (FirstName, LastName, DateOfBirth) values ('Sakil','Oneal', getdate());
insert into Students (FirstName, LastName, DateOfBirth) values ('Ben','Dover', getdate());
insert into Students (FirstName, LastName, DateOfBirth) values ('Papi','Chulo', getdate());
insert into Students (FirstName, LastName, DateOfBirth) values ('Cypress','Hill', getdate());
insert into Students (FirstName, LastName, DateOfBirth) values ('Machine','Head', getdate());
insert into Students (FirstName, LastName, DateOfBirth) values ('Bob','Dylan', getdate());
insert into Students (FirstName, LastName, DateOfBirth) values ('Bob','Marley', getdate());
insert into Students (FirstName, LastName, DateOfBirth) values ('Ale3hs','Tsipras', getdate());
insert into Students (FirstName, LastName, DateOfBirth) values ('Blue','PowerRanger', getdate());
insert into Students (FirstName, LastName, DateOfBirth) values ('Hu','Emai', getdate());

insert into CourseStudents (CourseID, StudentID) values (1, 1);
insert into CourseStudents (CourseID, StudentID) values (1, 2);
insert into CourseStudents (CourseID, StudentID) values (1, 3);
insert into CourseStudents (CourseID, StudentID) values (2, 4);
insert into CourseStudents (CourseID, StudentID) values (2, 5);
insert into CourseStudents (CourseID, StudentID) values (2, 6);
insert into CourseStudents (CourseID, StudentID) values (3, 6);
insert into CourseStudents (CourseID, StudentID) values (3, 7);
insert into CourseStudents (CourseID, StudentID) values (3, 8);
insert into CourseStudents (CourseID, StudentID) values (3, 9);
insert into CourseStudents (CourseID, StudentID) values (4, 10);
insert into CourseStudents (CourseID, StudentID) values (4, 1);


insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (1, 1, 1, 1, 19, 78);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (1, 1, 2, 1, 18, 65);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (1, 1, 3, 1, 15, 45);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (1, 2, 1, 1, 11, 80);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (1, 2, 2, 1, 18, 78);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (1, 2, 3, 1, 17, 75);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (1, 3, 1, 1, 15, 79);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (1, 3, 2, 1, 16, 45);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (1, 3, 3, 1, 15, 64);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (2, 4, 4, 1, 10, 56);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (2, 4, 5, 1, 10, 46);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (2, 4, 6, 1, 14, 65);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (2, 5, 4, 1, 17, 57);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (2, 5, 5, 1, 18, 56);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (2, 5, 6, 1, 17, 58);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (2, 6, 4, 1, 19, 52);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (2, 6, 5, 1, 19, 42);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (2, 6, 6, 1, 19, 76);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 6, 7, 1, 16, 73);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 6, 8, 1, 14, 71);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 6, 9, 1, 18, 74);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 7, 7, 1, 19, 71);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 7, 8, 1, 14, 59);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 7, 9, 1, 18, 63);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 8, 7, 1, 15, 68);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 8, 8, 1, 12, 61);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 8, 9, 1, 17, 65);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 9, 7, 1, 19, 45);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 9, 8, 1, 18, 58);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (3, 9, 9, 1, 12, 72);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (4, 10, 10, 1, 14, 77);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (4, 10, 11, 1, 15, 65);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (4, 10, 12, 1, 17, 53);

insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (4, 1, 10, 1, 18, 58);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (4, 1, 11, 1, 19, 52);
insert into StudentAssignments (CourseID, StudentID, AssignmentID, Submitted, OralMark, TotalMark) values (4, 1, 12, 1, 11, 75);
