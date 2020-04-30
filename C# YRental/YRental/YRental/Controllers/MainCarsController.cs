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
        public void Put(int id, [FromBody]int CarTypeId, string Kilometer, string Picture, int Undamaged, int Available, string CarNumber, int BranchId)
        {
            CarListTable c = YRentDB.CarListTables.FirstOrDefault(c1 => c1.Car_ID == id);
            if( c != null) 
            {
                c.Car_Type_ID = CarTypeId;
                c.Kilometer = Kilometer;
                c.Picture = Picture;
                c.Undamaged = Undamaged;
                c.Available = Available;
                c.Car_number = CarNumber;
                c.Branch_ID = BranchId;
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
