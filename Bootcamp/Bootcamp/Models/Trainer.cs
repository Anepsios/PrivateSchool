using System;

namespace Bootcamp.Models
{
    class Trainer
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

        private string _subjects;

        public string Subjects
        {
            get { return this._subjects; }
            set { this._subjects = value; }
        }

        public Trainer()
        {
            Console.WriteLine("Input trainer first name:");
            this.FirstName = Console.ReadLine();
            Console.WriteLine("Input trainer last name:");
            this.LastName = Console.ReadLine();
            Console.WriteLine("Input trainer subject(s):");
            this._subjects = Console.ReadLine();
        }
    }
}
