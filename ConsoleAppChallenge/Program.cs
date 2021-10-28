using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace ConsoleAppChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            String name, daysandhour;
            String initialandfinalhour;// temphour;
            double total = 0;
            char param = ',', param2 = '=', param3 = '-';
            List<string> stringListName, stringListDayandHour, stringinitialandfinalhour;
            string[] days = new String[] { "MO", "TU", "WE", "TH", "FR", "SA", "SU" };
            string[] hoursMF = new String[] { "00:01", "09:00", "09:01", "18:00", "18:01", "00:00" };
            //25 15 20
            DateTime[] dateTimes = new DateTime[]{
                new DateTime(2021, 1, 1,0,1,0),
                new DateTime(2021, 1, 1,9,0,0),
                new DateTime(2021, 1, 1,9,1,0),
                new DateTime(2021, 1, 1,18,0,0),
                new DateTime(2021, 1, 1,18,1,0),
                new DateTime(2021, 1, 1,0,0,0),
            };
            //30 20 25
            StreamReader sr = new StreamReader("C:\\Users\\riddi\\source\\repos\\ConsoleAppChallenge\\ConsoleAppChallenge\\File\\Test.txt");
            //RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00
            line = sr.ReadLine();
            while (line != null)
            {
                stringListName = line.Split(param2).ToList();
                name = stringListName[0];
                daysandhour = stringListName[1];
                stringListDayandHour = daysandhour.Split(param).ToList();
                for (int i = 0; i < stringListDayandHour.Count; i++) {
                    String day = stringListDayandHour[i].Substring(0,2);
                    String initialhour = stringListDayandHour[i].Substring(2, 4);
                    String finalhour = stringListDayandHour[i].Substring(8, 5);
                    DateTime initial = DateTime.Parse(initialhour);
                    DateTime finalhourdatetime = DateTime.Parse(finalhour);

                    if (day.Equals("SA"))
                    {
                        if (initial.Hour >= dateTimes[0].Hour && finalhourdatetime.Hour <= dateTimes[1].Hour)
                        {
                            total += 30;
                        }
                        else if (initial.Hour >= dateTimes[2].Hour && finalhourdatetime.Hour <= dateTimes[3].Hour)
                        {
                            total += 20;
                        }
                        else if (initial.Hour >= dateTimes[4].Hour && finalhourdatetime.Hour <= dateTimes[5].Hour)
                        {
                            total += 25;
                        }
                    } 
                    else if (day.Equals("SU"))
                    {
                        if (initial.Hour >= dateTimes[0].Hour && finalhourdatetime.Hour <= dateTimes[1].Hour)
                        {
                            total += 30;
                        }
                        else if (initial.Hour >= dateTimes[2].Hour && finalhourdatetime.Hour <= dateTimes[3].Hour)
                        {
                            total += 20;
                        }
                        else if (initial.Hour >= dateTimes[4].Hour && finalhourdatetime.Hour <= dateTimes[5].Hour)
                        {
                            total += 25;
                        }
                    }
                    else 
                    {
                        if (initial.Hour >= dateTimes[0].Hour && finalhourdatetime.Hour <= dateTimes[1].Hour)
                        {
                            total += 25;
                        }
                        else if (initial.Hour >= dateTimes[2].Hour && finalhourdatetime.Hour <= dateTimes[3].Hour)
                        {
                            total += 15;
                        }
                        else if (initial.Hour >= dateTimes[4].Hour && finalhourdatetime.Hour <= dateTimes[5].Hour)
                        {
                            total += 20;
                        }
                    }
                }

                Console.WriteLine(name+" = "+total);
                line = sr.ReadLine();
            }

            sr.Close();
            Console.ReadLine();


        }
    }
}
