using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AutoLotEntities db = new AutoLotEntities())
            {
                try
                {
                    //IQueryable<> orderList = from order in db.Orders select order;
                    //Orders or = new Orders() { CarID = 1, CustID = 1, OrderID = 1 };
                    //db.Orders.Add(or);
                    //db.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
