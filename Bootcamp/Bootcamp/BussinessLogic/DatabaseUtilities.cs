using Bootcamp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bootcamp.BussinessLogic
{
    static class DatabaseUtilities
    {
        internal static void PrintDataQuery(string query, string printMessage)
        {
            int count = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection("Server = .; DataBase = Bootcamp; Trusted_Connection = True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                Console.WriteLine(printMessage + "\n");
                                while (reader.Read())
                                {
                                    Console.WriteLine($"({count})");
                                    count++;
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write($"{reader.GetName(i),-25}: ");
                                        Console.WriteLine($"{reader[i]}");
                                    }
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\n");
            }
        }

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
        internal static DataSet GetDataQuery(string query, int courseid)
        {
            // Same as base method, only  modified to specifically use the SQL variable @CourseID
            // Shame on me for making a whole new method and not finding a more elegant way to solve this
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
                            command.Parameters.AddWithValue("@CourseID", courseid);
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
            Console.WriteLine();
            string printMessage = "Printing a list of all the students:";
            string query = "select * from Students order by ID;";
            PrintDataQuery(query, printMessage);
        }

        internal static void PrintAllTrainers()
        {
            Console.WriteLine();
            string printMessage = "Printing a list of all the trainers:";
            string query = "select * from Trainers order by ID;";
            PrintDataQuery(query, printMessage);
        }

        internal static void PrintAllAssignments()
        {
            Console.WriteLine();
            string printMessage = "Printing a list of all the assignments:";
            string query = "select * from Assignments order by ID;";
            PrintDataQuery(query, printMessage);
        }

        internal static void PrintAllCourses()
        {
            Console.WriteLine();
            string printMessage = "Printing a list of all the courses:";
            string query = "select * from Courses order by ID;";
            PrintDataQuery(query, printMessage);
        }

        internal static void PrintStudentsPerCourse()
        {
            Console.WriteLine();
            string printMessage = "Printing all the students per course:";
            string query = "select Courses.ID as CourseID, Courses.Title, Courses.Stream, Courses.CourseType, Students.ID as StudentID, Students.FirstName, Students.LastName " +
                           "from Students " +
                           "inner join CourseStudents " +
                           "on Students.ID = CourseStudents.StudentID " +
                           "inner join Courses " +
                           "on CourseStudents.CourseID = Courses.ID " +
                           "order by Courses.ID;";
            PrintDataQuery(query, printMessage);
        }

        internal static void PrintTrainersPerCourse()
        {
            Console.WriteLine();
            string printMessage = "Printing all the trainers per course:";
            string query = "select Courses.ID as CourseID, Courses.Title, Courses.Stream, Courses.CourseType, Trainers.ID as TrainerID, Trainers.FirstName, Trainers.LastName, Trainers.CourseSubject " +
                           "from Trainers " +
                           "inner join CourseTrainers " +
                           "on Trainers.ID = CourseTrainers.TrainerID " +
                           "inner join Courses " +
                           "on CourseTrainers.CourseID = Courses.ID " +
                           "order by Courses.ID;";
            PrintDataQuery(query, printMessage);
        }

        internal static void PrintAssignmentsPerCourse()
        {
            Console.WriteLine();
            string printMessage = "Printing all the assignments per course:";
            string query = "select Courses.ID as CourseID, Courses.Title, Courses.Stream, Courses.CourseType, Assignments.ID as AssignmentID, Assignments.Title, Assignments.AssignmentDescription, Assignments.SubmissionDate, Assignments.OralMark, Assignments.TotalMark " +
                           "from Assignments " +
                           "inner join CourseAssignments " +
                           "on Assignments.ID = CourseAssignments.AssignmentID " +
                           "inner join Courses " +
                           "on CourseAssignments.CourseID = Courses.ID " +
                           "order by Courses.ID;";
            PrintDataQuery(query, printMessage);
        }

        internal static void PrintAssignmentsPerCoursePerStudent()
        {
            Console.WriteLine();
            string printMessage = "Printing all the assignments per course per student:";
            string query = "select distinct Students.ID as StudentID, Students.FirstName, Students.LastName, Courses.ID as CourseID, Courses.Title, Courses.Stream, Courses.CourseType, Assignments.ID as AssignmentID, Assignments.Title, Assignments.AssignmentDescription, Assignments.SubmissionDate, StudentAssignments.OralMark, StudentAssignments.TotalMark from StudentAssignments " +
                "inner join Assignments " +
                "on StudentAssignments.AssignmentID = Assignments.ID " +
                "inner join Students " +
                "on StudentAssignments.StudentID = Students.ID " +
                "inner join Courses " +
                "on StudentAssignments.CourseID = Courses.ID " +
                "order by Students.ID, Courses.ID;";

            PrintDataQuery(query, printMessage);
        }

        internal static void PrintStudentsWithMultipleCourses()
        {
            Console.WriteLine();
            string printMessage = "Printing a list of students that belong to more than one courses:";
            string query = "select Students.ID as StudentID, Students.FirstName, Students.LastName from CourseStudents " +
                "inner join Students " +
                "on CourseStudents.StudentID = Students.ID " +
                "group by Students.ID, Students.FirstName, Students.LastName " +
                "having count(*) > 1;";
            PrintDataQuery(query, printMessage);
        }


        internal static void InsertStudent(Student student)
        {
            // Insert Student class object in Students table in database
            // Possible extension: Assign student to a course?

            string query = "insert into Students (FirstName, LastName, DateOfBirth) values (@FirstName, @LastName, @DateOfBirth)";
            try
            {
                using (SqlConnection connection = new SqlConnection("Server = .; Database = Bootcamp; Trusted_Connection = True;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", student.FirstName);
                        command.Parameters.AddWithValue("@LastName", student.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                        command.ExecuteNonQuery();
                        Console.WriteLine("\nStudent added successfully\n");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        internal static void InsertStudent(Student student, out bool success)
        {
            // Insert Student class object in Students table in database
            // and return true/false if operation succeded

            string query = "insert into Students (FirstName, LastName, DateOfBirth) values (@FirstName, @LastName, @DateOfBirth)";
            try
            {
                using (SqlConnection connection = new SqlConnection("Server = .; Database = Bootcamp; Trusted_Connection = True;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", student.FirstName);
                        command.Parameters.AddWithValue("@LastName", student.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                        command.ExecuteNonQuery();
                        Console.WriteLine("\nStudent added successfully\n");
                        success = true;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                success = false;
            }
        }

        internal static void InsertTrainer(Trainer trainer)
        {
            // Insert Trainer class object in Trainers table in database
            // Possible extension: Assign trainer to a course?

            string query = "insert into Trainers (FirstName, LastName, CourseSubject) values (@FirstName, @LastName, @Subjects)";
            try
            {
                using (SqlConnection connection = new SqlConnection("Server = .; Database = Bootcamp; Trusted_Connection = True;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", trainer.FirstName);
                        command.Parameters.AddWithValue("@LastName", trainer.LastName);
                        command.Parameters.AddWithValue("@Subjects", trainer.Subjects);
                        command.ExecuteNonQuery();
                        Console.WriteLine("\nTrainer added successfully\n");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        internal static void InsertTrainer(Trainer trainer, out bool success)
        {
            // Insert Trainer class object in Trainers table in database
            // and return true/false if operation succeded

            string query = "insert into Trainers (FirstName, LastName, CourseSubject) values (@FirstName, @LastName, @Subjects)";
            List<string> subjectToAdd = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection("Server = .; Database = Bootcamp; Trusted_Connection = True;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", trainer.FirstName);
                        command.Parameters.AddWithValue("@LastName", trainer.LastName);
                        command.Parameters.AddWithValue("@Subjects", trainer.Subjects);
                        command.ExecuteNonQuery();
                        Console.WriteLine("\nTrainer added successfully\n");
                        success = true;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                success = false;
            }
        }

        internal static void InsertAssignment(Assignment assignment)
        {
            // Insert Assignment class object in Assignments table in database
            // Possible extension: Assign assignment to a course? Then to courses students?

            string query = "insert into Assignments (Title, AssignmentDescription, SubmissionDate, OralMark, TotalMark) values (@Title, @Description, @SubmissionDate, @OralMark, @TotalMark)";
            try
            {
                using (SqlConnection connection = new SqlConnection("Server = .; Database = Bootcamp; Trusted_Connection = True;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", assignment.Title);
                        command.Parameters.AddWithValue("@Description", assignment.Description);
                        command.Parameters.AddWithValue("@SubmissionDate", assignment.SubDate);
                        command.Parameters.AddWithValue("@OralMark", assignment.OralMark);
                        command.Parameters.AddWithValue("@TotalMark", assignment.TotalMark);
                        command.ExecuteNonQuery();
                        Console.WriteLine("\nAssignment added successfully\n");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        internal static void InsertCourse(Course course)
        {
            string query = "insert into Courses (Title, Stream, CourseType, StartDate, EndDate) values (@Title, @Stream, @Type, @StartDate, @EndDate)";
            try
            {
                using (SqlConnection connection = new SqlConnection("Server = .; Database = Bootcamp; Trusted_Connection = True;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", course.Title);
                        command.Parameters.AddWithValue("@Stream", course.Stream);
                        command.Parameters.AddWithValue("@Type", course.Type);
                        command.Parameters.AddWithValue("@StartDate", course.StartDate);
                        command.Parameters.AddWithValue("@EndDate", course.EndDate);
                        command.ExecuteNonQuery();
                        Console.WriteLine("\nCourse added successfully\n");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        internal static void InsertStudentsPerCourse()
        {
            /* Unexpected bug/feature with base InsertStudent method: 
             * If object(student) that was input already exists but had not be previously assigned
             * to another object(course), then it will be assigned to the selected object(course).
             * Possible future extension: option to assign existing student to course */

            // Description: Iterate through each course getting its ID(courseid), and input student,
            // then get the ID(studentid) from the student that was just added 
            // and assign him to Course using the CourseStudents table

            string query = "select * from Courses;";
            DataSet courses = GetDataQuery(query);
            Student student;
            int courseid;
            int studentid = 0;
            bool studentInserted;

            for (int i = 0; i < courses.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine("Do you want to add students to {0} {1} {2}? (y/n)",
                                   courses.Tables[0].Rows[i].ItemArray[1], courses.Tables[0].Rows[i].ItemArray[2], courses.Tables[0].Rows[i].ItemArray[3]);
                if (Console.ReadLine() != "y")
                    continue;
                courseid = (int)courses.Tables[0].Rows[i].ItemArray[0];
                do
                {
                    InsertStudent(student = new Student(), out studentInserted);
                    if (studentInserted)
                    {
                        try
                        {
                            using (SqlConnection connection = new SqlConnection("Server = .; DataBase = Bootcamp; Trusted_Connection = True"))
                            {
                                connection.Open();
                                query = "select ID from Students where FirstName = @FirstName and LastName = @LastName;"; // ("select ID from Students order by ID desc limit 1;") would also work but let's keep it safe"
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                                    command.Parameters.AddWithValue("@LastName", student.LastName);
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            studentid = reader.GetInt32(0);
                                        }
                                    }
                                }
                                query = "insert into CourseStudents (CourseID, StudentID) values (@CourseID, @StudentID);";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@CourseID", courseid);
                                    command.Parameters.AddWithValue("@StudentID", studentid);
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("Student assigned to course\n");
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    Console.WriteLine("Do you want to add another student to {0} {1} {2}? (y/n)",
                                      courses.Tables[0].Rows[i].ItemArray[1], courses.Tables[0].Rows[i].ItemArray[2], courses.Tables[0].Rows[i].ItemArray[3]);
                } while (Console.ReadLine() == "y");
            }
        }

        internal static void InsertTrainersPerCourse()
        {
            /* Unexpected bug/feature with base InsertTrainer method: 
            * If object(trainer) that was input already exists but had not be previously assigned
            * to another object(course), then it will be assigned to the selected object(course) 
            * Possible future extension: option to assign existing student to course */

            // Description: Iterate through each course getting its ID(courseid) and input trainer,
            // then get the ID(trainerid) from the trainer that was just added 
            // and assign him to Course using the CourseTrainers table

            string query = "select * from Courses;";
            DataSet courses = GetDataQuery(query);
            Trainer trainer;
            int courseid;
            int trainerid = 0;
            bool trainerInserted;

            for (int i = 0; i < courses.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine("Do you want to add trainers to {0} {1} {2}? (y/n)",
                                   courses.Tables[0].Rows[i].ItemArray[1], courses.Tables[0].Rows[i].ItemArray[2], courses.Tables[0].Rows[i].ItemArray[3]);
                if (Console.ReadLine() != "y")
                    continue;
                courseid = (int)courses.Tables[0].Rows[i].ItemArray[0];
                do
                {
                    InsertTrainer(trainer = new Trainer(), out trainerInserted);
                    if (trainerInserted)
                    {
                        try
                        {
                            using (SqlConnection connection = new SqlConnection("Server = .; DataBase = Bootcamp; Trusted_Connection = True"))
                            {
                                connection.Open();
                                query = "select ID from Trainers where FirstName = @FirstName and LastName = @LastName;"; // ("select ID from Trainers order by ID desc limit 1;") would also work but let's keep it safe"
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@FirstName", trainer.FirstName);
                                    command.Parameters.AddWithValue("@LastName", trainer.LastName);
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            trainerid = reader.GetInt32(0);
                                        }
                                    }
                                }
                                query = "insert into CourseTrainers (CourseID, TrainerID) values (@CourseID, @TrainerID);";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@CourseID", courseid);
                                    command.Parameters.AddWithValue("@TrainerID", trainerid);
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("Trainer assigned to course\n");
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    Console.WriteLine("Do you want to add another trainer to {0} {1} {2}? (y/n)",
                                      courses.Tables[0].Rows[i].ItemArray[1], courses.Tables[0].Rows[i].ItemArray[2], courses.Tables[0].Rows[i].ItemArray[3]);
                } while (Console.ReadLine() == "y");
            }
        }

        internal static void InsertAssignmentsPerStudentPerCourse()
        {
            // this turned out kinda long
            // Description: Iterate through each course, getting its ID(courseid),
            // then iterate through each student, getting its ID(studentid),
            // then input assignmnet, input grade for student(or not) and get ID(assignmentid) from added assignment,
            // then add assignment to student's course, and assign it to the student

            string query = "select * from Courses;";
            DataSet courses = GetDataQuery(query);
            DataSet students;
            Assignment assignment;
            int courseid, studentid;
            int assignmentid = 0;

            int submitted;
            int? oralMark = null;
            int? totalMark = null;

            int tmpint;

            for (int i = 0; i < courses.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine("Do you want to add assignments to students in {0} {1} {2}? (y/n)",
                                   courses.Tables[0].Rows[i].ItemArray[1], courses.Tables[0].Rows[i].ItemArray[2], courses.Tables[0].Rows[i].ItemArray[3]);
                if (Console.ReadLine() != "y")
                    continue;
                courseid = (int)courses.Tables[0].Rows[i].ItemArray[0];
                query = "select * from Students " +
                        "inner join CourseStudents " +
                        "on Students.ID = CourseStudents.StudentID " +
                        "inner join Courses " +
                        "on CourseStudents.CourseID = Courses.ID " +
                        "where Courses.ID = @CourseID;";
                students = GetDataQuery(query, courseid); // There was an error with base method since @CourseID was not declared inside method. New method was created. Ugly solution but it works

                for (int j = 0; j < students.Tables[0].Rows.Count; j++)
                {
                    Console.WriteLine("Do you want to add assignments to {0} {1}? (y/n)",
                                       students.Tables[0].Rows[j].ItemArray[1], students.Tables[0].Rows[j].ItemArray[2]);
                    if (Console.ReadLine() != "y")
                        continue;
                    studentid = (int)students.Tables[0].Rows[j].ItemArray[0];
                    do
                    {
                        InsertAssignment(assignment = new Assignment((DateTime)courses.Tables[0].Rows[i].ItemArray[4], (DateTime)courses.Tables[0].Rows[i].ItemArray[5]));

                        Console.WriteLine("Has the student submitted the assignment? (y/n)");
                        if (Console.ReadLine() == "y")
                            submitted = 1;
                        else
                            submitted = 0;

                        if (submitted == 1)
                        {
                            Console.WriteLine("Input student assignment evaluation. Enter any non number if assignment hasn't been given a mark yet");
                            do
                            {
                                Console.WriteLine("Input student's oral mark: ");
                                oralMark = (int.TryParse(Console.ReadLine(), out tmpint) == true ? (int?)tmpint : null);
                                if (oralMark > assignment.OralMark || oralMark < 0 && oralMark != null)
                                    Console.WriteLine("Error: Value out of assignment oral mark range");
                            } while (oralMark > assignment.OralMark || oralMark < 0 && oralMark != null);
                            do
                            {
                                Console.WriteLine("input student's total mark: ");
                                totalMark = (int.TryParse(Console.ReadLine(), out tmpint) == true ? (int?)tmpint : null);
                                if (totalMark > assignment.TotalMark || totalMark < 0 && totalMark != null)
                                    Console.WriteLine("Error: Value out of assignment total mark range");
                            } while (totalMark > assignment.TotalMark || totalMark < 0 && totalMark != null);
                        }

                        try
                        {
                            using (SqlConnection connection = new SqlConnection("Server = .; DataBase = Bootcamp; Trusted_Connection = True"))
                            {
                                connection.Open();

                                query = "select top 1 ID from Assignments order by ID desc;"; // No danger of getting the wrong assignment, since assignment has no unique values for insertion to fail above
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            assignmentid = reader.GetInt32(0);
                                        }
                                    }
                                }

                                query = "insert into CourseAssignments (CourseID, AssignmentID) values (@CourseID, @AssignmentID);";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@CourseID", courseid);
                                    command.Parameters.AddWithValue("@AssignmentID", assignmentid);
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("Assignment added to course\n");
                                }

                                query = "insert into StudentAssignments (CourseID, StudentID, ASsignmentID, Submitted) values (@CourseID, @StudentID, @AssignmentID, @Submitted);";
                                if (submitted == 1)
                                    if (oralMark == null && totalMark != null)
                                        query = "insert into StudentAssignments (CourseID, StudentID, ASsignmentID, Submitted, TotalMark) values (@CourseID, @StudentID, @AssignmentID, @Submitted, @TotalMark);";
                                    else if (oralMark != null && totalMark == null)
                                        query = "insert into StudentAssignments (CourseID, StudentID, ASsignmentID, Submitted, OralMark) values (@CourseID, @StudentID, @AssignmentID, @Submitted, @OralMark);";
                                    else if (oralMark != null && totalMark != null)
                                        query = "insert into StudentAssignments (CourseID, StudentID, ASsignmentID, Submitted, OralMark, TotalMark) values (@CourseID, @StudentID, @AssignmentID, @Submitted, @OralMark, @TotalMark);";

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@CourseID", courseid);
                                    command.Parameters.AddWithValue("@StudentID", studentid);
                                    command.Parameters.AddWithValue("@AssignmentID", assignmentid);
                                    command.Parameters.AddWithValue("@Submitted", submitted);

                                    if (submitted == 1)
                                    {
                                        if (oralMark == null && totalMark != null)
                                            command.Parameters.AddWithValue("@TotalMark", totalMark);
                                        else if (oralMark != null && totalMark == null)
                                            command.Parameters.AddWithValue("@OralMark", oralMark);
                                        else if (oralMark != null && totalMark != null)
                                        {
                                            command.Parameters.AddWithValue("@OralMark", oralMark);
                                            command.Parameters.AddWithValue("@TotalMark", totalMark);
                                        }
                                    }

                                    command.ExecuteNonQuery();
                                    Console.WriteLine("Assignment assigned to student\n");
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                        Console.WriteLine("Do you want to add another assignment to {0} {1}? (y/n)",
                                          students.Tables[0].Rows[j].ItemArray[1], students.Tables[0].Rows[j].ItemArray[2]);
                    } while (Console.ReadLine() == "y");
                }
            }
        }
    }
}
