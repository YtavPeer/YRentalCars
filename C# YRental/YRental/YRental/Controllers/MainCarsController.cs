using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.Entity;

namespace YRental.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class MainCarsController : ApiController
    {
        YRentalDBEntities YRentDB = new YRentalDBEntities();

        // GET: api/MainCars
        public IEnumerable<CarListTable> Get()
        {
            return YRentDB.CarListTables.ToList();
        }

        // GET: api/MainCars/5
        public CarListTable Get(int id)
        {
            return YRentDB.CarListTables.FirstOrDefault(m => m.Car_ID==id);
        }

        // POST: api/MainCars
        public void Post([FromBody]CarListTable c1)
        {
            YRentDB.CarListTables.Add(c1);
            YRentDB.SaveChanges();
        }

        // PUT: api/MainCars/5
        [HttpPut]
        public void Put(int id, [FromBody]CarListTable u1)
        {
            CarListTable u = YRentDB.CarListTables.FirstOrDefault(f => f.Car_ID == id);
            if( u != null) 
            {
                u.Car_Type_ID =u1.Car_Type_ID;
                u.Kilometer = u1.Kilometer;
                u.Picture = u1.Picture;
                u.Undamaged = u1.Undamaged;
                u.Available = u1.Available;
                u.Car_number = u1.Car_number;
                u.Branch_ID = u1.Branch_ID;
                YRentDB.SaveChanges();
            
            }
        }


        // DELETE: api/MainCars/5
        public void Delete(int id)
        {
            CarListTable c = YRentDB.CarListTables.FirstOrDefault(c1 => c1.Car_ID == id);
            if (c != null)
            {
                YRentDB.CarListTables.Remove(c);
                YRentDB.SaveChanges();
            }
        }
    }
}
