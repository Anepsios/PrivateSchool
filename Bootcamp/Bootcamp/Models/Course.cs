using System;

namespace Bootcamp.Models
{
    class Course
    {
        private string _title;

        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        private string _stream;

        public string Stream
        {
            get { return this._stream; }
            set { this._stream = value; }
        }

        private string _type;

        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        private DateTime _startdate;

        public DateTime StartDate
        {
            get { return this._startdate; }
            set { this._startdate = value; }
        }

        private DateTime _enddate;

        public DateTime EndDate
        {
            get { return this._enddate; }
            set { this._enddate = value; }
        }

        public Course()
        {
            DateTime tempDate;
            bool correctDatetime;
            Console.WriteLine("Input course title:");
            this._title = Console.ReadLine();
            Console.WriteLine("Input course stream:");
            this._stream = Console.ReadLine();
            Console.WriteLine("Input course type:");
            this._type = Console.ReadLine();
            do
            {
                Console.WriteLine("Input start date:");
                correctDatetime = DateTime.TryParse(Console.ReadLine(), out tempDate);
                if (!correctDatetime)
                    Console.WriteLine("Error: Invalid date");
            } while (!correctDatetime);
            this._startdate = tempDate;
            do
            {
                Console.WriteLine("Input end date:");
                correctDatetime = DateTime.TryParse(Console.ReadLine(), out tempDate);
                if (!correctDatetime)
                    Console.WriteLine("Error: Invalid date");
                else if(tempDate.CompareTo(this._startdate) <= 0)
                    Console.WriteLine("Error: End date is before/same as start date");
            } while (!correctDatetime || (tempDate.CompareTo(this._startdate) <= 0));
            this._enddate = tempDate;
        }
    }
}
