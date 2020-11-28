using System;
using Bootcamp.Models;

namespace Bootcamp.BussinessLogic
{
    static class CommandPromtUtilities
    {
        internal static void MainMenu()
        {
            string input;
            do
            {
                PrintMainMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            OutputMenu();
                            Console.WriteLine();
                            break;
                        }
                    case "2":
                        {
                            InsertMenu();
                            Console.WriteLine();
                            break;
                        }
                    case "3":
                        {
                            AssignMenu();
                            Console.WriteLine();
                            break;
                        }
                    case "10":
                        {
                            Console.Clear();
                            break;
                        }
                }
            } while (input != "11");
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }

        private static void OutputMenu()
        {
            Console.Clear();
            string input;
            do
            {
                PrintOutputMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            DatabaseUtilities.PrintAllStudents();
                            Console.WriteLine();
                            break;
                        }
                    case "2":
                        {
                            DatabaseUtilities.PrintAllTrainers();
                            Console.WriteLine();
                            break;
                        }
                    case "3":
                        {
                            DatabaseUtilities.PrintAllAssignments();
                            Console.WriteLine();
                            break;
                        }
                    case "4":
                        {
                            DatabaseUtilities.PrintAllCourses();
                            Console.WriteLine();
                            break;
                        }
                    case "5":
                        {
                            DatabaseUtilities.PrintStudentsPerCourse();
                            Console.WriteLine();
                            break;
                        }
                    case "6":
                        {
                            DatabaseUtilities.PrintTrainersPerCourse();
                            Console.WriteLine();
                            break;
                        }
                    case "7":
                        {
                            DatabaseUtilities.PrintAssignmentsPerCourse();
                            Console.WriteLine();
                            break;
                        }
                    case "8":
                        {
                            DatabaseUtilities.PrintAssignmentsPerCoursePerStudent();
                            Console.WriteLine();
                            break;
                        }
                    case "9":
                        {
                            DatabaseUtilities.PrintStudentsWithMultipleCourses();
                            Console.WriteLine();
                            break;
                        }
                    case "10":
                        {
                            Console.Clear();
                            break;
                        }
                }
            } while (input != "11");
            Console.Clear();
        }

        private static void InsertMenu()
        {
            Console.Clear();
            string input;
            do
            {
                PrintInsertMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            DatabaseUtilities.InsertStudent();
                            Console.WriteLine();
                            break;
                        }
                    case "2":
                        {
                            DatabaseUtilities.InsertTrainer();
                            Console.WriteLine();
                            break;
                        }
                    case "3":
                        {
                            DatabaseUtilities.InsertAssignment();
                            Console.WriteLine();
                            break;
                        }
                    case "4":
                        {
                            DatabaseUtilities.InsertCourse();
                            Console.WriteLine();
                            break;
                        }
                    case "5":
                        {
                            DatabaseUtilities.InsertStudentsPerCourse();
                            Console.WriteLine();
                            break;
                        }
                    case "6":
                        {
                            DatabaseUtilities.InsertTrainersPerCourse();
                            Console.WriteLine();
                            break;
                        }
                    case "7":
                        {
                            DatabaseUtilities.InsertAssignmentsPerStudentPerCourse();
                            Console.WriteLine();
                            break;
                        }
                    case "10":
                        {
                            Console.Clear();
                            break;
                        }
                }
            } while (input != "11");
            Console.Clear();
        }

        private static void AssignMenu()
        {
            Console.Clear();
            string input;
            do
            {
                PrintAssignMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            DatabaseUtilities.AssignStudent();
                            break;
                        }
                    case "2":
                        {
                            DatabaseUtilities.AssignTrainer();
                            break;
                        }
                    case "3":
                        {
                            DatabaseUtilities.AssignAssignment();
                            break;
                        }
                    case "4":
                        {
                            DatabaseUtilities.AssignAssignmentToStudent();
                            break;
                        }
                    case "10":
                        {
                            Console.Clear();
                            break;
                        }
                }
            } while(input != "11" );
            Console.Clear();
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("Please select an option from the list below");
            Console.WriteLine("1) Go to output menu");
            Console.WriteLine("2) Go to insert menu");
            Console.WriteLine("10) Clear console");
            Console.WriteLine("11) Exit");
        }

        private static void PrintOutputMenu()
        {
            Console.WriteLine("Please select an option from the list below");
            Console.WriteLine("1) Print a list of all the students");
            Console.WriteLine("2) Print a list of all the trainers");
            Console.WriteLine("3) Print a list of all the assignments");
            Console.WriteLine("4) Print a list of all the courses");
            Console.WriteLine("5) Print all the students per course");
            Console.WriteLine("6) Print all the trainers per course");
            Console.WriteLine("7) Print all the assignments per course");
            Console.WriteLine("8) Print all the assignments per course per student");
            Console.WriteLine("9) Print a list of students that belong to more than one courses");
            Console.WriteLine("10) Clear console");
            Console.WriteLine("11) Back");
        }

        private static void PrintInsertMenu()
        {
            Console.WriteLine("Please select an option from the list below");
            Console.WriteLine("1) Insert a new student");
            Console.WriteLine("2) Insert a new trainer");
            Console.WriteLine("3) Insert a new assignment");
            Console.WriteLine("4) Insert a new course");
            Console.WriteLine("5) Insert new students per course");
            Console.WriteLine("6) Insert new trainers per course");
            Console.WriteLine("7) Insert assignments per students per course");
            Console.WriteLine("10) Clear console");
            Console.WriteLine("11) Back");
        }

        private static void PrintAssignMenu()
        {
            Console.WriteLine("Please select an option from the list below");
            Console.WriteLine("1) Assign student to class");
            Console.WriteLine("2) Assign trainer to class");
            Console.WriteLine("3) Assign assignment to class");
            Console.WriteLine("4) Assign assignment to student");
            Console.WriteLine("10) Clear console");
            Console.WriteLine("11) Back");
        }
    }
}
