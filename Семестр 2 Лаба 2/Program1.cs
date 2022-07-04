using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Семестр_2_Лаба_2
{
    class Program1
    {
        static void Main(string[] args)
        {
            Para physic = new Para(12, 10, 2022, 8, 30, 10, 0, "18 корпус", "Физика");
            Para math = new Para(12, 10, 2022, 10, 25, 11, 55, "19 корпус", "матем");
            Para ukr = new Para(12, 10, 2022, 12, 20, 13, 50, "18 корпус", "укр мова");
            Para programming = new Para(13, 10, 2022, 8, 30, 10, 0, "19 корпус", "програмування");
            Schedule schedule = new Schedule();
            schedule.Add(physic);
            schedule.Add(math);
            schedule.Add(ukr);  
            schedule.Add(programming);
            //schedule.Clear(13, 10, 2022);
            //schedule.ShowSchedule();
            schedule.ShowNotes(12, 10, 2022);
            schedule.ChangeInfo(12, 10, 2022, "Пари не буде");
            schedule.ShowSchedule();
            schedule.ShowTimeOfStart("19 корпус");
            schedule.SerializeParaToJson(ukr);
            Para ukr2 = schedule.DeserializeParaFromJson(@"C:\Users\user\OneDrive\Lab2Task2.txt");
            schedule.Add(ukr2);
            schedule.Remove(ukr);
            Para matan = new Para(11,10,2022,18,0,20,0,"25 корпус","КР по матану");
            schedule.SerializeParaToJson(matan);
            Para newMatan = schedule.DeserializeParaFromJson(@"C:\Users\user\OneDrive\Lab2Task2.txt");
            schedule.Add(newMatan);
            schedule.ShowSchedule();

        }
    }
}
