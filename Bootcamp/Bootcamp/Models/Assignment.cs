using System;

namespace Bootcamp.Models
{
    class Assignment
    {
        private string _title;

        public string Title 
        {
            get { return this._title; }
            set { this._title = value; }
        }

        private string _description;

        public string Description 
        {
            get { return this._description; }
            set { this._description = value; }
        }

        private DateTime _subdate;

        public DateTime SubDate 
        {
            get { return this._subdate; }
            set { this._subdate = value; }
        }

        private int _oralmark;

        public int OralMark 
        {
            get { return this._oralmark; }
            set { this._oralmark = value; }
        }

        private int _totalmark;

        public int TotalMark 
        {
            get { return this._totalmark; }
            set { this._totalmark = value; }
        }

        public Assignment()
        {
            DateTime subDate;
            bool correctDatetime;
            Console.WriteLine("Input assignment title:");
            this._title = Console.ReadLine();
            Console.WriteLine("Input assignment description:");
            this._description = Console.ReadLine();
            do
            {
                Console.WriteLine("Input submission date:");
                correctDatetime = DateTime.TryParse(Console.ReadLine(), out subDate);
                if (!correctDatetime)
                    Console.WriteLine("Invalid date");
            } while (!correctDatetime);
            this._subdate = subDate;
            Console.WriteLine("Input assignment oral mark:");
            this._oralmark = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input assignment total mark:");
            this._totalmark = Convert.ToInt32(Console.ReadLine());
        }

        public Assignment(DateTime courseStartDate, DateTime courseEndDate)
        {
            // Constructor that also checks if submission date is valid according to the course this assignment belongs to

            DateTime subDate;
            bool validDatetime;
            Console.WriteLine("Input assignment title:");
            this._title = Console.ReadLine();
            Console.WriteLine("Input assignment description:");
            this._description = Console.ReadLine();
            do
            {
                Console.WriteLine("Input submission date:");
                validDatetime = DateTime.TryParse(Console.ReadLine(), out subDate);
                if (!validDatetime)
                    Console.WriteLine("Error: Invalid date");
                else if (subDate.CompareTo(courseEndDate) >= 0)
                    Console.WriteLine("Error: Assignment's submission date is after the end date of its course");
                else if (subDate.CompareTo(courseStartDate) < 0)
                    Console.WriteLine("Error: Assignment's submission date is before the start date of its course");
            } while (!validDatetime || (subDate.CompareTo(courseEndDate) >= 0) || (subDate.CompareTo(courseStartDate) < 0));
            this._subdate = subDate;
            Console.WriteLine("Input assignment oral mark:");
            this._oralmark = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input assignment total mark:");
            this._totalmark = Convert.ToInt32(Console.ReadLine());
        }
    }
}
