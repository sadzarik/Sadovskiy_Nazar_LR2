using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Семестр_2_Лаба_2
{
    class Schedule
    {
        public List<Para> schedule;
        public Schedule()
        {
            schedule = new List<Para>();
        }
        public Schedule(int capacity)
        {
            schedule = new List<Para>(capacity);
        }
        public void Add(Para para)
        {
            schedule.Add(para);
        }
        public void ShowNotes(int day, int month, int year)
        {
            DateTime date = new DateTime(year, month, day);
            var result = schedule.Where(i => i.date == date).Select(i => i).OrderBy(i=>i.timeOfStart);//обираються ті пари , в яких дата співпадає з введеною
            Console.WriteLine($"Schedule on: {date.ToShortDateString()}:\n");
            foreach (var item in result)
            {
                item.GetInfo();
            }
            Console.WriteLine();
        }
        public void Clear(int day, int month, int year)
        {
            DateTime date = new DateTime(year, month, day);
            schedule.RemoveAll(i => i.date == date); //видаляє всі записи за дастою
            Console.WriteLine($"Schedule on {date.ToShortDateString()} was removed.\n");
        }
        public void ShowSchedule()
        {
            var result = schedule.OrderBy(i=>i.date).ThenBy(i => i.timeOfStart); //сортує по даті і часу 
            Console.WriteLine("_____Full Schedule_____\n");
            foreach (var item in result)
            {
                item.GetInfo();
            }
            Console.WriteLine();
        }
        public void RemoveInfo(int day, int month, int year)
        {//Видаляє інформацію(text) яка є по цій даті
            foreach (int item in SearchingIndexesOfElemsInSchedule(day, month, year))
            {
                schedule[item].text = "";
            }
        }
        public void Remove (Para para) { schedule.Remove(para); }//видаляє пару з розкладу
        public void AddInfo(int day, int month, int year, string newInfo)
        {
            //Додає інформацію(text) до розкладу за датою , наприклад якщо в якийсь день пари онлайн , можна додати цю інформацію
            foreach (int item in SearchingIndexesOfElemsInSchedule(day, month, year))
            {
                schedule[item].text = schedule[item].text + "\n" + newInfo;
            }
        }
        public void ChangeInfo(int day, int month, int year, string newInfo)
        {// Замінює інформацію , наприклад якщо пар не буде , то можна замінити інформацію в цей день на повідомлення *пари не буде*
            foreach (int item in SearchingIndexesOfElemsInSchedule(day, month, year))
            {
                schedule[item].text = newInfo;
            }
        }
        private List<int> SearchingIndexesOfElemsInSchedule(int day, int month, int year)
        {//через інрдекси легше щось змінювати в розкладі, тому зробив цей метод
            DateTime date = new DateTime(year, month, day);
            var result = schedule.Where(i => i.date == date).Select(i => i);
            List<int> range = new List<int>(result.Count());
            foreach (var item in result)
            {
                range.Add(schedule.IndexOf(item));
            }
            return range;
        }
        public void ShowTimeOfStart(string place)
        {
            foreach (var item in schedule)
            {
                if (item.place == place)
                {
                    Console.WriteLine($"Place:\t{place}; Start in:\t{item.timeOfStart.ToShortTimeString()}; " +
                        $"Duration:\t{item.timeOfEnd.Subtract(item.timeOfStart).ToString()}");//Subtract реалізує різницю 
                }
                Console.WriteLine();
            }
        }
        public void SerializeParaToJson(Para para)
        {
            string json = JsonConvert.SerializeObject(para);
            File.WriteAllText(@"C:\Users\user\OneDrive\Lab2Task2.txt", json);
        }
        public Para DeserializeParaFromJson(string file)
        {
            string json = File.ReadAllText(file);
            Para para = JsonConvert.DeserializeObject<Para>(json); 
            return para;
        }
    }
}
