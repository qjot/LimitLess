﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Model;

namespace Limitless.Data
{
    public class LimitlessSeedData : DropCreateDatabaseAlways<LimitlessEntities>
    {
            protected override void Seed(LimitlessEntities context)
            {
            //GetHall().ForEach(c => context.halls.Add(c));
            //GetEvent().ForEach(g => context.events.Add(g));
            //GetClasses().ForEach(k => context.classeses.Add(k));
            //GetOrderDetail().ForEach(x => context.orderDetails.Add(x));
                //context.Commit();
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

      

        private static List<Event> GetEvent()
            {
                return new List<Event>
            {
             new Event
             {
                 capacity = 20,
                 eventId = 0,
                 //date = DateTime.Now,
                 trainerId = "asdasdasdasd1",
                 hallId = 0
             },
             new Event
             {

                 capacity = 10,
                 eventId = 1,
                // date = DateTime.Now,
                 trainerId = "2",
                 hallId= 1
             }

            };
            }
        //private static List<Classes> GetClasses()
        //{
        //    return new List<Classes>
        //    {
        //        new Classes
        //        {
        //            name = "Fintess",
        //            id = 0,
        //            description = "Zajęcia fintess dla wszystkich",
        //            last = "45"
        //        }
        //    };
        //}
    }
    }
