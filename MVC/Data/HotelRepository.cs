using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Data
{
    public class HotelRepository
    {
        private static List<Hotel> hotels = new List<Hotel>();
        static HotelRepository()
        {
            hotels.Add(new Hotel(1, "Hotel zur Post", 2));
            hotels.Add(new Hotel(2, "Hotel Rebstock", 3));
            hotels.Add(new Hotel(3, "Wellness Hotel", 4));
        }
        public List<Hotel> FindAll()
        {
            return hotels;
        }
        public Hotel FindById(int id)
        {
            return hotels.Where(h => h.HotelID == id).FirstOrDefault();
        }
        public void Delete(int hotelid)
        {
            var hotel = FindById(hotelid);
            hotels.Remove(hotel);
        }
        public void Save(Hotel h)
        {
            if (h.HotelID == 0)
            {//neues Hotel einfügen
                hotels.Add(h);
                h.HotelID = hotels.Max(htl => htl.HotelID) + 1;
            }
            else
            {//bestehendes Hotel aktualisieren
                var hotel = FindById(h.HotelID);
                hotel.Bezeichnung = h.Bezeichnung;
                hotel.Sterne = h.Sterne;
            }
        }
    }

}