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
        public void Put(int id, [FromBody]int CarId, string StartDate, string ReturnEstimateDate, string ReturnRealTime, int UserId, string OrderStatus)
        {
            OrdersTable o = YRentDB.OrdersTables.FirstOrDefault(o1 => o1.Order_ID == id);
            if (o != null) 
            {
                o.Car_ID = CarId;
                o.Start_Date = StartDate;
                o.Return_Estimate_Date = ReturnEstimateDate;
                o.Returm_Real_Date = ReturnRealTime;
                o.User_ID = UserId;
                o.Order_Status = OrderStatus;
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
