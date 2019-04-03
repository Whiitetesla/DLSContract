using DYM.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DYM.Infrastructure.FakeDB
{
    public class FakeDb
    {
        public List<string> Words { get; private set; }

        public FakeDb()
        {
            FillDB();
        }

        private void FillDB()
        {
            Words = new List<string>();

            Words.Add("Cake");
            Words.Add("Food");
            Words.Add("Coffie");
            Words.Add("Tea");
            Words.Add("Soda");
            Words.Add("Coke");
            Words.Add("Fanta");
            Words.Add("Cocio");
            Words.Add("Billions");
            Words.Add("Classic");
            Words.Add("Get");
            Words.Add("Of");
            Words.Add("Month");

        }
    }
}
