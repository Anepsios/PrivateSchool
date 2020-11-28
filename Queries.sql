use Bootcamp;


-- Output a list of all students

select * from Students order by ID;


--Output a list of all trainers

select * from Trainers;


--Output a list of all assignments

select * from Assignments order by ID;


--Output a list of all courses

select * from Courses order by ID;


--Output all the students per course

select Courses.ID as CourseID, Courses.Title, Courses.Stream, Courses.CourseType, Students.ID as StudentID, Students.FirstName, Students.LastName from Students
inner join CourseStudents
on Students.ID = CourseStudents.StudentID
inner join Courses
on CourseStudents.CourseID = Courses.ID
order by Courses.ID;


--Output all the trainers per course

select Courses.ID as CourseID, Courses.Title, Courses.Stream, Courses.CourseType, Trainers.ID as TrainerID, Trainers.FirstName, Trainers.LastName, Trainers.CourseSubject from Trainers
inner join CourseTrainers
on Trainers.ID = CourseTrainers.TrainerID
inner join Courses
on CourseTrainers.CourseID = Courses.ID
order by Courses.ID;


--Output all the assignments per course

select Courses.ID as CourseID, Courses.Title, Courses.Stream, Courses.CourseType, Assignments.ID as AssignmentID, Assignments.Title, Assignments.AssignmentDescription, Assignments.SubmissionDate, Assignments.OralMark, Assignments.TotalMark from Assignments
inner join CourseAssignments
on Assignments.ID = CourseAssignments.AssignmentID
inner join Courses
on CourseAssignments.CourseID = Courses.ID
order by Courses.ID;


--Output all the assignments per course per student

select distinct Students.ID as StudentID, Students.FirstName, Students.LastName, Courses.ID as CourseID, Courses.Title, Courses.Stream, Courses.CourseType, Assignments.ID as AssignmentID, Assignments.Title, Assignments.AssignmentDescription, Assignments.SubmissionDate, StudentAssignments.OralMark, StudentAssignments.TotalMark from StudentAssignments
inner join Assignments
on StudentAssignments.AssignmentID = Assignments.ID
inner join Students
on StudentAssignments.StudentID = Students.ID
inner join Courses
on StudentAssignments.CourseID = Courses.ID
order by Students.ID, Courses.ID;

--Output a list of students that belong to more that one courses

select Students.ID, Students.FirstName, Students.LastName from CourseStudents 
inner join Students
on CourseStudents.StudentID = Students.ID
group by Students.ID, Students.FirstName, Students.LastName
having count(*) > 1;