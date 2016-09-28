using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Model;

namespace Limitless.Data
{
    public class LimitlessSeedData : DropCreateDatabaseIfModelChanges<LimitlessEntities>
    {
            protected override void Seed(LimitlessEntities context)
            {
            GetHall().ForEach(c => context.halls.Add(c));
            GetTimetable().ForEach(g => context.timetables.Add(g));

                context.Commit();
            }

            private static List<Hall> GetHall()
            {
                return new List<Hall>
            {
                new Hall {
                    maxCapacity =20,
                    name = "Sala 1",
                    hallId = 0
                },
                new Hall {
                    maxCapacity = 50,
                    name = "Sala 2",
                    hallId = 1
                }
            };
            }

            private static List<Timetable> GetTimetable()
            {
                return new List<Timetable>
            {
             

            };
            }
        }
    }
