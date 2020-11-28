using BootcampLinq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BootcampLinq.ProjectLogic
{
    static class DatabaseUtilities
    {
        internal static DataSet GetDataQuery(string query)
        {
            DataSet dataset = new DataSet();
            try
            {

                using (SqlConnection connection = new SqlConnection("Server = .; Database = Bootcamp; Trusted_Connection = True;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            adapter.Fill(dataset);
                        }
                    }
                }
                return (dataset);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return (null);
            }
        }

        internal static void PrintAllStudents()
        {
            using (BootcampEntities context = new BootcampEntities())
            {
                try
                {
                    var query = from student in context.Students
                                select new
                                {
                                    ID = student.ID,
                                    FirstName = student.FirstName,
                                    LastName = student.LastName,
                                    DateOfBirth = student.DateOfBirth
                                };
                    Console.WriteLine("ID   First Name      Last Name       Date of Birth");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.ID,-5}{item.FirstName,-16}{item.LastName,-16}{item.DateOfBirth}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        internal static void PrintAllTrainers()
        {
            using (BootcampEntities context = new BootcampEntities())
            {
                try
                {
                    var query = from trainer in context.Trainers
                                select new
                                {
                                    ID = trainer.ID,
                                    FirstName = trainer.FirstName,
                                    LastName = trainer.LastName,
                                    Subject = trainer.CourseSubject
                                };
                    Console.WriteLine("ID   First Name      Last Name       Subjects");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.ID, -5}{item.FirstName, -16}{item.LastName, -16}{item.Subject}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        internal static void PrintAllAssignments()
        {
            using (BootcampEntities context = new BootcampEntities())
            {
                try
                {
                    var query = from assignment in context.Assignments
                                select new
                                {
                                    ID = assignment.ID,
                                    Title = assignment.Title,
                                    Description = assignment.AssignmentDescription,
                                    SubmissionDate = assignment.SubmissionDate,
                                    OralMark = assignment.OralMark,
                                    TotalMark = assignment.TotalMark
                                };
                    Console.WriteLine("ID   Title                    SubmissionDate OralMark  TotalMark");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.ID, -5}{item.Title, -25}{item.SubmissionDate, -15}{item.OralMark,-10}{item.TotalMark}");
                        Console.WriteLine("Description: " + item.Description);
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        internal static void PrintAllCourses()
        {
            using (BootcampEntities context = new BootcampEntities())
            {
                try
                {
                    var query = from course in context.Courses
                                select new 
                                {
                                    ID = course.ID,
                                    Title = course.Title,
                                    Stream = course.Stream,
                                    Type = course.CourseType,
                                    StartDate = course.StartDate,
                                    EndDate = course.EndDate
                                };
                    Console.WriteLine("ID   Title   Stream  Type        Start Date    End Date");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.ID, -5}{item.Title, -8}{item.Stream, -8}{item.Type, -12}{item.StartDate, -14}{item.EndDate}");
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        internal static void PrintStudentsPerCourse()
        {
            using (BootcampEntities context = new BootcampEntities())
            {
                try
                {
                    var query = from student in context.Students
                                join coursestudent in context.CourseStudents
                                on student.ID equals coursestudent.StudentID
                                join course in context.Courses
                                on coursestudent.CourseID equals course.ID
                                select new
                                {
                                    CourseID = course.ID,
                                    StudentID = student.ID,
                                    FirstName = student.FirstName,
                                    LastName = student.LastName,
                                    Title = course.Title,
                                    Stream = course.Stream,
                                    Type = course.CourseType
                                };
                    Console.WriteLine("Course ID  Title  Stream  Type        Student ID  First Name      Last Name");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.CourseID,-11}{item.Title,-7}{item.Stream,-8}{item.Type,-12}{item.StudentID,-12}{item.FirstName, -16}{item.LastName}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        internal static void PrintTrainersPerCourse()
        {
            using (BootcampEntities context = new BootcampEntities())
            {
                try
                {
                    var query = from trainer in context.Trainers
                                from course in context.Courses
                                where trainer.Courses.Any(x => x.ID == course.ID)
                                select new 
                                {
                                    CourseID = course.ID,
                                    TrainerID = trainer.ID,
                                    FirstName = trainer.FirstName,
                                    LastName = trainer.LastName,
                                    Title = course.Title,
                                    Stream = course.Stream,
                                    Type = course.CourseType
                                };


                    Console.WriteLine("Course ID  Title  Stream  Type        Student ID  First Name      Last Name");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.CourseID,-11}{item.Title,-7}{item.Stream,-8}{item.Type,-12}{item.TrainerID,-12}{item.FirstName,-16}{item.LastName}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        internal static void PrintAssignmentsPerCourse()
        {
            using (BootcampEntities context = new BootcampEntities())
            {
                try
                {
                    var query = from assignment in context.Assignments
                                join courseassignment in context.CourseAssignments
                                on assignment.ID equals courseassignment.AssignmentID
                                join course in context.Courses
                                on courseassignment.CourseID equals course.ID
                                select new
                                {
                                    CourseID = course.ID,
                                    AssignmentID = assignment.ID,
                                    AssignmentTitle = assignment.Title,
                                    CourseTitle = course.Title,
                                    Stream = course.Stream,
                                    Type = course.CourseType
                                };


                    Console.WriteLine("Course ID  Course Title  Stream  Type        Assignment ID  Assignment Title");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.CourseID,-11}{item.CourseTitle,-14}{item.Stream,-8}{item.Type,-12}{item.AssignmentID,-15}{item.AssignmentTitle}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        internal static void PrintAssignmentsPerCoursePerStudent()
        {
            using (BootcampEntities context = new BootcampEntities())
            {
                try
                {
                    var query = from student in context.Students
                                join coursestudent in context.CourseStudents
                                on student.ID equals coursestudent.StudentID
                                join course in context.Courses
                                on coursestudent.CourseID equals course.ID
                                select new
                                {
                                    CourseID = course.ID,
                                    StudentID = student.ID,
                                    FirstName = student.FirstName,
                                    LastName = student.LastName,
                                    Title = course.Title,
                                    Stream = course.Stream,
                                    Type = course.CourseType
                                };
                    Console.WriteLine("Course ID  Title  Stream  Type        Student ID  First Name      Last Name");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.CourseID,-11}{item.Title,-7}{item.Stream,-8}{item.Type,-12}{item.StudentID,-12}{item.FirstName,-16}{item.LastName}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        internal static void PrintStudentsWithMultipleCourses()
        {
            using (BootcampEntities context = new BootcampEntities())
            {
                try
                {
                    var query = from course in context.Courses
                                select new
                                {
                                    ID = course.ID,
                                    Title = course.Title,
                                    Stream = course.Stream,
                                    Type = course.CourseType,
                                    StartDate = course.StartDate,
                                    EndDate = course.EndDate
                                };
                    Console.WriteLine("ID   Title   Stream  Type        Start Date    End Date");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.ID,-5}{item.Title,-8}{item.Stream,-8}{item.Type,-12}{item.StartDate,-14}{item.EndDate}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }


        internal static void InsertStudent()
        {

        }

        internal static void InsertTrainer()
        {

        }

        internal static void InsertAssignment()
        {

        }

        internal static void InsertCourse()
        {

        }

        internal static void InsertStudentsPerCourse()
        {

        }

        internal static void InsertTrainersPerCourse()
        {

        }

        internal static void InsertAssignmentsPerStudentPerCourse()
        {

        }


        internal static void AssignStudent()
        {

        }

        internal static void AssignTrainer()
        {

        }

        internal static void AssignAssignment()
        {

        }

        internal static void AssignAssignmentToStudent()
        {

        }
    }
}
