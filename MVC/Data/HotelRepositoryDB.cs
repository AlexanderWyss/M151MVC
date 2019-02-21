using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Data
{
    public class HotelRepository
    {
        static HotelRepository()
        {
        }

        public IEnumerable<Hotel> FindAll()
        {
            HotelDBEntities ctx = new HotelDBEntities();
            return ctx.Hotels;
        }

        public Hotel FindById(int id)
        {
            HotelDBEntities ctx = new HotelDBEntities();
            ctx.Configuration.LazyLoadingEnabled = false;
            return ctx
                .Hotels
                .FirstOrDefault(h => h.HotelId == id);
        }

        public void Delete(int hotelid)
        {
            var hotel = FindById(hotelid);
            Delete(hotel);
        }

        public void Delete(Hotel h)
        {
            HotelDBEntities ctx = new HotelDBEntities();
            ctx.Hotels.Attach(h);
            ctx.Entry(h).State = System.Data.Entity.EntityState.Deleted;
            ctx.Hotels.Remove(h);
            ctx.SaveChanges();
        }

        public void Save(Hotel h)
        {
            HotelDBEntities ctx = new HotelDBEntities();
            if (h.HotelId == 0)
            { 
                ctx.Hotels.Add(h);
                ctx.SaveChanges();
            }
            else
            {
                ctx.Hotels.Attach(h);
                ctx.Entry(h).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public void Dispose()
        {
        }
    }
}