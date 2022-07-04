using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Семестр_2_Лаба_2
{
    internal class Para
    {
        public DateTime date;
        public DateTime timeOfStart;
        public DateTime timeOfEnd;
        public string place;
        public string text;
        public Para() { }
        public Para(int day,int month, int year, int hourOfStart,int minuteOfStart,int hourOfEnd,int minuteOfEnd,string place, string text)
        {
            date = new DateTime(year, month, day);
            timeOfStart = new DateTime(year, month ,day , hourOfStart, minuteOfStart, 0);
            timeOfEnd = new DateTime(year, month , day , hourOfEnd, minuteOfEnd,0);
            this.text = text;
            this.place = place;
        }
        public void GetInfo()
        {
            Console.WriteLine("Date:\t"+ date.ToShortDateString());
            Console.WriteLine("Start:\t"+ timeOfStart.ToShortTimeString());
            Console.WriteLine("Finish:\t"+ timeOfEnd.ToShortTimeString());
            Console.WriteLine($"Place:{place}\nNotice:{text}");
            Console.WriteLine();
        }
    }
}
