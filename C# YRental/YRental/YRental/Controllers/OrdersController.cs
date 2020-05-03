using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace YRental.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class OrdersController : ApiController
    {
        YRentalDBEntities YRentDB = new YRentalDBEntities();

        // GET: api/Orders
        public IEnumerable<OrdersTable> Get()
        {
            return YRentDB.OrdersTables.ToList();
        }

        // GET: api/Orders/5
        public OrdersTable Get(int id)
        {
            return YRentDB.OrdersTables.FirstOrDefault(o => o.Order_ID==id);
        }

        // POST: api/Orders
        public void Post([FromBody]OrdersTable O1)
        {
            YRentDB.OrdersTables.Add(O1);
            YRentDB.SaveChanges();
        }

        // PUT: api/Orders/5

        [HttpPut]
        public void Put(int id, [FromBody]OrdersTable u1)
        {
            OrdersTable u =YRentDB.OrdersTables.FirstOrDefault(f => f.Order_ID == id);
            if (u != null) 
            {
                u.Car_ID = u1.Car_ID;
                u.Start_Date = u1.Start_Date;
                u.Return_Estimate_Date = u1.Return_Estimate_Date;
                u.Return_Real_Date = u1.Return_Real_Date;
                u.User_ID = u1.User_ID;
                u.Order_Status = u1.Order_Status;
                u.Car_Number = u1.Car_Number;
                u.Number_Of_Days = u1.Number_Of_Days;
                u.Price_PerDay = u1.Price_PerDay;
                u.Estimate_Cost = u1.Estimate_Cost;
                u.Number_Of_Delay = u1.Number_Of_Delay;
                u.PricePerDelay = u1.PricePerDelay;
                u.Total_Cost = u1.Total_Cost;
                YRentDB.SaveChanges();     
            }
        }
        
        // DELETE: api/Orders/5
        public void Delete(int id)
        {
            OrdersTable o = YRentDB.OrdersTables.FirstOrDefault(o1 => o1.Order_ID == id);
            if (o != null)
            {
                YRentDB.OrdersTables.Remove(o);
                YRentDB.SaveChanges();
            }
        }
    }
}
