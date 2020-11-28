using System;

namespace Bootcamp.Models
{
    class Student
    {
        private string _firstname;

        public string FirstName
        {
            get { return this._firstname; }
            set { this._firstname = value; }
        }

        private string _lastname;

        public string LastName
        {
            get { return this._lastname; }
            set { this._lastname = value; }
        }

        private DateTime _dateofbirth;

        public DateTime DateOfBirth
        {
            get { return this._dateofbirth; }
            set { this._dateofbirth = value; }
        }

        public Student()
        {
            DateTime dateOfBirth;
            bool correctDatetime;
            Console.WriteLine("Input student first name:");
            this.FirstName = Console.ReadLine();
            Console.WriteLine("Input student last name:");
            this.LastName = Console.ReadLine();
            do
            {
                Console.WriteLine("Input student date of birth:");
                correctDatetime = DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
                if (!correctDatetime)
                    Console.WriteLine("Error: Invalid date");
                else if(dateOfBirth.CompareTo(DateTime.Now) > 0)
                    Console.WriteLine("Error: Date of birth is in the future");
            }while (!correctDatetime || dateOfBirth.CompareTo(DateTime.Now) > 0);
            this.DateOfBirth = dateOfBirth;
        }
    }
}
