using System;
using System.Globalization;
using System.Threading;
using Bootcamp.BussinessLogic;

namespace Bootcamp.Models
{
    class BootCamp
    {
        public void RunBootcampEditor()
        {
            // DateTime format is ShortDatePattern + LongDatePattern. Now time won't be printed along with date in this assembly

            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;

            Console.WriteLine("Welcome to Bootcamp Editor");
            CommandPromtUtilities.MainMenu();
        }
    }
}
