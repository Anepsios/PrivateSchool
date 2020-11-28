using Bootcamp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Bootcamp.BussinessLogic
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
                        Console.WriteLine($"{item.ID,-5}{item.FirstName,-16}{item.LastName,-16}{item.Subject}");
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

        }

        internal static void PrintAllCourses()
        {

        }

        internal static void PrintStudentsPerCourse()
        {

        }

        internal static void PrintTrainersPerCourse()
        {

        }

        internal static void PrintAssignmentsPerCourse()
        {

        }

        internal static void PrintAssignmentsPerCoursePerStudent()
        {

        }

        internal static void PrintStudentsWithMultipleCourses()
        {

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
