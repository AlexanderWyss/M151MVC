using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Hotel
    {
        //Membervariablen
        private int m_HotelID;
        private string m_Bezeichnung;

        private int m_Stene;

        //Konstruktoren
        public Hotel()
        {

        }
        public Hotel(int id, string bezeichnung, int sterne)
        {
            HotelID = id;
            Bezeichnung = bezeichnung;
            Sterne = sterne;
        }

        //Methoden  (Tipp: prp schreiben  + <tab> <tab>)
        public int HotelID
        {
            get { return m_HotelID; }
            set { m_HotelID = value; }
        }

        public string Bezeichnung
        {
            get { return m_Bezeichnung; }
            set { m_Bezeichnung = value; }
        }

        public int Sterne
        {
            get { return m_Stene; }
            set { m_Stene = value; }
        }
    }
}
