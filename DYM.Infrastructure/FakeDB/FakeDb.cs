using DYM.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DYM.Infrastructure.FakeDB
{
    public class FakeDb
    {
        public List<Entity> Words { get; private set; }

        public FakeDb()
        {
            FillDB();
        }

        private void FillDB()
        {
            Words = new List<Entity>();
        }
    }
}
