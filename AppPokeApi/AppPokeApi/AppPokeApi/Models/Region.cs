using System;
using System.Collections.Generic;
using System.Text;

namespace AppPokeApi.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string url { get; set; }



        public class RootObject
        {
            public int count { get; set; }
            public object next { get; set; }
            public object previous { get; set; }
            public List<Region> results { get; set; }
        }
    }
}
