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
            GetClasses().ForEach(k => context.classeses.Add(k));
            GetOrderDetail().ForEach(x => context.orderDetails.Add(x));
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

        private static List<OrderDetail> GetOrderDetail()
        {
            return new List<OrderDetail>
            {
                new OrderDetail {
                    orderId = 0,
                    orderDetailId = 0,
                    description = "Przykładowe zamówienie",
                    name = "cos",
                    productId = 0,
                    unitPrice = 20,
                    quantity = 1
                },
                new OrderDetail {
                    orderId = 1,
                    orderDetailId = 1,
                    description = "Przykładowe zamówienie 1",
                    name = "cos1",
                    productId = 1,
                    unitPrice = 20,
                    quantity = 1
                }
            };
        }

        private static List<Timetable> GetTimetable()
            {
                return new List<Timetable>
            {
             new Timetable
             {
                 capacity = 20,
                 timetableID = 0,
                 classesID = 0,
                 //date = DateTime.Now,
                 trainerID = 1,
                 hallID = 0
             },
             new Timetable
             {

                 capacity = 10,
                 timetableID = 1,
                 classesID = 1,
                // date = DateTime.Now,
                 trainerID = 2,
                 hallID = 1
             }

            };
            }
        private static List<Classes> GetClasses()
        {
            return new List<Classes>
            {
                new Classes
                {
                    name = "Fintess",
                    classesId = 0,
                    description = "Zajęcia fintess dla wszystkich",
                    last = "45"
                }
            };
        }
    }
    }
